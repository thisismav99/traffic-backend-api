using TrafficBackendAPI.UserModule.Models;
using TrafficBackendAPI.UserModule.Repositories;
using TrafficBackendAPI.UserModule.Utilities;

namespace TrafficBackendAPI.UserModule.Services
{
    internal class UserService : IUserService
    {
        #region Variables
        private readonly IGenericRepository<UserModel, UserDbContext> _genericRepository;
        #endregion

        #region Constructor
        public UserService(IGenericRepository<UserModel, UserDbContext> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        #endregion

        #region Methods
        public async Task<(UserModel?, string?)> AddUser(UserModel user)
        {
            try
            {
                var data = await _genericRepository.Add(user);

                if(data is not null)
                {
                    return (data, ResponseMessageHelper.ServiceCommandMessage(1));
                }
                else
                {
                    return (null, ResponseMessageHelper.ServiceCommandMessage(2));
                }
            }
            catch(Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<(UserModel?, string?)> GetUserById(Guid id)
        {
            try
            {
                var data = await _genericRepository.GetById(id);

                if( data is not null)
                {
                    return (data, ResponseMessageHelper.ServiceQueryMessage(1));
                }
                else
                {
                    return (null, ResponseMessageHelper.ServiceQueryMessage(2));
                }
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<(List<UserModel>?, string?)> GetUsers(List<Guid>? usersId, bool asNoTracking)
        {
            try
            {
                var data = await _genericRepository.GetAll(usersId, asNoTracking);

                if(data is not null)
                {
                    return (data, ResponseMessageHelper.ServiceQueryMessage(1));
                }
                else
                {
                    return (null, ResponseMessageHelper.ServiceQueryMessage(2));
                }
            }
            catch(Exception ex)
            {
                return (null, ex.Message);
            }
        }
        #endregion
    }
}
