namespace Api.Models.Employee.RequestBody
{
    public class CreateEmployeeBodyModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Signature { get; set; }
        public bool Active { get; set; }
        public string Position { get; set; }
    }
}
