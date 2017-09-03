using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASecurity.Domain.Repository
{
    public interface IBaseRepository<T> where T: class
    {
        void Insert(T entity);
        T Get(Guid id);
        void Update(T entity);
        void Delete(Guid id);
        List<T> Get();
    }
}
