using VKBackendInternship.DataAccessLayer.Data;

namespace VKBackendInternship.DataAccessLayer.Repository
{
    public class UserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context) 
        {
            this._context = context;
        }
        public async void CreateUser()
        {
            // Создание пользователя
        }
    }
}
