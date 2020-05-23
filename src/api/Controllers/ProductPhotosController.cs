using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAngular.Application.Storage.ProductPhotos;
using SampleAngular.Application.Storage.ProductPhotos.Commands.Create;
using SampleAngular.Application.Storage.ProductPhotos.Commands.Delete;
using SampleAngular.Application.Storage.ProductPhotos.Queries.AsList;
using SampleAngular.Application.Storage.ProductPhotos.Queries.AsList.ByProduct;

namespace SampleAngular.WebAPI.Controllers
{
    public class ProductPhotosController : BaseController
    {
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductPhotoLookupDto>> Create()
        {
            try
            {
                var tmp = Request.Form.Files[0];
                return Ok(await Mediator.Send(new CreateProductPhotoCommand()));
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
    }
}