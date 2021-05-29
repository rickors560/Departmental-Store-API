using AutoMapper;
using DepartmentalStore.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Product.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<GetProductsVM>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IProductRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<List<GetProductsVM>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetStaffsWithInventoryAndPrice(request.IncludeInventory, request.IncludePrice);
            return _mapper.Map<List<GetProductsVM>>(results);
        }
    }
}
