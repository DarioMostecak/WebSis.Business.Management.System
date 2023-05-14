// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Identity;
using WebSis.Business.Management.Api.Models.Users;

namespace WebSis.Business.Management.Api.Brokers.UserManagers
{
    public interface IUserManagerBroker
    {
        ValueTask<User> SelectUserByEmail(string email);
        ValueTask<IdentityResult> InsertUserAsync(User user, string password);
        ValueTask<User> SelectUserByIdAsync(Guid userId);
        ValueTask<IdentityResult> UpdateUserAsync(User user);
        ValueTask<IdentityResult> DeleteUserAsync(User user);
        ValueTask<bool> ConfirmUserByPasswordAsync(User user, string password);
    }
}
