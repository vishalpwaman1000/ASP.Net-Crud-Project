namespace Crud_Project_MVC.Models
{
    public class AddStudentRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool SubScribed { get; set; }
    }
}
