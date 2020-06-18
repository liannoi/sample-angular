using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAngular.Application.Storage.Manufacturers.Commands.Create;
using SampleAngular.Application.Storage.Manufacturers.Commands.Delete;
using SampleAngular.Application.Storage.Manufacturers.Commands.Update;
using SampleAngular.Application.Storage.Manufacturers.Models;
using SampleAngular.Application.Storage.Manufacturers.Queries;
using SampleAngular.Infrastructure.Common.Pagings;
using SampleAngular.Infrastructure.Pagings;

namespace SampleAngular.WebAPI.Controllers
{
    // TODO: Pull the logic from the controller into the appropriate classes.
    public class ManufacturersController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ListViewModel>> GetAll(int page = 1, int limit = 10)
        {
            try
            {
                return Ok(await Mediator.Send(new ListQuery
                {
                    Info = new ManufacturerPagingViewModel
                        {PagingDetails = new PagingDetails {CurrentPage = page, ItemsPerPage = limit}}
                }));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetailViewModel>> Create(
            [FromBody] CreateCommand command)
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
        public async Task<ActionResult<DetailViewModel>> GetById(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new DetailQuery {ManufacturerId = id}));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetailViewModel>> Update(int id,
            [FromBody] UpdateCommand command)
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
        public async Task<ActionResult<DetailViewModel>> Delete(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteCommand {ManufacturerId = id}));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}