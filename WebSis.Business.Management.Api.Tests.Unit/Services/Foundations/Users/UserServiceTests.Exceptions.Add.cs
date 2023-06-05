// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Moq;
using System;
using System.Threading.Tasks;
using WebSis.Business.Management.Api.Models.Users;
using WebSis.Business.Management.Api.Models.Users.Exceptions;
using Xunit;

namespace WebSis.Business.Management.Api.Tests.Unit.Services.Foundations.Users
{
    public partial class UserServiceTests
    {
        [Theory]
        [MemberData(nameof(DependencyValidationExceptions))]
        public async Task ShouldThrowDependencyValidationExceptionOnAddIfInvalidColumnOrObjectNameExceptionOcccurresAndLogItAsync(
            Exception dependencyValidationException)
        {
            //given
            User someUser = CreateUser();
            string somePassword = GetRandomPassword();

            var expectedUserDependencyValidationException =
                new UserDependencyValidationException(dependencyValidationException);

            this.userManagerMock.Setup(manager =>
                manager.InsertUserAsync(It.IsAny<User>(), It.IsAny<string>()))
                        .ThrowsAsync(dependencyValidationException);

            //when
            ValueTask<User> addUserTask =
                this.userService.AddUserAsync(someUser, somePassword);

            //then
            await Assert.ThrowsAsync<UserDependencyValidationException>(() =>
                addUserTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedUserDependencyValidationException))),
                     Times.Once);

            this.userManagerMock.Verify(manager =>
                manager.InsertUserAsync(It.IsAny<User>(), It.IsAny<string>()),
                 Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.userManagerMock.VerifyNoOtherCalls();
        }
    }
}
