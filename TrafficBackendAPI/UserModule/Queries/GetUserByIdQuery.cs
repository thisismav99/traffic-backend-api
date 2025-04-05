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
        public Guid Id { get; set; }

        public string? FirstName { get; set; } = null;

        public string? MiddleName { get; set; } = null;

        public string? LastName { get; set; } = null;

        public bool? IsAnonymous { get; set; } = null;

        public Guid? CreatedBy { get; set; } = Guid.Empty;

        public DateTime? DateCreated { get; set; } = null;

        public Guid? UpdatedBy { get; set; } = Guid.Empty;

        public DateTime? DateUpdated { get; set; } = null;

        public bool? IsActive { get; set; } = null;
    }
    #endregion

    #region Handler
    internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
    {
        #region Variables
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Method
        public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var getUser = await _userService.GetUserById(request.Id);
            var result = new GetUserByIdQueryResponse();

            if (getUser is not null)
            {
                result = new GetUserByIdQueryResponse
                {
                    Id = getUser.Id,
                    FirstName = getUser.FirstName,
                    MiddleName = getUser.MiddleName,
                    LastName = getUser.LastName,
                    IsAnonymous = getUser.IsAnonymous,
                    CreatedBy = getUser.CreatedBy,
                    DateCreated = getUser.DateCreated,
                    UpdatedBy = getUser.UpdatedBy,
                    DateUpdated = getUser.DateUpdated,
                    IsActive = getUser.IsActive
                };
            }

            return result;
        }
        #endregion
    }
    #endregion
}
