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

namespace DepartmentalStore.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductVM>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<CreateProductVM> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = await _repository.AddAsync(_mapper.Map<entities::Product>(request.CreateProductVM));
            return _mapper.Map<entities::Product, CreateProductVM>(newProduct);
        }
    }
}
