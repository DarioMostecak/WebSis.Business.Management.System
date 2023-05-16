// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebSis.Business.Management.Api.Models.ExceptionModels;

namespace WebSis.Business.Management.Api.Utilities
{
    //describe in documentation
    public class ExceptionEf
    {

        public static ExceptionEf exceptionEf = new ExceptionEf();
        public static ExceptionEf Instance => exceptionEf;

        public static void ThrowMeaningfulException(DbUpdateException dbUpdateException)
        {
            Instance.ThrowException(dbUpdateException);
        }

        public void ThrowException(DbUpdateException dbUpdateException)
        {
            ValidateInnerException(dbUpdateException);

            SqlException dbException =
                GetSqlException(dbUpdateException.InnerException);

            int sqlErrorCode = GetSqlErrorCode(dbException);
            ConvertAndThrowMeaningfulException(sqlErrorCode, dbException.Message);

            throw dbUpdateException;
        }

        private void ValidateInnerException(DbUpdateException dbUpdateException)
        {
            if (dbUpdateException.InnerException == null)
                throw dbUpdateException;
        }

        private SqlException GetSqlException(Exception exception)
        {
            var sqlException =
                exception as SqlException;

            if (sqlException == null)
                throw exception;

            return sqlException;
        }

        private void ConvertAndThrowMeaningfulException(int code, string message)
        {
            switch (code)
            {
                case 207:
                    throw new InvalidColumnNameException(message);
                case 208:
                    throw new InvalidObjectNameException(message);
                case 547:
                    throw new ForeignKeyConstraintConflictException(message);
                case 2601:
                    throw new DuplicateKeyWithUniqueIndexException(message);
                case 2627:
                    throw new DuplicateKeyException(message);
            }
        }

        private int GetSqlErrorCode(SqlException exception) => exception.Number;
    }
}
