
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantHere.Application.CQRS.Category.Cammands.CreateCategory;
using PlantHere.Application.CQRS.Category.Cammands.DeleteCategory;
using PlantHere.Application.CQRS.Category.Cammands.UpdateCategory;
using PlantHere.Application.CQRS.Category.Queries.GetCategories;
using PlantHere.WebAPI.CustomResults;
using System.Net;

namespace PlantHere.WebAPI.Controllers
{
    public class CategoryController : CustomBaseController
    {

        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get Category
        /// </summary>
        [Authorize]
        [HttpGet]
        public async Task<CustomResult<IEnumerable<GetCategoriesQueryResult>>> GetAll()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());
            return CustomResult<IEnumerable<GetCategoriesQueryResult>>.Success((int)HttpStatusCode.OK, categories);
        }

        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="createCategoryCommand"></param>
        [Authorize(Roles = "superadmin")]
        [HttpPost]
        public async Task<CustomResult<CreateCategoryCommandResult>> CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            return CustomResult<CreateCategoryCommandResult>.Success((int)HttpStatusCode.Created, (await _mediator.Send(createCategoryCommand)));
        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="updateCategoryCommand"></param>
        [Authorize(Roles = "superadmin")]
        [HttpPut]
        public async Task<CustomResult<UpdateCategoryCommandResult>> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
        {
            return CustomResult<UpdateCategoryCommandResult>.Success((int)HttpStatusCode.OK, await _mediator.Send(updateCategoryCommand));
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="deleteCategoryCommand"></param>
        /// <returns></returns>
        [Authorize(Roles = "superadmin")]
        [HttpDelete]
        public async Task<CustomResult<DeleteCategoryCommandResult>> DeleteCategory(DeleteCategoryCommand deleteCategoryCommand)
        {
            return CustomResult<DeleteCategoryCommandResult>.Success((int)HttpStatusCode.OK, await _mediator.Send(deleteCategoryCommand));
        }

    }
}
