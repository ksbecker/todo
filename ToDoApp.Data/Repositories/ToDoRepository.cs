using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using ToDoApp.Data.Models;
using ToDoApp.Data.Repositories.Interfaces;

namespace ToDoApp.Data.Repositories
{
    public class ToDoRepository : BaseRepository<ToDo>, IToDoRepository
    {
        public ToDoRepository(ToDoContext context, ILogger<ToDoRepository> logger) : base(context, logger) { }

        public bool Create(ToDo toDo)
        {
            if (toDo == null)
                throw new ArgumentNullException(nameof(toDo), "To do cannot be null");

            try
            {
                toDo.Updated_Dt = DateTimeOffset.Now;
                toDo.Created_Dt = DateTimeOffset.Now;

                Context.Add(toDo);
                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError($"There was an error creating the to do: {ex.Message}");

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var toDo = Context.ToDo.Find(id);

                if (toDo == null)
                {
                    Logger.LogWarning($"While attempting to delete, to do not found. ID: {id}");

                    return false;
                }

                Context.Remove(toDo);
                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error deleting to do: {ex.Message}");

                return false;
            }
        }

        public ToDo Get(int id)
        {
            try
            {
                var toDo = Context.ToDo.Find(id);

                if (toDo == null)
                {
                    Logger.LogError("To do not found");

                    return null;
                }

                return toDo;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error retrieving to do: {ex.Message}");

                return null;
            }
        }

        public IQueryable<ToDo> List()
        {
            try
            {
                return Context.ToDo;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error retrieving list of to dos: {ex.Message}");

                return null;
            }
        }

        public bool Update(ToDo toDo)
        {
            if (toDo == null)
                throw new ArgumentNullException(nameof(toDo), "To do cannot be null");

            try
            {
                var toDoFromDB = Context.ToDo.Find(toDo.Id);

                if (toDoFromDB == null)
                {
                    Logger.LogWarning($"While attempting to update, to do was not found. ID: {toDo.Id}");

                    return false;
                }

                toDo.Updated_Dt = DateTimeOffset.Now;
                Context.Entry(toDoFromDB).CurrentValues.SetValues(toDo);

                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error updating to do: {ex.Message}");

                return false;
            }
        }
    }
}
