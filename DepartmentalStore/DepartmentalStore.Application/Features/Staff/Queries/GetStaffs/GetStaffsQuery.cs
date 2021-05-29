using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Staff.Queries.GetStaffs
{
    public class GetStaffsQuery : IRequest<List<GetStaffsVM>>
    {
        public bool IncludeAddress { get; set; }
    }
}