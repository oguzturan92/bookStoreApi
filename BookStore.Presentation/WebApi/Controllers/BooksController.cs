using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Book.Commands.Create;
using Application.Features.Book.Commands.Delete;
using Application.Features.Book.Commands.Update;
using Application.Features.Book.Queries.GetAll;
using Application.Features.Book.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllBooksQueryRequest());
            return Ok(response);
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateBookCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (!response.Success)
                return BadRequest(response.Errors);

            return CreatedAtAction(nameof(GetById), new { bookId = response.BookId }, response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int bookId)
        {
            var result = await _mediator.Send(new GetBookByIdQueryRequest { BookId = bookId });
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateBookCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (!result.Success) return BadRequest(result.Errors);
            return NoContent();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int bookId)
        {
            var result = await _mediator.Send(new DeleteBookCommandRequest { BookId = bookId });
            if (!result.Success) return NotFound(result.Errors);
            return NoContent();
        }

        // Deneme Amaçlı Metot
        [HttpGet("ThrowError")]
        public IActionResult ThrowError()
        {
            throw new Exception("Test hatası");
        }

    }
}