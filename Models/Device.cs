namespace SmartInventoryAPI.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string DeviceName { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string Status { get; set; } = "Pasif";
        public DateTime? LastMaintenanceDate { get; set; }
    }
}