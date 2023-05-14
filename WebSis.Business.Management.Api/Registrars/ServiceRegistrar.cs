// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using WebSis.Business.Management.Api.Brokers.Storages;
using WebSis.Business.Management.Api.Brokers.UserManagers;
using WebSis.Business.Management.Api.Options;

namespace WebSis.Business.Management.Api.Registrars
{
    public class ServiceRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            #region Context
            builder.Services.AddDbContext<StorageBroker>();
            #endregion

            #region JWT settings
            builder.Services.AddTransient<JwtSettings>();
            #endregion

            #region Brokers
            builder.Services.AddTransient<IUserManagerBroker, UserManagerBroker>();
            #endregion
        }
    }
}
