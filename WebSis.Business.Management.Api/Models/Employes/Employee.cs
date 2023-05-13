using WebSis.Business.Management.Api.Models.User;
using WebSis.Business.Managmant.Api.Models.Warehouses;

namespace WebSis.Business.Managmant.Api.Models.Employes
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public Guid WarehouseID { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public Warehouse Warehouse { get; set; }
        public string IdentityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; } //Nullabe
        public string Email { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
