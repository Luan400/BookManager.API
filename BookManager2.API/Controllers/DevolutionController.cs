using BookManager.Application.Command.CreateDevolution;
using BookManager.Application.Queries.GetAllBook;
using BookManager.Application.Queries.GetAllDevolution;
using BookManager.Application.Queries.GetBookById;
using BookManager.Application.Queries.GetDevolutionById;
using BookManager.Domain.Entities;
using BookManager.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/devolution")]
    public class DevolutionController : ControllerBase
    {

        private readonly IMediator _mediator;

        public DevolutionController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet]

        public async Task<IActionResult> GetAllAsync(string query)
        {
            var getAll = new GetAllDevolutionQuery(query);

            var id = await _mediator.Send(getAll);

            return Ok(id);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var getId = new GetDevolutionByIdQuery(id);

            var Id = await _mediator.Send(getId);

            return Ok(Id);
        }

        [HttpPost]

        public async Task<IActionResult> AddAsync([FromBody] CreateDevolutionCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }

    }
}
