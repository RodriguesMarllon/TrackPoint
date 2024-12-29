namespace Api.Models.Project.RequestBody
{
    public class CreateProjectBodyModel
    {
        public string Name { get; set; }
        public decimal TotalHours { get; set; }
        public decimal ConsumedHours { get; set; }
        public string Description { get; set; }
    }
}
