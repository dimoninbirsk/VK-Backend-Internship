namespace VKBackendInternship.DataAccessLayer.Model
{
    public class User
    {
        public int Id { get; set; }
        
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int GroupId { get; set; }
        public UserGroup Group { get; set; }
        public int StateId { get; set; }
        public UserState State { get; set; }
        
    }
}
