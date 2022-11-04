
using EmployeeSample.Domain;

namespace EmployeeSample.Repositories
{
    public interface  IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> CreateAsync(T employee);
        Task<int> UpdateAsync(T employee);
        Task<int> DeleteAsync(T employee);
    }
}
