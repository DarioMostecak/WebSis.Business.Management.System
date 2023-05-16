﻿// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using WebSis.Business.Management.Api.Models.ExceptionsModels;

namespace WebSis.Business.Management.Api.Models.Users.Exceptions
{
    public class NotFoundUserException : ExceptionModel
    {
        public NotFoundUserException(Guid id) :
            base(message: $"Couldn't find user with email: {id}.")
        { }

        public NotFoundUserException(string email)
            : base(message: $"Couldn't find user with email: {email}.")
        { }
    }
}
