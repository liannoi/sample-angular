using System.Linq;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductLookupDto>> Create(CreateProductCommand command)
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

        [HttpGet("{limit?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductsListViewModel>> GetAll(int limit = 0)
        {
            try
            {
                var products = await Mediator.Send(new GetProductsAsListQuery());
                var takenProducts = limit == 0 ? products.Products : products.Products.Take(limit);
                foreach (var product in takenProducts) await _filler.FillParent(Mediator, product);

                return Ok(takenProducts);
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

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductLookupDto>> Update(UpdateProductCommand command)
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

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductLookupDto>> Delete(DeleteProductCommand command)
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
    }
}