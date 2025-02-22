namespace TrafficBackendAPI.ReportModule.Models
{
    internal class ReportModel : BaseModel
    {
        public required string Subject { get; set; }

        public required string Description { get; set; }

        public bool IsUrgent { get; set; }

        public int Status { get; set; }
    }
}
