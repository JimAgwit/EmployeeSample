using Dapper;
using EmployeeSample.Models;


namespace EmployeeSample.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration)
           : base(configuration) { }

        public async Task<List<Employee>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM Employees";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Employee>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
