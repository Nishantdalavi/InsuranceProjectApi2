using System.Linq.Expressions;

namespace EInsuranceProject.Repository
{
    public interface IEntityRepository<T>
    {
        public Task<IEnumerable<T>> GetAll(string[] innerTable, Expression<Func<T, bool>> predicate);
       
        public Task<T> GetById(object id);

        public Task Insert(T entity);
        public Task<bool> Update(T entity,int id);
        public  Task<bool> Delete(object id);
    }
}
