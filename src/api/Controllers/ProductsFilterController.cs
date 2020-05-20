using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAngular.Application.Storage.Products.Models;
using SampleAngular.Application.Storage.Products.Queries.Get.AsList;

namespace SampleAngular.WebAPI.Controllers
{
    public class ProductsFilterController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductsListViewModel>> GetAllByFilter(
            [FromForm] GetProductsAsListByFilterQuery command)
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