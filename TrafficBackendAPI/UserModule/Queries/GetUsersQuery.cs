using MediatR;
using TrafficBackendAPI.UserModule.Services;

namespace TrafficBackendAPI.UserModule.Queries
{
    #region Request
    public class GetUsersQueryRequest : IRequest<List<GetUsersQueryResponse>>
    {
        public List<Guid>? Id { get; set; }

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

        public bool? IsActive { get; set; } = null;

        public string? Message { get; set; } = null;
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
            var getUsers = await _userService.GetUsers(request.Id, request.AsNoTracking);

            if(getUsers.Item1 is not null)
            {
                var custom = getUsers.Item1.Select(x => new GetUsersQueryResponse
                {
                    Id = x.Id,
                    FirstName =  x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    IsAnonymous = x.IsAnonymous,
                    CreatedBy = x.CreatedBy,
                    DateCreated = x.DateCreated,
                    IsActive = x.IsActive,
                    Message = getUsers.Item2
                }).ToList();

                var result = new List<GetUsersQueryResponse>();
                result.AddRange(custom);

                return result;
            }
            else
            {
                var result = new List<GetUsersQueryResponse>();

                result.Select(x => new GetUsersQueryResponse
                {
                    Message = getUsers.Item2
                }).ToList();

                return result;
            }
        }
        #endregion
    }
    #endregion
}
