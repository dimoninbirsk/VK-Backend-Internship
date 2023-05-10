using VKBackendInternship.DataAccessLayer.Model;

namespace VKBackendInternship.Domain.DataTransferObjects
{
    public class UserData
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateOfCreation { get; set; }
        public UserGroup Group { get; set; }
        public UserState State { get; set; }
    }
}
