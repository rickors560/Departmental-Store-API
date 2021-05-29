using DepartmentalStore.Application.Features.Product.Commands.CreateProduct;
using DepartmentalStore.Application.Features.Product.Commands.DeleteProduct;
using DepartmentalStore.Application.Features.Product.Commands.UpdateProduct;
using DepartmentalStore.Application.Features.Product.Queries.GetProduct;
using DepartmentalStore.Application.Features.Product.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly LinkGenerator _linkGenerator;

        public ProductsController(IMediator mediator, LinkGenerator linkGenerator)
        {
            this._mediator = mediator;
            this._linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetProductsVM>>> GetAllProducts(bool includeInventory = false, bool includePrice = false)
        {
            try
            {
                var results = await _mediator.Send(new GetProductsQuery
                {
                    IncludeInventory = includeInventory,
                    IncludePrice = includePrice
                });

                return results;
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetProductVM>> GetProduct(int id, bool includeInventory = false, bool includePrices = false)
        {
            try
            {
                var product = await _mediator.Send(new GetProductQuery { 
                    Id = id,
                    IncludePrices = includePrices,
                    IncludeInventory = includeInventory
                });

                if (product == null)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound, "Product ID not found.");
                }

                return product;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CreateProductVM>> PostProduct(CreateProductVM createProductVM)
        {
            try
            {
                var product = await _mediator.Send(new CreateProductCommand { CreateProductVM = createProductVM });

                var location = _linkGenerator.GetPathByAction("GetProduct", "Products", new { id = product.Id });
                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("Could not use current ID");
                }

                return this.Created(location, product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UpdateProductVM>> PutProduct(int id, UpdateProductVM updateProductVM)
        {
            try
            {
                if (updateProductVM.Id == 0)
                {
                    updateProductVM.Id = id;      //In Case of Null
                }

                if (id != updateProductVM.Id)
                {
                    return this.BadRequest("Id must be same.");
                }

                var product = await _mediator.Send(new UpdateProductCommand { UpdateProductVM = updateProductVM });

                var location = _linkGenerator.GetPathByAction("GetProduct", "Products", new { id = product.Id });
                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("Could not use current ID");
                }

                return this.Accepted(location, product);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _mediator.Send(new DeleteProductCommand { Id = id });
                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}