using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppUsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommandRequest request)
        {
            var result = await _mediator.Send(request);

            if (!result.Success)
                return BadRequest(result.Errors);

            return Ok("Kayıt başarılı.");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest request)
        {
            var result = await _mediator.Send(request);

            if (!result.Success)
                return Unauthorized(result.Errors);

            return Ok(new { token = result.Token });
        }
    }
}