using EmployeeSample.Domain;

namespace EmployeeSample.Models
{
    public class Employee:BaseEntity
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string? Address { get; set; }
        public string? Contact { get; set; }
        public DateTime Birthday { get; set; }
        public float Salary { get; set; }
    }
}
                