namespace Api.Models.Project.RequestBody
{
    public class UpdateProjectBodyModel
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
        public byte? Status { get; set; }
        public int? CreatedBy { get; set; }
    }
}
