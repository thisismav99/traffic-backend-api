using TrafficBackendAPI.UserModule.Model;

namespace TrafficBackendAPI.UserModule.Services
{
    internal interface IUserService
    {
        Task<Guid> AddUser(UserModel user);
        Task<UserModel?> GetUserById(Guid id);
        Task<List<UserModel>?> GetUsersById(List<Guid> usersId, bool asNoTracking);
        Task<List<UserModel>?> GetUsers(bool asNoTracking);
        Task<string?> UpdateUser(UserModel user);
        Task<string?> DeleteUser(Guid id);
    }
}
