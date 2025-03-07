﻿using MediatR;
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
        [HttpPost("[controller]")]
        public async Task<IActionResult> AddUser([FromBody]UserRequestModel userRequestModel)
        {
            var command = new AddUserCommandRequest
            {
                FirstName = userRequestModel.FirstName,
                MiddleName = userRequestModel.MiddleName,
                LastName = userRequestModel.LastName,
                AddressId = userRequestModel.AddressId,
                IsAnonymous = userRequestModel.IsAnonymous,
                CreatedBy = userRequestModel.CreatedBy,
                DateCreated = userRequestModel.DateCreated,
                IsActive = userRequestModel.IsActive
            };

            var result = await _mediator.Send(command);

            if(result is not null)
            {
                return CreatedAtAction(nameof(GetUserById), new { id = result.Id }, result);
            }
            else
            {
                return BadRequest(result!.Message);
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

        [HttpGet("[controller]")]
        public async Task<IActionResult> GetUsers()
        {
            var command = new GetUsersQueryRequest();

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
        #endregion
    }
}
