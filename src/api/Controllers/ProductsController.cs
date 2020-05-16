using System;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
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