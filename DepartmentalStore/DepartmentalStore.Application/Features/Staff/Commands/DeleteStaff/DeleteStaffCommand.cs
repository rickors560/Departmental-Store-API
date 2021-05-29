using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Staff.Commands.DeleteStaff
{
    public class DeleteStaffCommand : IRequest
    {
        public int Id { get; set; }
    }
}
