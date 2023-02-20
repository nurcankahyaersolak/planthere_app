namespace PlantHere.Application.Requests.Catogories
{
    public class CreateCategoryRequest
    {
        public string? NameTr { get; set; }

        public string? NameEn { get; set; }

        public CreateCategoryRequest(string? nameTr, string? nameEn)
        {
            NameTr = nameTr;
            NameEn = nameEn;
        }
    }
}
