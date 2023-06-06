// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebSis.Business.Management.Api.Models.ExceptionModels;
using WebSis.Business.Management.Api.Models.Users;
using WebSis.Business.Management.Api.Models.Users.Exceptions;

namespace WebSis.Business.Management.Api.Services.Foundations.Users
{
    public partial class UserService
    {
        private delegate ValueTask<User> ReturningUserFunctions();
        private delegate IQueryable<User> ReturningUsersFunctions();

        private async ValueTask<User> TryCatch(
            ReturningUserFunctions returningUserFunctions)
        {
            try
            {
                return await returningUserFunctions();
            }
            catch (NullUserException nullUserException)
            {
                throw CreateAndLogValidationException(nullUserException);
            }
            catch (NullUserPasswordException nullUserPasswordException)
            {
                throw CreateAndLogValidationException(nullUserPasswordException);
            }
            catch (InvalidUserException invalidUserException)
            {
                throw CreateAndLogValidationException(invalidUserException);
            }
            catch (AlreadyExistsUserException alreadyExsistUserException)
            {
                throw CreateAndLogValidationException(alreadyExsistUserException);
            }
            catch (NotFoundUserException notFoundUserException)
            {
                throw CreateAndLogValidationException(notFoundUserException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alredyExistsUserException =
                    new AlreadyExistsUserException(duplicateKeyException);

                throw CreateAndLogDependencyValidationException(alredyExistsUserException);
            }
            catch (InvalidColumnNameException invalidColumnNameException)
            {
                throw CreateAndLogDependencyValidationException(invalidColumnNameException);
            }
            catch (InvalidObjectNameException invalidObjectNameException)
            {
                throw CreateAndLogDependencyValidationException(invalidObjectNameException);
            }
            catch (SqlException sqlException)
            {
                var failedUserStorageException =
                    new FailedUserStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedUserStorageException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedUserException =
                    new LockedUserException(dbUpdateConcurrencyException);

                throw CreateAndLogDependencyException(lockedUserException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                var failedUserStorageException =
                    new FailedUserStorageException(dbUpdateException);

                throw CreateAndLogDependencyException(failedUserStorageException);
            }
            catch (Exception exception)
            {
                var failedUserServiceException =
                    new FailedUserServiceException(exception);

                throw CreateAndLogServiceException(failedUserServiceException);
            }
        }

        private UserValidationException CreateAndLogValidationException(Exception exception)
        {
            var userValidationException =
                new UserValidationException(exception, exception.Data);

            this.loggingBroker.LogError(userValidationException);

            return userValidationException;
        }

        private UserDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var userDependencyException =
                new UserDependencyException(exception);

            this.loggingBroker.LogError(userDependencyException);

            return userDependencyException;
        }

        private UserDependencyException CreateAndLogCriticalDependencyException(Exception exception)
        {
            var userDependencyException =
                new UserDependencyException(exception);

            this.loggingBroker.LogCritical(userDependencyException);

            return userDependencyException;
        }

        private UserServiceException CreateAndLogServiceException(Exception exception)
        {
            var userServiceException =
                new UserServiceException(exception);

            this.loggingBroker.LogError(userServiceException);

            return userServiceException;
        }

        private UserDependencyValidationException CreateAndLogDependencyValidationException(Exception exception)
        {
            var userDependencyValidationException =
                new UserDependencyValidationException(exception);

            this.loggingBroker.LogError(userDependencyValidationException);

            return userDependencyValidationException;
        }
    }
}
