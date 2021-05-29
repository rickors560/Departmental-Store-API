using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Staff.Commands.UpdateStaff
{
    public class UpdateStaffCommand : IRequest<UpdateStaffVM>
    {
        public UpdateStaffVM UpdateStaffVM { get; set; }
    }
}