using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Staff.Commands.UpdateStaff
{
    public class UpdateStaffVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }

        public int GenderId { get; set; }
        public int RoleId { get; set; }
        public int AddressId { get; set; }
    }
}
