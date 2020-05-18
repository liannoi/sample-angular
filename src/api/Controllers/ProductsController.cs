using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAngular.Application.Common.Interfaces;
using SampleAngular.Application.Storage.Products;
using SampleAngular.Application.Storage.Products.Commands.Create;
using SampleAngular.Application.Storage.Products.Commands.Delete;
using SampleAngular.Application.Storage.Products.Commands.Update;
using SampleAngular.Application.Storage.Products.Queries.Get;
using SampleAngular.Application.Storage.Products.Queries.Get.AsList;

namespace SampleAngular.WebAPI.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IParentFiller<ProductLookupDto> _filler;

        public ProductsController(IParentFiller<ProductLookupDto> filler)
        {
            _filler = filler;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductsListViewModel>> GetAll()
        {
            try
            {
                var products = await Mediator.Send(new GetProductsAsListQuery());
                foreach (var product in products.Products) await _filler.FillParent(Mediator, product);

                return Ok(products);
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
                var product = await Mediator.Send(new GetProductQuery {ProductId = id});
                await _filler.FillParent(Mediator, product);

                return Ok(product);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductLookupDto>> Update([FromBody] UpdateProductCommand command)
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