using DepartmentalStore.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Staff.Commands.DeleteStaff
{
    public class DeleteStaffCommandHandler : IRequestHandler<DeleteStaffCommand>
    {
        private readonly IStaffRepository _repository;

        public DeleteStaffCommandHandler(IStaffRepository repository)
        {
            this._repository = repository;
        }
        public async Task<Unit> Handle(DeleteStaffCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(await _repository.GetByIdAsync(request.Id));
            
            return Unit.Value;                
        }
    }
}
