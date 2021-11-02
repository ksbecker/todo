using ToDoApp.Data.Models;

namespace ToDoApp.Data.Repositories.Interfaces
{
    public interface IToDoRepository : IBaseRepository<ToDo>
    {
        bool Create(ToDo toDo);
        ToDo Get(int id);
        bool Update(ToDo toDo);
        bool Delete(int id);
    }
}
