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

namespace DepartmentalStore.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductVM>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<UpdateProductVM> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<entities::Product>(request.UpdateProductVM);
            var updatedProduct = (await _repository.UpdateAsync(product));
            return _mapper.Map<entities::Product, UpdateProductVM>(updatedProduct);
        }
    }
}
