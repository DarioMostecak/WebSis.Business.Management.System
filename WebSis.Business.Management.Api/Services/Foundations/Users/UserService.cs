using WebSis.Business.Management.Api.Brokers.Loggers;

namespace WebSis.Business.Management.Api.Services.Foundations.Users
{
    public partial class UserService : IUserService
    {
        private readonly ILoggingBroker loggingBroker;
        private readonly IUserService userService;

        public UserService(
            ILoggingBroker loggingBroker,
            IUserService userService)
        {
            this.loggingBroker = loggingBroker;
            this.userService = userService;
        }
    }
}
