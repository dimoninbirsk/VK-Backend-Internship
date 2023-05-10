using VKBackendInternship.Domain.Enums;

namespace VKBackendInternship.Domain.DataTransferObjects
{
    public class UserRegistrationRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string RoleDescription { get; set; }
        public string StatusDescription { get; set; }
    }
}
