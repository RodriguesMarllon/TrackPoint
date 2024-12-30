namespace Application.Models.Response
{
    public class GetAllProjectResponseItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal TotalHours { get; set; }
        public decimal ConsumedHours { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
