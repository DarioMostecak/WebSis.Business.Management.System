// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Identity;
using WebSis.Business.Management.Api.Brokers.Loggers;
using WebSis.Business.Management.Api.Brokers.UserManagers;
using WebSis.Business.Management.Api.Models.Users;

namespace WebSis.Business.Management.Api.Services.Foundations.Users
{
    public partial class UserService : IUserService
    {
        private readonly ILoggingBroker loggingBroker;
        private readonly IUserManagerBroker userManagerBroker;

        public UserService(
            ILoggingBroker loggingBroker,
            IUserManagerBroker userMangerBroker)
        {
            this.loggingBroker = loggingBroker;
            this.userManagerBroker = userMangerBroker;
        }

        public ValueTask<User> AddUserAsync(User user, string password) =>
        TryCatch(async () =>
        {
            //Validate user
            //Validate Password

            IdentityResult identityResult =
                 await this.userManagerBroker.InsertUserAsync(user, password);

            //Validate identityResult
            return user;
        });


        public ValueTask<User> ModifyUserUser(User user)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> RemoveUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> RetrieveUserById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
