using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAngular.Application.Storage.Manufacturers;
using SampleAngular.Application.Storage.Manufacturers.Commands.Create;
using SampleAngular.Application.Storage.Manufacturers.Commands.Delete;
using SampleAngular.Application.Storage.Manufacturers.Commands.Update;
using SampleAngular.Application.Storage.Manufacturers.Queries.Get;
using SampleAngular.Application.Storage.Manufacturers.Queries.Get.AsList;

namespace SampleAngular.WebAPI.Controllers
{
    public class ManufacturersController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ManufacturerLookupDto>> Create(CreateManufacturerCommand command)
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
        public async Task<ActionResult<ManufacturersListViewModel>> GetAll(int limit = 0)
        {
            try
            {
                var result = await Mediator.Send(new GetManufacturersAsListQuery());
                if (limit > 0) result.Manufacturers = result.Manufacturers.Take(limit).ToList();

                return Ok(result);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ManufacturerLookupDto>> GetById(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetManufacturerQuery {ManufacturerId = id}));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ManufacturerLookupDto>> Update(UpdateManufacturerCommand command)
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
        public async Task<ActionResult<ManufacturerLookupDto>> Delete(DeleteManufacturerCommand command)
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