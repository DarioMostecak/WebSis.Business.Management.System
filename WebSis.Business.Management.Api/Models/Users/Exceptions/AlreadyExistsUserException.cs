// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using WebSis.Business.Management.Api.Models.ExceptionsModels;

namespace WebSis.Business.Management.Api.Models.Users.Exceptions
{
    public class AlreadyExistsUserException : ExceptionModel
    {
        public AlreadyExistsUserException(Exception innerException)
            : base(message: "User already exist.", innerException)
        { }

        public AlreadyExistsUserException()
            : base(message: "User email alredy exist.") { }
    }
}
