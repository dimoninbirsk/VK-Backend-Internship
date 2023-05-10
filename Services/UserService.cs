using VKBackendInternship.DataAccessLayer.Model;
using VKBackendInternship.Domain.Abstractions.IRepository;
using VKBackendInternship.Domain.DataTransferObjects;
using VKBackendInternship.Domain.Enums;

namespace VKBackendInternship.Services
{
    public class UserService : IUserService 
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) 
        { 
            _repository = repository;
        }
        public async Task<Result<bool>> CreateUser(UserRegistrationRequest request)
        {
            Result<bool> result = new Result<bool>();
            if (_repository.IsAdminExist().Result)
            {
                result.Errors.Add("Администратор уже существует");
                result.Data = false;
                return result;
            }
            if (_repository.IsUserExist(request.Login).Result)
            {
                result.Errors.Add("Пользователь уже существует");
                result.Data = false;
                return result;
            }
            await _repository.CreateUser(request);
            Task.Delay(5000).Wait();
            result.Data = true;
            return result;
        }
        public async Task<Result<UserData>> GetUser(string login)
        {
            Result<UserData> result = new Result<UserData>();
            if (_repository.IsUserExist(login).Result == false)
            {
                result.Errors.Add("Такого пользователя не существует");
                result.Data = null;
                return result;
            }
            var user = await _repository.GetUser(login);
            result.Data = user;
            return result;
        }
        public async Task<Result<PaginationList<UserData>>> GetUsers(int page, int size)
        {
            Result<PaginationList<UserData>> result = new Result<PaginationList<UserData>>();
            if (page <= 0 || size <= 0)
            {
                result.Errors.Add("Введены неккоректные параметры пагинации");
                result.Data = null;
                return result;
            }
            var users = await _repository.GetUsers(page, size);
            result.Data = users;
            return result;
        }
        public async Task<Result<bool>> DeleteUser(string login)
        {
            Result<bool> result = new Result<bool>();
            if(_repository.IsUserExist(login).Result == false)
            {
                result.Errors.Add("Пользователя не существует");
                result.Data = false;
                return result;
            }
            if(_repository.GetUser(login).Result.State.Status == Status.Blocked)
            {
                result.Errors.Add("Пользователя уже заблокирован");
                result.Data = false;
                return result;
            }
            result.Data = await _repository.DeleteUser(login);
            return result;
        }
    }
}
