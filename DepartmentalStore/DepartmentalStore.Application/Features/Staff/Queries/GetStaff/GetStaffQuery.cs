using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Staff.Queries.GetStaff
{
    public class GetStaffQuery : IRequest<GetStaffVM>
    {
        public int Id { get; set; }
        public bool IncludeAddress { get; set; }
    }
}
