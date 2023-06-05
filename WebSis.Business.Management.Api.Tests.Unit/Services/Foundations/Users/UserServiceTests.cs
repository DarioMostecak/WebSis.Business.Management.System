﻿// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Moq;
using System;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using WebSis.Business.Management.Api.Brokers.Loggers;
using WebSis.Business.Management.Api.Brokers.UserManagers;
using WebSis.Business.Management.Api.Models.ExceptionModels;
using WebSis.Business.Management.Api.Models.Users;
using WebSis.Business.Management.Api.Services.Foundations.Users;
using Xunit;

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

        private static string GetRandomPassword() => new MnemonicString(1, 8, 20).GetValue();

        private static Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
        {
            return actualException =>
                actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message;
        }

        public static TheoryData DependencyValidationExceptions()
        {
            string errorMessage = "Error occurred";

            var invalidColumnNameException =
                new InvalidColumnNameException(errorMessage);

            var invalidObjectNameException =
                new InvalidObjectNameException(errorMessage);

            return new TheoryData<Exception>
            {
                invalidColumnNameException,
                invalidObjectNameException
            };
        }

        private static User CreateUser()
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Email = "travis@mail.com",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow.AddDays(10),
            };

            return newUser;
        }
    }
}
