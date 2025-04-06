using TrafficBackendAPI.UserModule.Model;
using TrafficBackendAPI.UserModule.Repositories;

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
        public async Task<Guid> AddUser(UserModel user)
        {
            try
            {
                user.DateCreated = DateTime.UtcNow;
                user.IsActive = true;

                var data = await _genericRepository.Add(user);

                if(data is not null)
                {
                    return data.Id;
                }
                else
                {
                    throw new ArgumentNullException("Data has not been saved.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<string?> DeleteUser(Guid id)
        {
            try
            {
                var entity = await _genericRepository.GetById(id);

                if(entity is not null)
                {
                    await _genericRepository.Delete(entity);

                    return string.Empty;
                }
                else
                {
                    throw new KeyNotFoundException($"ID: {id} was not found.");
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<UserModel?> GetUserById(Guid id)
        {
            try
            {
                var data = await _genericRepository.GetById(id);

                if( data is not null)
                {
                    return data;
                }
                else
                {
                    throw new ArgumentNullException("No data found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<UserModel>?> GetUsers(bool asNoTracking)
        {
            try
            {
                var data = await _genericRepository.GetAll(asNoTracking);

                if(data is not null)
                {
                    return data;
                }
                else
                {
                    throw new ArgumentNullException("No data found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<UserModel>?> GetUsersById(List<Guid> usersId, bool asNoTracking)
        {
            try
            {
                var data = await _genericRepository.GetAllById(usersId, asNoTracking);

                if(data is not null)
                {
                    return data;
                }
                else 
                {
                    throw new ArgumentNullException("No data found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<string?> UpdateUser(UserModel user)
        {
            try
            {
                var existing = await _genericRepository.GetById(user.Id);

                if (existing is not null)
                {
                    await _genericRepository.Update(user);

                    return string.Empty;
                }
                else
                {
                    throw new KeyNotFoundException($"ID: {user.Id} was not found.");
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
    }
}
