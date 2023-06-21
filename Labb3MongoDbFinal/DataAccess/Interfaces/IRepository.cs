using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        void add(T entity);

        IEnumerable<T> GetAll();

        void update(T entity);

        void delete(T entity);

        T GetById(Guid id);

        T GetByUsernameAndPassword(string password, string username);
    }
}
