using MediatR;
using TrafficBackendAPI.UserModule.Model;
using TrafficBackendAPI.UserModule.Services;

namespace TrafficBackendAPI.UserModule.Commands
{
    #region Request
    public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
    {
        public Guid Id { get; set; }

        public required string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public required string LastName { get; set; }

        public bool IsAnonymous { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime DateUpdated { get; set; }

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
            var updateUser = await _userService.UpdateUser(new UserModel
            {
                Id = request.Id,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                IsAnonymous = request.IsAnonymous,
                UpdatedBy = request.UpdatedBy,
                DateUpdated = request.DateUpdated,
                IsActive = request.IsActive,
            });

            return new UpdateUserCommandResponse
            {
                Message = updateUser
            };
        }
        #endregion
    }
    #endregion
}
