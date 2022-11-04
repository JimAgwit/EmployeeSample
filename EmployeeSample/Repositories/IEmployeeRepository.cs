using EmployeeSample.Models;

namespace EmployeeSample.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        //Task<string?> GetByIdAsync();

    }
}
