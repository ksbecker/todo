using System.Linq;

namespace ToDoApp.Data.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> List();
    }
}
