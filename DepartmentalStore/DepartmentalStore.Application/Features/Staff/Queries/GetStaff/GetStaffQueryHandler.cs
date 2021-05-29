using AutoMapper;
using DepartmentalStore.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Staff.Queries.GetStaff
{
    public class GetStaffQueryHandler : IRequestHandler<GetStaffQuery, GetStaffVM>
    {
        private readonly IStaffRepository _repository;
        private readonly IMapper _mapper;

        public GetStaffQueryHandler(IStaffRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<GetStaffVM> Handle(GetStaffQuery request, CancellationToken cancellationToken)
        {
            var staff = await _repository.GetByIdWithAddressAsync(request.Id, request.IncludeAddress);
            return _mapper.Map<GetStaffVM>(staff);
        }
    }
}
