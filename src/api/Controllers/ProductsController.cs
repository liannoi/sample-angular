using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAngular.Application.Storage.Products;
using SampleAngular.Application.Storage.Products.Commands.Create;
using SampleAngular.Application.Storage.Products.Commands.Delete;
using SampleAngular.Application.Storage.Products.Commands.Update;
using SampleAngular.Application.Storage.Products.Models;
using SampleAngular.Application.Storage.Products.Queries.Get;
using SampleAngular.Application.Storage.Products.Queries.Get.AsList;

namespace SampleAngular.WebAPI.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductsListViewModel>> GetAll()
        {
            try
            {
                return Ok(await Mediator.Send(new GetProductsAsListQuery()));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductLookupDto>> Create([FromBody] CreateProductCommand command)
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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductLookupDto>> GetById(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetProductQuery {ProductId = id}));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductLookupDto>> Update(int id, [FromBody] UpdateProductCommand command)
        {
            try
            {
                command.ProductId = id;
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
        public async Task<ActionResult<ProductLookupDto>> Delete(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteProductCommand {ProductId = id}));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}