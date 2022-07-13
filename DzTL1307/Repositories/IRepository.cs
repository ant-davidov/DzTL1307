using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzTL1307.Repositories
{
    public interface IRepository<T>
    {
        IReadOnlyList<T> GetAll();
        T GetById(int id);
        void Insert(T model);
        void Delete(int id);
    }
}
