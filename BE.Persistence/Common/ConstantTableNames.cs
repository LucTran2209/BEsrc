using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Common
{
    public static class ConstantTableNames
    {
        internal const string Users = nameof(Users);
        internal const string Roles = nameof(Roles);
        internal const string UserRoles = nameof(UserRoles);
        internal const string RefreshTokens = nameof(RefreshTokens);

        //Room
        internal const string Rooms = nameof(Rooms);

        // Table Business
        internal const string Products = nameof(Products);
    }
}
