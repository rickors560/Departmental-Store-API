using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Staff.Commands.CreateStaff
{
    public class CreateStaffCommand : IRequest<CreateStaffVM>
    {
        public CreateStaffVM CreateStaffVM { get; set; }
    }
}
