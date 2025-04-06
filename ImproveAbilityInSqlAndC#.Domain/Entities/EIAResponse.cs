namespace ImproveAbilityInSqlAndC_.Domain.Entities
{
    public class EIAResponse
    {
        public int Id { get; set; }
        public int UserMessageId { get; set; }
        public EUserQuestion UserMessage { get; set; } = null!;
        public string Response { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
