using EmployeeSample.Models;

namespace EmployeeSample.Services
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetAllEmployees();
        public Task<Employee> GetEmployeeById(int id);
    }
}
