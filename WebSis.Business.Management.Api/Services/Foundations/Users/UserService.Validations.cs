// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System.Text.RegularExpressions;
using WebSis.Business.Management.Api.Models.Users;
using WebSis.Business.Management.Api.Models.Users.Exceptions;

namespace WebSis.Business.Management.Api.Services.Foundations.Users
{
    public partial class UserService
    {
        private static void ValidateUserAndPasswordOnCreate(User user, string password)
        {
            ValidateUserIsNull(user);
            ValidatePasswordIsNull(password);

            Validate(
                (Rule: IsInvalidX(user.Id), Parameter: nameof(User.Id)),
                (Rule: IsInvalidX(user.UserName), Parameter: nameof(User.UserName)),
                (Rule: IsInvalidX(user.Email), Parameter: nameof(User.Email))
                );
        }

        private static dynamic IsInvalidX(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id isn't valid."
        };

        private static dynamic IsInvalidX(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Field is required"
        };

        private static dynamic IsInvalidX(DateTime date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private static dynamic IsInvalidEmail(string email) => new
        {
            Condition = !Regex.IsMatch(
                input: email,
                pattern: @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                       + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(["
                       + @"a-z0-9!#$%&'*+/=?^_`{|}~-]+(\.[-a-z0-9!#$%&'"
                       + @"+/=?^_`{|}~]*)*@([a-z0-9-]+(\.[-a-z0-9]+)*(\.[a-z]{2,})|"
                       + @"(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}))(\:\d{2,5})?$",

                options: RegexOptions.IgnoreCase),

            Message = "Date is required"
        };

        private static dynamic IsInvalidPassword(string password) => new
        {
            Condition = !Regex.IsMatch(
                input: password,
                pattern: @"^(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,25}$"),

            Message = "Password must have " +
            "one uppercase letter, one number, one special" +
            "character and it must be between 8 and 25 characthers."
        };

        private static void ValidateUserIsNull(User user)
        {
            if (user is null)
                throw new NullUserException();
        }

        private static void ValidatePasswordIsNull(string password)
        {
            if (password is null)
                throw new NullUserPasswordException();
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidUserException = new InvalidUserException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidUserException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidUserException.ThrowIfContainsErrors();
        }
    }
}
