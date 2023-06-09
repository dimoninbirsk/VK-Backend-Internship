﻿using VKBackendInternship.Domain.Enums;

namespace VKBackendInternship.DataAccessLayer.Model
{
    public class UserGroup
    {
        public Guid Id { get; set; }
        public Role Role { get; set; }
        public string Description { get; set; } = "";
    }
}
