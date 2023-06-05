// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Moq;
using WebSis.Business.Management.Api.Brokers.Loggers;
using WebSis.Business.Management.Api.Brokers.UserManagers;
using WebSis.Business.Management.Api.Services.Foundations.Users;

namespace WebSis.Business.Management.Api.Tests.Unit.Services.Foundations.Users
{
    public partial class UserServiceTests
    {
        private readonly Mock<IUserManagerBroker> userManagerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IUserService userService;

        public UserServiceTests()
        {
            this.userManagerMock = new Mock<IUserManagerBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.userService = new UserService(
                userMangerBroker: userManagerMock.Object,
                loggingBroker: loggingBrokerMock.Object);
        }
    }
}
