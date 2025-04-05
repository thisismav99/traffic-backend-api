using MediatR;
using TrafficBackendAPI.UserModule.Services;

namespace TrafficBackendAPI.UserModule.Queries
{
    #region Request
    public class GetUsersQueryRequest : IRequest<List<GetUsersQueryResponse>>
    {
        public bool AsNoTracking { get; set; }
    }
    #endregion

    #region Response
    public class GetUsersQueryResponse
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
    internal class GetUsersQueryHandler : IRequestHandler<GetUsersQueryRequest, List<GetUsersQueryResponse>>
    {
        #region Variables
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public GetUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Method
        public async Task<List<GetUsersQueryResponse>> Handle(GetUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var getUsers = await _userService.GetUsers(request.AsNoTracking);
            var result = new List<GetUsersQueryResponse>();

            if(getUsers is not null)
            {
                var custom = getUsers.Select(x => new GetUsersQueryResponse
                {
                    Id = x.Id,
                    FirstName =  x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    IsAnonymous = x.IsAnonymous,
                    CreatedBy = x.CreatedBy,
                    DateCreated = x.DateCreated,
                    UpdatedBy = x.UpdatedBy,
                    DateUpdated = x.DateUpdated,
                    IsActive = x.IsActive,
                }).ToList();

                result.AddRange(custom);
            }

            return result;
        }
        #endregion
    }
    #endregion
}
