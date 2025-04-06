namespace ImproveAbilityInSqlAndC_.Application.DTOs
{
    public class DtoProducts
    {
        public int id { get; set; }
        public required string ProductName { get; set; }
        public required string details { get; set; }
        public required string productCategory { get; set; }
        public double price { get; set; }
        public DateTime createdAt { get; set; }
    }
}
