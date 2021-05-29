using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductVM>
    {
        public UpdateProductVM UpdateProductVM { get; set; }
    }
}
