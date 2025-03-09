using DemoCQRS.Commands.CreateUser;
using DemoCQRS.Commands.DeleteUser;
using DemoCQRS.Commands.UpdateUser;
using DemoCQRS.Queries.GetUserById;
using DemoCQRS.Queries.GetUserList;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMediator _mediator;
        public UsersController(ILogger<UsersController> logger,
            IMediator mediator) 
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(List<GetUserListQueryResponse>), 200, "application/json")]
        public async Task<ActionResult> GetList(
            [FromQuery]GetUserListQuery request,
            CancellationToken cancellationToken,
            IValidator<GetUserListQuery> validator)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(CreateUserCommandResponse), 200, "application/json")]
        public async Task<ActionResult> Create([FromBody]CreateUserCommand request,
            CancellationToken cancellationToken,
            IValidator<CreateUserCommand> validator)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }
            
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(UpdateUserCommandResponse), 200, "application/json")]
        public async Task<ActionResult> Update([FromBody] UpdateUserCommand request,
            CancellationToken cancellationToken,
            IValidator<UpdateUserCommand> validator)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }

            await _mediator.Send(request, cancellationToken);
            return Ok();
        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(GetUserByIdQueryResponse), 200, "application/json")]
        public async Task<ActionResult> GetById(
            [FromRoute]Guid id,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _mediator.Send(new GetUserByIdQuery { Id = id }, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Consumes("application/json")]
        public async Task<ActionResult> DeleteById(
            [FromRoute]Guid id,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _mediator.Send(new DeleteUserByIdCommand { Id = id }, cancellationToken);
            return Ok();
        }
    }
}
