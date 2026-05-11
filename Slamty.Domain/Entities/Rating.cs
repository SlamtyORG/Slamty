namespace Slamty.Domain.Entities
{
    public class Rating : BaseEntity
    {
        public int Score { get; set; }
        public string? Comment { get; set; }
    }
}
