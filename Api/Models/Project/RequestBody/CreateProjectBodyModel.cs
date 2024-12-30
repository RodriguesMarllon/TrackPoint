namespace Api.Models.Project.RequestBody
{
    public class CreateProjectBodyModel
    {
        public string Name { get; set; }
        public decimal TotalHours { get; set; }
        public decimal? ConsumedHours { get; set; } = 0;
        public DateOnly? StartDate { get; set; } = null;
        public DateOnly? EndDate { get; set; } = null;
        public int? EstimatedDevelopmentHours { get; set; }
        public decimal? Budget { get; set; }
        public int? ResponsiblePerson { get; set; }
        public long? ClientId { get; set; }
        public byte? Status { get; set; }
        public int? CreatedBy { get; set; }
    }
}
