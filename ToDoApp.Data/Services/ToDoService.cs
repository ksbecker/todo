using System.Linq;
using ToDoApp.Data.Models;
using ToDoApp.Data.Repositories.Interfaces;
using ToDoApp.Data.Services.Interfaces;

namespace ToDoApp.Data.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoService(IToDoRepository toDoRepository) => _toDoRepository = toDoRepository;

        public ToDo Create(ToDo toDo) => _toDoRepository.Create(toDo);
        public bool Delete(int id) => _toDoRepository.Delete(id);
        public ToDo Get(int id) => _toDoRepository.Get(id);
        public IQueryable<ToDo> List() => _toDoRepository.List();
        public bool Update(ToDo toDo) => _toDoRepository.Update(toDo);
        public bool ToggleCompleted(int id, bool completed)
        {
            var toDo = Get(id);

            toDo.Completed = completed;

            Update(toDo);

            return true;
        }
    }
}
