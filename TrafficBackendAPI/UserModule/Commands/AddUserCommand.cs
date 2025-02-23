using MediatR;
using TrafficBackendAPI.UserModule.Models;
using TrafficBackendAPI.UserModule.Services;

namespace TrafficBackendAPI.UserModule.Commands
{
    #region Request
    public class AddUserCommandRequest : IRequest<AddUserCommandResponse>
    {
        public required string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public required string LastName { get; set; }

        public Guid? AddressId { get; set; }

        public bool IsAnonymous { get; set; }

        public required Guid CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }
    }
    #endregion

    #region Response
    public class AddUserCommandResponse
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; } = null;

        public string? MiddleName { get; set; } = null;

        public string? LastName { get; set; } = null;

        public Guid? AddressId { get; set; } = Guid.Empty;

        public bool? IsAnonymous { get; set; } = null;

        public Guid? CreatedBy { get; set; } = Guid.Empty;

        public DateTime? DateCreated { get; set; } = null;

        public bool? IsActive { get; set; } = null;

        public string? Message { get; set; } = null;
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
            var addResult = await _userService.AddUser(new UserModel
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                AddressId = request.AddressId,
                IsAnonymous = request.IsAnonymous,
                CreatedBy = request.CreatedBy,
                DateCreated = request.DateCreated,
                IsActive = request.IsActive
            });

            if(addResult.Item1 is not null)
            {
                var result = new AddUserCommandResponse
                {
                    Id = addResult.Item1.Id,
                    FirstName = addResult.Item1.FirstName,
                    MiddleName = addResult.Item1.MiddleName,
                    LastName = addResult.Item1.LastName,
                    AddressId = addResult.Item1.AddressId,
                    IsAnonymous = addResult.Item1.IsAnonymous,
                    CreatedBy = addResult.Item1.CreatedBy,
                    DateCreated = addResult.Item1.DateCreated,
                    IsActive = addResult.Item1.IsActive,
                    Message = addResult.Item2
                };

                return result;
            }
            else
            {
                var result = new AddUserCommandResponse
                {
                    Message = addResult.Item2
                };

                return result;
            }
        }
        #endregion
    }
    #endregion
}
