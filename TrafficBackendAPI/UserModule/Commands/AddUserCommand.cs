using MediatR;
using TrafficBackendAPI.DatabaseModule.Models.UserModule;
using TrafficBackendAPI.UserModule.Services;

namespace TrafficBackendAPI.UserModule.Commands
{
    #region Request
    public class AddUserCommandRequest : IRequest<AddUserCommandResponse>
    {
        public required string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public required string LastName { get; set; }

        public bool IsAnonymous { get; set; }

        public required Guid CreatedBy { get; set; }
    }
    #endregion

    #region Response
    public class AddUserCommandResponse
    {
        public Guid Id { get; set; }
    }
    #endregion

    #region Handler
    internal class AddUserCommandHandler : IRequestHandler<AddUserCommandRequest, AddUserCommandResponse>
    {
        #region Variables
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public AddUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Method
        public async Task<AddUserCommandResponse> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
        {
            var addUser = await _userService.AddUser(new UserModel
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                IsAnonymous = request.IsAnonymous,
                CreatedBy = request.CreatedBy
            });

            var result = new AddUserCommandResponse()
            {
                Id = addUser
            };

            return result;
        }
        #endregion
    }
    #endregion
}
