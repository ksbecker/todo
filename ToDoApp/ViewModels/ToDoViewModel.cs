using System;
using System.Collections.Generic;
using AutoMapper;
using ToDoApp.Data.Models;
using ToDoApp.Data.Services.Interfaces;

namespace ToDoApp.ViewModels
{
    public class ToDoViewModel
    {
        #region Public Properties

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Due { get; set; }
        public bool Completed { get; set; }
        public DateTimeOffset Created_Dt { get; set; }
        public DateTimeOffset Updated_Dt { get; set; }

        #endregion

        #region Methods

        internal static IEnumerable<ToDoViewModel> List(IToDoService toDoService, IMapper mapper)
        {
            var toDos = toDoService.List();

            if (toDos == null)
                return null;

            return mapper.Map<IEnumerable<ToDoViewModel>>(toDos);
        }

        internal static ToDoViewModel Get(int id, IToDoService toDoService, IMapper mapper)
        {
            var toDo = toDoService.Get(id);

            if (toDo == null)
                return null;

            var toDoViewModel = mapper.Map<ToDoViewModel>(toDo);

            return toDoViewModel;
        }

        internal bool Add(IToDoService toDoService, IMapper mapper)
        {
            var newToDo = mapper.Map<ToDo>(this);

            toDoService.Create(newToDo);

            return true;
        }

        internal static bool Delete(IToDoService toDoService, int id)
        {
            toDoService.Delete(id);

            return true;
        }

        internal static bool ToggleComplete(IToDoService toDoService, int id, bool completed)
        {
            toDoService.ToggleCompleted(id, completed);

            return true;
        }

        internal bool Update(IToDoService toDoService, IMapper mapper)
        {
            var toDo = mapper.Map<ToDo>(this);

            toDoService.Update(toDo);

            return true;
        }

        #endregion
    }
}
