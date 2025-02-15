﻿using MediatR;

namespace BE.Application.Services.Users.Commands.Requests
{
    public class InsertUserCommand : IRequest<int>
    {
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public bool Gender {  get; set; }
        public int RoleId {  get; set; }
    }
}
