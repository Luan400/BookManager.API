using BookManager.Application.Command.CreateLoans;
using BookManager.Application.Command.UpdateLoans;
using BookManager.Application.Queries.GetAllBook;
using BookManager.Application.Queries.GetAllLoans;
using BookManager.Application.Queries.GetBookById;
using BookManager.Application.Queries.GetLoansById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/loans")]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]

        public async Task<IActionResult> GetAllAsync(string query)
        {
            var getAll = new GetAllLoansQuery(query);

            var id = await _mediator.Send(getAll);

            return Ok(id);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var getId = new GetLoansByIdQuery(id);

            var Id = await _mediator.Send(getId);

            return Ok(Id);
        }

        [HttpPost]

        public async Task<IActionResult> AddAsync([FromBody] CreateLoansCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateDateAsync([FromBody] UpdateLoansCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
