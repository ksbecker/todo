using AutoMapper;
using ToDoApp.Data.Models;
using ToDoApp.ViewModels;

namespace ToDoApp
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            CreateMap<ToDo, ToDoViewModel>();
            CreateMap<ToDoViewModel, ToDo>();
        }
    }
}
