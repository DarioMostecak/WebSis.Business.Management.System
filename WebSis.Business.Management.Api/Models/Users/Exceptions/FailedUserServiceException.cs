﻿// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using WebSis.Business.Management.Api.Models.ExceptionsModels;

namespace WebSis.Business.Management.Api.Models.Users.Exceptions
{
    public class FailedUserServiceException : ExceptionModel
    {
        public FailedUserServiceException(Exception innerException)
            : base(message: "Failed user service exception, contact support.", innerException)
        { }
    }
}