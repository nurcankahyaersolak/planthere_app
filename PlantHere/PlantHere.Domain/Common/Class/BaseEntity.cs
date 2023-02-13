namespace PlantHere.Domain.Common.Class
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            UniqueId = $"{Guid.NewGuid()}_{DateTime.Now.ToString("yyyyMMddHHmmssff")}";
        }

        public int Id { get; set; }

        public string UniqueId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

    }
}
