namespace ImproveAbilityInSqlAndC_.Domain.Entities
{
    public class EProducts
    {
        public int id { get; set; }
        public required string name { get; set; }
        public required string description { get; set; }
        public required string category { get; set; }
        public double price { get; set; }
        public DateTime createdAt { get; set; }
    }
}
