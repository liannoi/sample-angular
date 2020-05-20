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
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ManufacturersListViewModel>> GetAll()
        {
            try
            {
                return Ok(await Mediator.Send(new GetManufacturersAsListQuery()));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ManufacturerLookupDto>> Create([FromBody] CreateManufacturerCommand command)
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

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ManufacturerLookupDto>> Update(int id,
            [FromBody] UpdateManufacturerCommand command)
        {
            try
            {
                command.ManufacturerId = id;
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
        public async Task<ActionResult<ManufacturerLookupDto>> Delete(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteManufacturerCommand {ManufacturerId = id}));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}