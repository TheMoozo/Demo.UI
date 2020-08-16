using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int Id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Add(T entity);
        Task<int> Delete(int Id);
        Task<int> Update(T entity);
    }
}
