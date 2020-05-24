using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAngular.Application.Storage.ProductPhotos;
using SampleAngular.Application.Storage.ProductPhotos.Commands.Create;
using SampleAngular.Application.Storage.ProductPhotos.Commands.Delete;
using SampleAngular.Application.Storage.ProductPhotos.Queries.AsList;
using SampleAngular.Application.Storage.ProductPhotos.Queries.AsList.ByProduct;
using SampleAngular.WebAPI.Infrastructure;

namespace SampleAngular.WebAPI.Controllers
{
    public class ProductPhotosController : BaseController
    {
        private readonly IApiImageSaver _apiImageSaver;

        public ProductPhotosController(IApiImageSaver apiImageSaver)
        {
            _apiImageSaver = apiImageSaver;
        }

        /// <summary>
        ///     Getting all photos of a product.
        /// </summary>
        /// <param name="id">The value of the primary product key.</param>
        /// <returns>Object with a collection of product photos.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductPhotosListViewModel>> GetAllByProduct(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetProductPhotosAsListByProductQuery {ProductId = id}));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        ///     Getting absolutely all photos.
        /// </summary>
        /// <returns>Object with a collection of absolutely all photos.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductPhotosListViewModel>> GetAll()
        {
            try
            {
                return Ok(await Mediator.Send(new GetProductPhotosAsListQuery()));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductPhotoLookupDto>> Upload(int id)
        {
            try
            {
                var file = Request.Form.Files.FirstOrDefault() ?? throw new ArgumentException();
                var uniqueFileName = _apiImageSaver.GenerateUniqueFileName(file);
                await _apiImageSaver.SaveImageAsync(GeneratePath(uniqueFileName), file);

                return Ok(await Mediator.Send(new CreateProductPhotoCommand
                {
                    ProductId = id,
                    Path = _apiImageSaver.GenerateDatabasePath(ApiDefaults.ProductPhotosPath, uniqueFileName)
                }));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductPhotoLookupDto>> Delete(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteProductPhotoCommand {PhotoId = id}));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        #region Helpers

        // ReSharper disable once MemberCanBeMadeStatic.Local
        private string GeneratePath(string uniqueFileName)
        {
            return Path.Combine($"{Directory.GetCurrentDirectory()}/{ApiDefaults.ProductPhotosPath}", uniqueFileName);
        }

        #endregion
    }
}