namespace ImproveAbilityInSqlAndC_.Domain.Entities
{
    public class EUserQuestion
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string UserQuestion { get; set; } = string.Empty;
        public DateTime SendDate { get; set; } = DateTime.UtcNow;
        public ICollection<EIAResponse> Responses { get; set; } = new List<EIAResponse>();
    }
}
