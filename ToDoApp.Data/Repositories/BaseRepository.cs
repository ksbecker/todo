using ToDoApp.Data.Models;

namespace ToDoApp.Data.Repositories
{
    public class BaseRepository<TEntity>
    {
        protected readonly ToDoContext Context;

        public BaseRepository(ToDoContext context) => Context = context;
    }
}
