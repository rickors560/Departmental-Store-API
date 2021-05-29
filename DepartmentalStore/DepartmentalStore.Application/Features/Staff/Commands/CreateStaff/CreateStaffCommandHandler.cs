using AutoMapper;
using DepartmentalStore.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using entities = DepartmentalStore.Domain.Entities;

namespace DepartmentalStore.Application.Features.Staff.Commands.CreateStaff
{
    public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, CreateStaffVM>
    {
        private readonly IStaffRepository _repository;
        private readonly IMapper _mapper;

        public CreateStaffCommandHandler(IStaffRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<CreateStaffVM> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            var newStaff = await _repository.AddAsync(_mapper.Map<entities::Staff>(request.CreateStaffVM));
            return _mapper.Map<entities::Staff, CreateStaffVM>(newStaff);
        }
    }
}
