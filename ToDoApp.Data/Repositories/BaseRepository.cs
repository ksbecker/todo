using Microsoft.Extensions.Logging;
using ToDoApp.Data.Models;

namespace ToDoApp.Data.Repositories
{
    public class BaseRepository<TEntity>
    {
        protected readonly ToDoContext Context;
        protected readonly ILogger Logger;

        public BaseRepository(ToDoContext context, ILogger<BaseRepository<TEntity>> logger)
        {
            Context = context;
            Logger = logger;
        }
    }
}
