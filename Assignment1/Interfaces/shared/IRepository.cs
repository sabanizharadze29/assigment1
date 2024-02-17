using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment1.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Update(T item);
        void Delete(int id);
    }
}