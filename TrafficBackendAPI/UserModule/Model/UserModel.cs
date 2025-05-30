﻿namespace TrafficBackendAPI.UserModule.Model
{
    internal class UserModel : BaseModel
    {
        public required string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public required string LastName { get; set; }

        public bool IsAnonymous { get; set; }
    }
}
