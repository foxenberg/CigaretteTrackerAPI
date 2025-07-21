namespace CigaretteTrackerAPI.Models
{
    public class CigaretteLog
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Brand { get; set; }
        public string Location { get; set; }
        public string Mood { get; set; }
    }
}
