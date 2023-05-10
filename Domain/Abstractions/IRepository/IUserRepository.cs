using VKBackendInternship.Domain.DataTransferObjects;

namespace VKBackendInternship.Domain.Abstractions.IRepository
{
    public interface IUserRepository
    {
        public Task<bool> CreateUser(UserRegistrationRequest request);
        public Task<PaginationList<UserData>> GetUsers(int page, int count);
        public Task<UserData> GetUser(string login);
        public Task<bool> DeleteUser(string login);
        public Task<bool> IsAdminExist();
        public Task<bool> IsUserExist(string login);
    }
}
