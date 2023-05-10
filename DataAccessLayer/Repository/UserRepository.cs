using Microsoft.EntityFrameworkCore;
using VKBackendInternship.DataAccessLayer.Data;
using VKBackendInternship.DataAccessLayer.Model;
using VKBackendInternship.Domain.Abstractions.IRepository;
using VKBackendInternship.Domain.DataTransferObjects;
using VKBackendInternship.Domain.Enums;

namespace VKBackendInternship.DataAccessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context) 
        {
            this._context = context;
        }
        public async Task<bool> CreateUser(UserRegistrationRequest request)
        {
            var id = Guid.NewGuid();
            var group = new UserGroup()
            {
                Id = id,
                Role = request.Role,
                Description = request.RoleDescription,
            };
            await _context.UsersGroup.AddAsync(group);
            var status = new UserState()
            {
                Id = id,
                Status = Status.Active,
                Description = request.StatusDescription,
            };
            await _context.UsersState.AddAsync(status);
            var newUser = new User()
            {
                Id = id,
                DateOfCreation = DateTime.UtcNow,
                Login = request.Login,
                Password = request.Password,
                GroupId = id,
                StateId = id,
            };
            await _context.Users.AddAsync(newUser);
            _context.SaveChanges();
            return true;
        }
        public async Task<PaginationList<UserData>> GetUsers(int page, int count)
        {
            int skipValue = (page - 1) * count ;
            var users = await _context.Users
                .Include(user => user.Group)
                .Include(user => user.State)
                .Skip(skipValue)
                .Take(count)
                .ToListAsync();
            List<UserData> usersMapped = new List<UserData>();
            foreach(var item in users)
            {
                usersMapped.Add(Map(item));
            }
            var result = new PaginationList<UserData>(page, count, usersMapped);
            return result;
        }
        
        public async Task<UserData> GetUser(string login)
        {
            var result = new Result<UserData>();
            var user = await _context.Users
                .Where(user => user.Login == login)
                .Include(user=> user.Group)
                .Include(user=> user.State)
                .FirstAsync();

            return Map(user);
        }
        public async Task<bool> DeleteUser(string login)
        {
            var result = new Result<bool>();
            var user = _context.Users
                .Where(user => user.Login == login)
                .Include(user => user.State)
                .First();

            user.State.Status = Status.Blocked;
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> IsAdminExist()
        {
            var adminCount = await _context.UsersGroup.Where(group => group.Role == Role.Admin).CountAsync();
            if (adminCount == 0) return false;
            return true;
        }
        public async Task<bool> IsUserExist(string login)
        {
            var userCount = await _context.Users.Where(user => user.Login == login).CountAsync();
            if (userCount == 0) return false;
            return true;
        }
        private UserData Map(User item)
        {
            return new UserData()
            {
                Id = item.Id,
                DateOfCreation = DateTime.UtcNow,
                Group = item.Group,
                Login = item.Login,
                Password = item.Password,
                State = item.State,
            };
        }
    }
}
