using EmployeeSample.Models;
using EmployeeSample.Repositories;

namespace EmployeeSample.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<Employee>> GetAllEmployees ()
        {
            return await _employeeRepository.GetAllAsync();
           
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<int> CreateEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.CreateAsync(employee);
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.UpdateAsync(employee);
        }

        public async Task<int> DeleteEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.DeleteAsync(employee);
        }
    }
}
