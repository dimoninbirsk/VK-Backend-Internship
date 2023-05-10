using VKBackendInternship.Domain.Enums;

namespace VKBackendInternship.DataAccessLayer.Model
{
    public class UserState
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; } = "";
    }
}
