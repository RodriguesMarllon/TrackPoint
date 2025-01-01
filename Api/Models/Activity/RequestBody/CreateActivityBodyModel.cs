namespace Api.Models.Activity.RequestBody
{
    public class CreateActivityBodyModel
    {
        public long ProjectId{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool External { get; set; }
    }
}
