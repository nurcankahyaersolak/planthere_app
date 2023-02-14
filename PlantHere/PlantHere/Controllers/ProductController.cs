using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantHere.Application.CQRS.Product.Commands.CreateProduct;
using PlantHere.Application.CQRS.Product.Commands.CreateProductsIndexES;
using PlantHere.Application.CQRS.Product.Commands.DeleteProduct;
using PlantHere.Application.CQRS.Product.Commands.UpdateProduct;
using PlantHere.Application.CQRS.Product.Queries.GetProductByUniqueId;
using PlantHere.Application.CQRS.Product.Queries.GetProductsByPage;
using PlantHere.Application.CQRS.Product.Queries.GetProductsCount;
using PlantHere.Application.CQRS.Product.Queries.GetProductsES;
using PlantHere.WebAPI.CustomResults;
using System.Net;

namespace PlantHere.WebAPI.Controllers
{
    [Route("products")]
    public class ProductController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get Product By Unique Id
        /// </summary>
        /// <param name="uniqueId"></param>
        [AllowAnonymous]
        [HttpGet("{uniqueId}")]
        public async Task<CustomResult<GetProductByUniqueIdQueryResult>> GetProductByUniqueId(string uniqueId)
        {
            return CustomResult<GetProductByUniqueIdQueryResult>.Success((int)HttpStatusCode.OK, await _mediator.Send(new GetProductByUniqueIdQuery(uniqueId)));
        }

        /// <summary>
        /// Get Products By Page
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        [AllowAnonymous]
        [HttpGet("{page}/{pageSize}")]
        public async Task<CustomResult<IEnumerable<GetProductsByPageQueryResult>>> GetProductsByPage(int page, int pageSize)
        {
            return CustomResult<IEnumerable<GetProductsByPageQueryResult>>.Success((int)HttpStatusCode.OK, await _mediator.Send(new GetProductsByPageQuery(page, pageSize)));
        }

        /// <summary>
        /// Get Products Count
        /// </summary>
        [AllowAnonymous]
        [HttpGet("count")]
        public async Task<CustomResult<GetProductsCountQueryResult>> GetProductsCount()
        {
            return CustomResult<GetProductsCountQueryResult>.Success((int)HttpStatusCode.OK, await _mediator.Send(new GetProductsCountQuery()));
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="command"></param>
        [Authorize(Roles = "superadmin,seller")]
        [HttpPut]
        public async Task<CustomResult<GetProductByUniqueIdQueryResult>> UpdateProduct(UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return CustomResult<GetProductByUniqueIdQueryResult>.Success((int)HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="command"></param>
        [Authorize(Roles = "superadmin,seller")]
        [HttpPost]
        public async Task<CustomResult<CreateProductCommandResult>> CreateProduct(CreateProductCommand command)
        {
            return CustomResult<CreateProductCommandResult>.Success((int)HttpStatusCode.OK, await _mediator.Send(command));
        }

        /// <summary>
        /// Get Products ES
        /// </summary>
        /// <param name="keyword"></param>
        [AllowAnonymous]
        [HttpGet("elastic-search/{keyword}")]
        public async Task<CustomResult<List<GetProductsESQueryResult>>> GetProductsES(string keyword)
        {
            var products = await _mediator.Send(new GetProductsESQuery(keyword));
            return CustomResult<List<GetProductsESQueryResult>>.Success((int)HttpStatusCode.OK, products);
        }

        /// <summary>
        /// Create Products Index ES
        /// </summary>
        [AllowAnonymous]
        [HttpGet("elastic-search-index")]
        public async Task<CustomResult<CreateProductsIndexESCommandResult>> CreateProductsIndexES()
        {
            return CustomResult<CreateProductsIndexESCommandResult>.Success((int)HttpStatusCode.OK, await _mediator.Send(new CreateProductsIndexESCommand()));
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id"></param>
        [Authorize(Roles = "superadmin")]
        [HttpDelete("{id}")]
        public async Task<CustomResult<DeleteProductCommand>> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return CustomResult<DeleteProductCommand>.Success((int)HttpStatusCode.NoContent);
        }
    }
}
