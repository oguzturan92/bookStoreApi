using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Category.Commands.Create;
using Application.Features.Category.Commands.Delete;
using Application.Features.Category.Commands.Update;
using Application.Features.Category.Queries.GetAll;
using Application.Features.Category.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllCategoriesQueryRequest());
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (!response.Success)
                return BadRequest(response.Errors);

            return CreatedAtAction(nameof(GetById), new { categoryId = response.CategoryId }, response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int categoryId)
        {
            var result = await _mediator.Send(new GetCategoryByIdQueryRequest { CategoryId = categoryId });
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int categoryId, [FromBody] UpdateCategoryCommandRequest request)
        {
            request.CategoryId = categoryId;
            var result = await _mediator.Send(request);
            if (!result.Success) return BadRequest(result.Errors);
            return NoContent();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            var result = await _mediator.Send(new DeleteCategoryCommandRequest { CategoryId = categoryId });
            if (!result.Success) return NotFound(result.Errors);
            return NoContent();
        }

    }
}