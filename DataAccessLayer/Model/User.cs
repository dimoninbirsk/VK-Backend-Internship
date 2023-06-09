﻿namespace VKBackendInternship.DataAccessLayer.Model
{
    public class User
    {
        public Guid Id { get; set; }
        
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateOfCreation { get; set; }
        public UserGroup Group { get; set; }
        public Guid GroupId { get; set; }
        public UserState State { get; set; }
        public Guid StateId { get; set; }
        
    }
}
