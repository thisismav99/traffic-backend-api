using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrafficBackendAPI.Models.Users;
using TrafficBackendAPI.UserModule.Commands;
using TrafficBackendAPI.UserModule.Queries;

namespace TrafficBackendAPI.Controllers.Users
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        #region Variables
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]AddUserModel addUserModel)
        {
            if(ModelState.IsValid)
            {
                var command = new AddUserCommandRequest
                {
                    FirstName = addUserModel.FirstName,
                    MiddleName = addUserModel.MiddleName,
                    LastName = addUserModel.LastName,
                    IsAnonymous = addUserModel.IsAnonymous,
                    CreatedBy = addUserModel.CreatedBy
                };

                var result = await _mediator.Send(command);

                if(result is not null)
                {
                    return CreatedAtAction(nameof(GetUserById), new { id = result.Id }, result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var command = new GetUserByIdQueryRequest
            {
                Id = id
            };

            var result = await _mediator.Send(command);

            if(result is not null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("/api/Users")]
        public async Task<IActionResult> GetUsers([FromQuery]bool asNoTracking)
        {
            var command = new GetUsersQueryRequest 
            { 
                AsNoTracking = asNoTracking,
            };

            var result = await _mediator.Send(command);

            if(result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var command = new DeleteUserCommandRequest()
            {
                Id = id
            };

            var result = await _mediator.Send(command);

            if(string.IsNullOrEmpty(result.Message))
            {
                return NoContent();
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody]UpdateUserModel updateUserModel)
        {
            if (ModelState.IsValid)
            {
                var command = new UpdateUserCommandRequest()
                {
                    Id = updateUserModel.Id,
                    FirstName = updateUserModel.FirstName,
                    MiddleName = updateUserModel.MiddleName,
                    LastName = updateUserModel.LastName,
                    IsAnonymous = updateUserModel.IsAnonymous,
                    UpdatedBy = updateUserModel.UpdatedBy,
                    DateUpdated = updateUserModel.DateUpdated,
                    IsActive = updateUserModel.IsActive,
                };

                var result = await _mediator.Send(command);

                if(string.IsNullOrEmpty(result.Message))
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(result);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion
    }
}
