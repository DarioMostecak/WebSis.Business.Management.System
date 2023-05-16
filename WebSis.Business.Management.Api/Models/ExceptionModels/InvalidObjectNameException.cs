// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

namespace WebSis.Business.Management.Api.Models.ExceptionModels
{
    public class InvalidObjectNameException : Exception
    {
        public InvalidObjectNameException(string message) : base(message) { }
    }
}
