namespace SmartInventoryAPI.Models
{
    public class AlarmLog
    {
        public int Id { get; set; }
        public double Temperature { get; set; } 
        public DateTime LogDate { get; set; } = DateTime.UtcNow; 
        public string Message { get; set; } = string.Empty; 
    }
}