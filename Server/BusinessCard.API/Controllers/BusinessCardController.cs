using BusinessCard.Application.Commands.BusinessCard.Create;
using BusinessCard.Application.Commands.BusinessCard.Delete;
using BusinessCard.Application.Common;
using BusinessCard.Application.DTOs.BusinessCard;
using BusinessCard.Application.Queries.BusinessCard;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusinessCard.Server.Controllers
{
    [ApiController]
    [Route("api/card")]
    public class BusinessCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusinessCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(DataTablesParameters parameters)
        {
            var result = await _mediator.Send(new GetBusinessCardsQuery() { Options = parameters.ToQueryOptions() });

            if (result.Failed)
                return BadRequest(result);

            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBusinessCardRequestDto request)
        {
            var result = await _mediator.Send(new CreateBusinessCardCommand()
            {
                Name = request.Name,
                Email = request.Email,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                CountryCode = request.CountryCode,
                Phone = request.Phone,
                Street = request.Street,
                City = request.City,
                ZipCode = request.ZipCode,
                Photo = request.Photo

            });

            if (result.Failed)
                return BadRequest(result);

            return Ok(result);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var result = await _mediator.Send(new DeleteBusinessCardCommand() { Id = id });

            if (result.Failed)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
