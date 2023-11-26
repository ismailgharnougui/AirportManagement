using System.Linq.Expressions;

namespace AM.ApplicationCore.Interfaces
{ 
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
        //Delete (p=>p.Username.Equals(nom))
        TEntity GetById(params object[] keyValues);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAll(); // GetMany()
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where = null);
    }    
}