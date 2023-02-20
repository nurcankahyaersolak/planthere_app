
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantHere.Application.CQRS.Category.Cammands.CreateCategory;
using PlantHere.Application.CQRS.Category.Cammands.DeleteCategory;
using PlantHere.Application.CQRS.Category.Cammands.UpdateCategory;
using PlantHere.Application.CQRS.Category.Queries.GetCategories;
using PlantHere.Application.Requests.Catogories;
using PlantHere.WebAPI.CustomResults;
using System.Net;

namespace PlantHere.WebAPI.Controllers
{
    [Route("categories")]
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
        [AllowAnonymous]
        [HttpGet]
        public async Task<CustomResult<IEnumerable<GetCategoriesQueryResult>>> GetAll()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());
            return CustomResult<IEnumerable<GetCategoriesQueryResult>>.Success((int)HttpStatusCode.OK, categories);
        }

        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="createCategoryRequest"></param>
        [Authorize(Roles = "superadmin")]
        [HttpPost]
        public async Task<CustomResult<CreateCategoryCommandResult>> CreateCategory(CreateCategoryRequest createCategoryRequest)
        {
            var command = new CreateCategoryCommand(createCategoryRequest.NameTr, createCategoryRequest.NameEn);

            return CustomResult<CreateCategoryCommandResult>.Success((int)HttpStatusCode.Created, (await _mediator.Send(command)));
        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="updateCategoryRequest"></param>
        [Authorize(Roles = "superadmin")]
        [HttpPut]
        public async Task<CustomResult<UpdateCategoryCommandResult>> UpdateCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            var command = new UpdateCategoryCommand(updateCategoryRequest.Id, updateCategoryRequest.NameTr, updateCategoryRequest.NameEn);

            return CustomResult<UpdateCategoryCommandResult>.Success((int)HttpStatusCode.OK, await _mediator.Send(command));
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="deleteCategoryRequest"></param>
        /// <returns></returns>
        [Authorize(Roles = "superadmin")]
        [HttpDelete]
        public async Task<CustomResult<DeleteCategoryCommandResult>> DeleteCategory(DeleteCategoryRequest deleteCategoryRequest)
        {
            var command = new DeleteCategoryCommand(deleteCategoryRequest.Id);

            return CustomResult<DeleteCategoryCommandResult>.Success((int)HttpStatusCode.OK, await _mediator.Send(command));
        }

    }
}
