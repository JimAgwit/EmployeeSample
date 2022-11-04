using EmployeeSample.Models;

namespace EmployeeSample.Services
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetAllEmployees();
        public Task<Employee> GetEmployeeById(int id);
        public Task<int> CreateEmployeeAsync(Employee employee);
        public Task<int> UpdateEmployeeAsync(Employee employee);
        public Task<int> DeleteEmployeeAsync(Employee employee);
    }
}
