using System;
using Domain.Enums;

namespace Application.DTOs
{
    public class UserDto
    {
        public Ulid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public UserStatus Status { get; set; }
    }
}
