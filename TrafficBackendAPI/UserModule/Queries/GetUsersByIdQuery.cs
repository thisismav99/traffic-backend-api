using MediatR;
using TrafficBackendAPI.UserModule.Services;

namespace TrafficBackendAPI.UserModule.Queries
{
    #region Request
    public class GetUsersByIdQueryRequest : IRequest<List<GetUsersByIdQueryResponse>>
    {
        public required List<Guid> UsersId { get; set; }

        public bool AsNoTracking { get; set; }
    }
    #endregion

    #region Response
    public class GetUsersByIdQueryResponse
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
    internal class GetUsersByIdQueryHandler : IRequestHandler<GetUsersByIdQueryRequest, List<GetUsersByIdQueryResponse>>
    {
        #region Variables
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public GetUsersByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Method
        public async Task<List<GetUsersByIdQueryResponse>> Handle(GetUsersByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var getUsersById = await _userService.GetUsersById(request.UsersId, request.AsNoTracking);
            var result = new List<GetUsersByIdQueryResponse>();

            if(getUsersById is not null)
            {
                var custom = getUsersById.Select(x => new GetUsersByIdQueryResponse
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
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
