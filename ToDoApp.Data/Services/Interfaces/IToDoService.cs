using ToDoApp.Data.Models;

namespace ToDoApp.Data.Services.Interfaces
{
    public interface IToDoService : IBaseService<ToDo>
    {
        bool Create(ToDo toDo);
        ToDo Get(int id);
        bool Update(ToDo toDo);
        bool Delete(int id);
        bool ToggleCompleted(int id, bool completed);
    }
}
