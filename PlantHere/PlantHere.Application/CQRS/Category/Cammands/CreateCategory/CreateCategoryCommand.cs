using PlantHere.Application.CQRS.Base;

namespace PlantHere.Application.CQRS.Category.Cammands.CreateCategory
{
    public class CreateCategoryCommand : CommandBase<CreateCategoryCommandResult>
    {

        public string? NameTr { get; set; }

        public string? NameEn { get; set; }

        public CreateCategoryCommand(string? nameTr, string? nameEn)
        {
            NameTr = nameTr;
            NameEn = nameEn;
        }
    }
}
