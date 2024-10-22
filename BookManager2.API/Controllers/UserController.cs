
using BookManager.Application.Command.CreateUser;
using BookManager.Application.Queries.GetAllBook;
using BookManager.Application.Queries.GetAllUser;
using BookManager.Application.Queries.GetBookById;
using BookManager.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace BookManager.API.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]

        public async Task<IActionResult> GetAllAsync(string query)
        {
            var getAll = new GetAllUserQuery(query);

            var id = await _mediator.Send(getAll);

            return Ok(id);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var getId = new GetUserByIdQuery(id);

            var Id = await _mediator.Send(getId);

            return Ok(Id);
        }

        [HttpPost]

        public async Task<IActionResult> AddAsync([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }
    }
}
