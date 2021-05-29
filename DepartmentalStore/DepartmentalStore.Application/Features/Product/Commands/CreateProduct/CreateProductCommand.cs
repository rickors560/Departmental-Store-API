using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductVM>
    {
        public CreateProductVM CreateProductVM { get; set; }
    }
}
