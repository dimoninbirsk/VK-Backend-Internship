using VKBackendInternship.Domain.DataTransferObjects;

namespace VKBackendInternship.Domain.Abstractions.IRepository
{
    public interface IUserService
    {
        public Task<Result<bool>> CreateUser(UserRegistrationRequest request);
        public Task<Result<UserData>> GetUser(string login);
        public Task<Result<PaginationList<UserData>>> GetUsers(int page, int size);
        public Task<Result<bool>> DeleteUser(string login);
    }
}
