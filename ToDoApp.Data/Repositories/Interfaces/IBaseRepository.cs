using System.Linq;

namespace ToDoApp.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> List();
    }
}
