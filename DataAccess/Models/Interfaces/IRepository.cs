using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PostgresApi.DataAccess.Models.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        IQueryable<T> Query();

        //Dirty access to other DbContext entities, handy for Transaction updates
        void Add<U>(U obj) where U : class;
        void Update<U>(U obj) where U : class;
        void Remove<U>(U obj) where U : class;
        IQueryable<U> Query<U>() where U : class;

        void Save();

        Task SaveAsync();
    }
}
