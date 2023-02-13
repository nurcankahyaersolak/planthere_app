using PlantHere.Application.CQRS.Base;

namespace PlantHere.Application.CQRS.Category.Cammands.DeleteCategory
{
    public class DeleteCategoryCommand : CommandBase<DeleteCategoryCommandResult>
    {
        public int Id { get; set; }
    }
}
