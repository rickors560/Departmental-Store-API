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

namespace DepartmentalStore.Application.Features.Staff.Commands.UpdateStaff
{
    public class UpdateStaffCommandHandler : IRequestHandler<UpdateStaffCommand, UpdateStaffVM>
    {
        private readonly IStaffRepository _repository;
        private readonly IMapper _mapper;

        public UpdateStaffCommandHandler(IStaffRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<UpdateStaffVM> Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
        {
            var staff = _mapper.Map<entities::Staff>(request.UpdateStaffVM);
            var updatedStaff = (await _repository.UpdateAsync(staff));
            return _mapper.Map<entities::Staff, UpdateStaffVM>(updatedStaff);
        }
    }
}
