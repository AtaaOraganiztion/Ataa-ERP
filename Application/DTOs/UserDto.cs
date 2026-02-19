using System;
using Domain.Enums;

namespace Application.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public UserStatus Status { get; set; }
    }

    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NID { get; set; }
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public string Password { get; set; }
    }

    public class UpdateUserDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? Age { get; set; }
    }
}
