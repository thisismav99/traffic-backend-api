using MediatR;
using TrafficBackendAPI.UserModule.Services;

namespace TrafficBackendAPI.UserModule.Commands
{
    #region Request
    public class DeleteUserCommandRequest : IRequest<DeleteUserCommandResponse>
    {
        public Guid Id { get; set; }
    }
    #endregion

    #region Response
    public class DeleteUserCommandResponse
    {
        public string? Message { get; set; }
    }
    #endregion

    #region Handler
    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
    {
        #region Variables
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Method
        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteResult = await _userService.DeleteUser(request.Id);

            return new DeleteUserCommandResponse()
            {
                Message = deleteResult
            };
        }
        #endregion
    }
    #endregion
}
