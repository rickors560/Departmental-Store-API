using AutoMapper;
using DepartmentalStore.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Staff.Queries.GetStaffs
{
    public class GetStaffsQueryHandler : IRequestHandler<GetStaffsQuery, List<GetStaffsVM>>
    {
        private readonly IStaffRepository _repository;
        private readonly IMapper _mapper;

        public GetStaffsQueryHandler(IStaffRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        async Task<List<GetStaffsVM>> IRequestHandler<GetStaffsQuery, List<GetStaffsVM>>.Handle(GetStaffsQuery request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetStaffsWithAddress(request.IncludeAddress);
            return _mapper.Map<List<GetStaffsVM>>(results);
        }
    }
}
