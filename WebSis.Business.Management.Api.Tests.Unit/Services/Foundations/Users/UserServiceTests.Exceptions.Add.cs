// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using WebSis.Business.Management.Api.Models.ExceptionModels;
using WebSis.Business.Management.Api.Models.Users;
using WebSis.Business.Management.Api.Models.Users.Exceptions;
using Xunit;

namespace WebSis.Business.Management.Api.Tests.Unit.Services.Foundations.Users
{
    public partial class UserServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAddIfDuplicateKeyExceptionOccuresAndLogItAsync()
        {
            //given
            User someUser = CreateUser();
            string somePassword = GetRandomPassword();
            string errorMessage = "Error occured.";

            var duplicateKeyException =
                new DuplicateKeyException(errorMessage);

            var alreadyExistsUserException =
                new AlreadyExistsUserException(duplicateKeyException);

            var expectedUserDependencyValidationException =
                new UserDependencyValidationException(alreadyExistsUserException);

            this.userManagerMock.Setup(manager =>
                manager.InsertUserAsync(It.IsAny<User>(), It.IsAny<string>()))
                        .ThrowsAsync(duplicateKeyException);

            //when
            ValueTask<User> addUserAsyncTask =
                this.userService.AddUserAsync(someUser, somePassword);

            //then
            await Assert.ThrowsAsync<UserDependencyValidationException>(() =>
                addUserAsyncTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedUserDependencyValidationException))),
                 Times.Once);

            this.userManagerMock.Verify(manager =>
                manager.InsertUserAsync(It.IsAny<User>(), It.IsAny<string>()),
                 Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.userManagerMock.VerifyNoOtherCalls();
        }

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

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAddIfSqlExceptionOccurresAndLogItAsync()
        {
            //given
            User someUser = CreateUser();
            string somePassword = GetRandomPassword();
            SqlException sqlException = GetSqlException();

            var failedUserStorageException =
                new FailedUserStorageException(sqlException);

            var expectedUserDependencyException =
                new UserDependencyException(failedUserStorageException);

            this.userManagerMock.Setup(manager =>
                manager.InsertUserAsync(It.IsAny<User>(), It.IsAny<string>()))
                        .ThrowsAsync(sqlException);

            //when
            ValueTask<User> addUserTask =
                this.userService.AddUserAsync(someUser, somePassword);

            //then
            await Assert.ThrowsAsync<UserDependencyException>(() =>
                addUserTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(
                    expectedUserDependencyException))),
                     Times.Once);

            this.userManagerMock.Verify(manager =>
                manager.InsertUserAsync(It.IsAny<User>(), It.IsAny<string>()),
                 Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.userManagerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAddIfDbUpdateConcurrencyExceptionOccurresAndLogItAsync()
        {
            //given
            User someUser = CreateUser();
            string somePassword = GetRandomPassword();

            DbUpdateConcurrencyException dbUpdateConcurrencyException =
                GetDbUpdateConcurrencyException();

            var lockedUserException =
                new LockedUserException(dbUpdateConcurrencyException);

            var expectedUserDependencyException =
                new UserDependencyException(lockedUserException);

            this.userManagerMock.Setup(manager =>
                manager.InsertUserAsync(It.IsAny<User>(), It.IsAny<string>()))
                        .ThrowsAsync(dbUpdateConcurrencyException);

            //when
            ValueTask<User> addUserTask =
                this.userService.AddUserAsync(someUser, somePassword);

            //then
            await Assert.ThrowsAsync<UserDependencyException>(() =>
                addUserTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedUserDependencyException))),
                     Times.Once);

            this.userManagerMock.Verify(manager =>
                manager.InsertUserAsync(It.IsAny<User>(), It.IsAny<string>()),
                 Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.userManagerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAddIfDbUpdateExceptionOccurresAndLogItAsync()
        {
            //given
            User someUser = CreateUser();
            string somePassword = GetRandomPassword();
            DbUpdateException dbUpdateException = GetDbUpdateException();

            var failedUserStorageException =
                new FailedUserStorageException(dbUpdateException);

            var expectedUserDependencyException =
                new UserDependencyException(failedUserStorageException);

            this.userManagerMock.Setup(manager =>
                manager.InsertUserAsync(It.IsAny<User>(), It.IsAny<string>()))
                        .ThrowsAsync(dbUpdateException);

            //when
            ValueTask<User> addUserTask =
                this.userService.AddUserAsync(someUser, somePassword);

            //then
            await Assert.ThrowsAsync<UserDependencyException>(() =>
                addUserTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedUserDependencyException))),
                     Times.Once);

            this.userManagerMock.Verify(manager =>
                manager.InsertUserAsync(It.IsAny<User>(), It.IsAny<string>()),
                 Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.userManagerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnaddIfExceptionOccuresAndLogItAsync()
        {
            //given
            User someUser = CreateUser();
            string somePassword = GetRandomPassword();
            var exception = new Exception();

            var failedUserServiceException =
                new FailedUserServiceException(exception);

            var expectedUserServiceException =
                new UserServiceException(failedUserServiceException);

            this.userManagerMock.Setup(manager =>
               manager.InsertUserAsync(It.IsAny<User>(), It.IsAny<string>()))
                       .ThrowsAsync(exception);

            //when
            ValueTask<User> addUserTask =
                this.userService.AddUserAsync(someUser, somePassword);

            //then
            await Assert.ThrowsAsync<UserServiceException>(() =>
                addUserTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedUserServiceException))),
                     Times.Once);

            this.userManagerMock.Verify(manager =>
                manager.InsertUserAsync(It.IsAny<User>(), It.IsAny<string>()),
                 Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.userManagerMock.VerifyNoOtherCalls();
        }
    }
}
