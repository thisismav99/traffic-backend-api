using MediatR;
using TrafficBackendAPI.UserModule.Models;
using TrafficBackendAPI.UserModule.Services;

namespace TrafficBackendAPI.UserModule.Commands
{
    #region Request
    public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
    {
        public required string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public required string LastName { get; set; }

        public bool IsAnonymous { get; set; }

        public required Guid CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }
    }
    #endregion

    #region Response
    public class UpdateUserCommandResponse
    {
        public string? Message { get; set; }
    }
    #endregion

    #region Handler
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        #region Variables
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Method
        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var updateResult = await _userService.UpdateUser(new UserModel
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                IsAnonymous = request.IsAnonymous,
                CreatedBy = request.CreatedBy,
                DateCreated = request.DateCreated,
                IsActive = request.IsActive,
            });

            return new UpdateUserCommandResponse
            {
                Message = updateResult
            };
        }
        #endregion
    }
    #endregion
}
