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
                throw new Exception("");

            return mapper.Map<IEnumerable<ToDoViewModel>>(toDos);
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

        #endregion
    }
}
