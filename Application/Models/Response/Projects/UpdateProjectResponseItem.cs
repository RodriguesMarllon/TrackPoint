namespace Application.Models.Response.Projects
{
    public class UpdateProjectResponseItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal TotalHours { get; set; }
        public decimal? ConsumedHours { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? EstimatedDevelopmentHours { get; set; }
        public decimal? Budget { get; set; }
        public int? ResponsiblePerson { get; set; }
        public long? ClientId { get; set; }
        public byte? Status { get; set; }
        public int? CreatedBy { get; set; }
    }
}
