using MediatR;
using TrafficBackendAPI.UserModule.Services;

namespace TrafficBackendAPI.UserModule.Queries
{
    #region Request
    public class GetUserByIdQueryRequest : IRequest<GetUserByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
    #endregion

    #region Response
    public class GetUserByIdQueryResponse
    {
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
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
    {
        #region Variables
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        internal GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Method
        public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var getUser = await _userService.GetUserById(request.Id);

            if (getUser.Item1 is not null)
            {
                var result = new GetUserByIdQueryResponse
                {
                    FirstName = getUser.Item1.FirstName,
                    MiddleName = getUser.Item1.MiddleName,
                    LastName = getUser.Item1.LastName,
                    AddressId = getUser.Item1.AddressId,
                    IsAnonymous = getUser.Item1.IsAnonymous,
                    CreatedBy = getUser.Item1.CreatedBy,
                    DateCreated = getUser.Item1.DateCreated,
                    IsActive = getUser.Item1.IsActive,
                    Message = getUser.Item2
                };

                return result;
            }
            else
            {
                var result = new GetUserByIdQueryResponse
                {
                    Message = getUser.Item2
                };

                return result;
            }
        }
        #endregion
    }
    #endregion
}
