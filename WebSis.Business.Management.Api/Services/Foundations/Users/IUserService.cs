// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using WebSis.Business.Management.Api.Models.Users;

namespace WebSis.Business.Management.Api.Services.Foundations.Users
{
    public interface IUserService
    {
        ValueTask<User> AddUser(User user, string password);
        ValueTask<User> ModifyUserUser(User user);
        ValueTask<User> RemoveUserById(Guid id);
        ValueTask<User> RetrieveUserById(Guid id);
    }
}
