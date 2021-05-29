using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Domain.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<ProductSupplier> ProductSuppliers { get; set; }
    }
}