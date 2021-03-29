using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();

        TEntity GetByID(object id);

        TEntity Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        TEntity Update(TEntity entityToUpdate);
    }
}
