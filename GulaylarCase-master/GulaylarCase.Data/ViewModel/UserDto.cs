﻿using System.Collections.Generic;

namespace GulaylarCase.Data.ViewModel
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public string Token { get; set; }
        public List<SubscribeDto> Subscribe { get; set; }
    }
}
