using Microsoft.AspNetCore.Identity;

namespace WebSis.Business.Management.Api.Models.Users
{
    public class User : IdentityUser<Guid>
    {
        public bool IsActive { get; set; }
        public DateTime LastLogInDate { get; set; }
    }
}
