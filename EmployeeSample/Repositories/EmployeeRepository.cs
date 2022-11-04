using Dapper;
using EmployeeSample.Models;
using System.Data;

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

        public async Task<Employee> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM Employees WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Employee>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async  Task<int> CreateAsync(Employee employee)
        {
            try
            {
                var query = "INSERT INTO Employees (Fullname, Address, Contact, Salary) VALUES (@Fullname, @Address, @Contact, @Salary)";

                var parameters = new DynamicParameters();
                parameters.Add("Fullname", employee.Fullname, DbType.String);
                parameters.Add("Address", employee.Address, DbType.String);
                parameters.Add("Contact", employee.Contact, DbType.String);
                parameters.Add("Salary", employee.Salary, DbType.Decimal);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(Employee employee)
        {
            try
            {
                var query = "UPDATE Employees SET Fullname = @Fullname, Address = @Address, Contact = @Contact, Salary= @Salary WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Fullname", employee.Fullname, DbType.String);
                parameters.Add("Address", employee.Address, DbType.String);
                parameters.Add("Contact", employee.Contact, DbType.String);
                parameters.Add("Salary", employee.Salary, DbType.Decimal);

                using (var connection = CreateConnection())
                {
                    
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> DeleteAsync(Employee entity)
        {
            try
            {
                var query = "DELETE FROM Employees WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", entity.Id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
