using System;
using System.Linq;
using ToDoApp.Data.Models;
using ToDoApp.Data.Repositories.Interfaces;

namespace ToDoApp.Data.Repositories
{
    public class ToDoRepository : BaseRepository<ToDo>, IToDoRepository
    {
        public ToDoRepository(ToDoContext context) : base(context) { }

        public ToDo Create(ToDo toDo)
        {
            if (toDo == null)
                throw new ArgumentNullException(nameof(toDo), "To do cannot be null");

            try
            {
                toDo.Updated_Dt = DateTimeOffset.Now;

                Context.Add(toDo);
                Context.SaveChanges();

                return toDo;
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error creating the to do: {ex.Message}");
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var toDo = Context.ToDo.Find(id);

                if (toDo == null)
                    throw new Exception($"While attempting to delete, to do not found. ID: {id}");

                Context.Remove(toDo);
                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting to do: {ex.Message}");
            }
        }

        public ToDo Get(int id)
        {
            try
            {
                return Context.ToDo.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving to do: {ex.Message}");
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
                throw new Exception($"Error retrieving list of to dos: {ex.Message}");
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
                    throw new Exception($"While attempting to update, to do was not found. ID: {toDo.Id}");

                toDo.Updated_Dt = DateTimeOffset.Now;
                Context.Entry(toDoFromDB).CurrentValues.SetValues(toDo);

                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating to do: {ex.Message}");
            }
        }
    }
}
