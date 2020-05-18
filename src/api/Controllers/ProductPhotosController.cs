using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAngular.Application.Storage.Products.Infrastructure.Photos;
using SampleAngular.Application.Storage.Products.Infrastructure.Photos.Commands.Create;
using SampleAngular.Application.Storage.Products.Infrastructure.Photos.Commands.Delete;

namespace SampleAngular.WebAPI.Controllers
{
    public class ProductPhotosController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductPhotoLookupDto>> Create([FromBody] CreateProductPhotoCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
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