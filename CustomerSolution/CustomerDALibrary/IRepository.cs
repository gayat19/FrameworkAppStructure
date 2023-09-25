using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDALibrary
{
    public interface IRepository<K,T>where T : class
    {
         Task<T> Get(K key);
        Task<T> Add(T item);
        Task<T> Delete(K key);
        Task<T> Update(T item);
        Task<ICollection<T>> GetAll();
    }
}
