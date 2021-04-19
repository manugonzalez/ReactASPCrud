using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactASPCrud.Repository
{
    //Generic Repository Interface
    public interface IGenericRepository<T> where T: class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        T Insert(T obj);

        void Update(T obj);

        void Delete(T obj);

        void Save();
    }
}
