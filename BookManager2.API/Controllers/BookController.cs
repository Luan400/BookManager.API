using BookManager.Application.Command.CreateBook;
using BookManager.Application.Command.DeleteBook;
using BookManager.Application.Command.UpdateBook;
using BookManager.Application.Queries.GetAllBook;
using BookManager.Application.Queries.GetBookById;
using BookManager.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
           var getId = new GetBookByIdQuery(id);

            var Id = await _mediator.Send(getId);

            return Ok(Id);
        }

        [HttpGet]

        public async Task<IActionResult> GetAllAsync(string query)
        {
            var getAll = new GetAllBookQuery(query);

            var id = await _mediator.Send(getAll);

            return Ok(id);
        }


        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var delete = new DeleteBookCommand(id);

            var result = _mediator.Send(delete);

            return Ok(result);

        }

        [HttpPost]

        public async Task<IActionResult> Post([FromBody] CreateBookCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }


        [HttpPut]


        public async Task<IActionResult> Put([FromBody] UpdateBookCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

    }
}
