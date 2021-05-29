using AutoMapper;
using DepartmentalStore.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Product.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductVM>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IProductRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<GetProductVM> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetStaffWithInventoryAndPrice(request.Id, request.IncludeInventory, request.IncludePrices);
            return _mapper.Map<GetProductVM>(result);
        }
    }
}
