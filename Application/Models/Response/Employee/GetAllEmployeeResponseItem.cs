namespace Application.Models.Response.Employee
{
    public class GetAllEmployeeResponseItem
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Signature { get; set; }
        public bool Active { get; set; }
        public string Position { get; set; }
        public DateTime? DateInsertUpdate { get; set; }
    }
}
