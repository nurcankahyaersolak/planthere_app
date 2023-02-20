using PlantHere.Application.CQRS.Base;

namespace PlantHere.Application.CQRS.Category.Cammands.UpdateCategory
{
    public class UpdateCategoryCommand : CommandBase<UpdateCategoryCommandResult>
    {
        public int Id { get; set; }

        public string NameTr { get; set; }

        public string NameEn { get; set; }

        public UpdateCategoryCommand(int id, string nameTr, string nameEn)
        {
            Id = id;
            NameTr = nameTr;
            NameEn = nameEn;
        }
    }
}
