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
    }
}
