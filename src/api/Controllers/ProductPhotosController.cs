using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAngular.Application.Storage.Products.Photos.Commands;
using SampleAngular.Application.Storage.Products.Photos.Models;
using SampleAngular.Application.Storage.Products.Photos.Queries;
using SampleAngular.WebAPI.Infrastructure;

namespace SampleAngular.WebAPI.Controllers
{
    public class ProductPhotosController : BaseController
    {
        private readonly IWebImageSaver _webImageSaver;

        public ProductPhotosController(IWebImageSaver webImageSaver)
        {
            _webImageSaver = webImageSaver;
        }

        /// <summary>
        ///     Getting all photos of a product.
        /// </summary>
        /// <param name="id">The value of the primary product key.</param>
        /// <returns>Object with a collection of product photos.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ListViewModel>> GetAllByProduct(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new ListQuery.ByProduct {ProductId = id}));
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
        public async Task<ActionResult<ListViewModel>> GetAll()
        {
            try
            {
                return Ok(await Mediator.Send(new ListQuery()));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductPhotoDto>> Upload(int id)
        {
            try
            {
                var file = Request.Form.Files.FirstOrDefault() ?? throw new ArgumentException();
                var uniqueFileName = _webImageSaver.Unique(file);
                await _webImageSaver.SaveAsync(GeneratePath(uniqueFileName), file);

                return Ok(await Mediator.Send(new CreateCommand
                {
                    ProductId = id,
                    Path = _webImageSaver.Path(ApiDefaults.ProductPhotosPath, uniqueFileName)
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
        public async Task<ActionResult<ProductPhotoDto>> Delete(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteCommand {PhotoId = id}));
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