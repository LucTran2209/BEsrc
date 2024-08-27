using BE.Application.Services.Users.Commands.Requests;
using BE.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Services.Users.Mapping
{
    public static class ModelExtentions
    {
        public static User ToEntity(this InsertUserCommand command)
        {
            var user = new User();
            user.PhoneNumber = command.PhoneNumber;
            user.UserName = command.UserName;   
            user.Email = command.Email;     
            
            return user;
        }

    }
}
