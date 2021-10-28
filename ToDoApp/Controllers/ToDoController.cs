using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Data.Services.Interfaces;
using ToDoApp.ViewModels;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private readonly IToDoService _toDoService;
        private readonly IMapper _mapper;

        public ToDoController(IToDoService toDoService, IMapper mapper)
        {
            _toDoService = toDoService;
            _mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<ToDoViewModel> Get() => ToDoViewModel.List(_toDoService, _mapper);

        // POST api/values
        [HttpPost]
        public void Post([FromForm] ToDoViewModel toDoViewModel) => toDoViewModel.Add(_toDoService, _mapper);

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] bool completed) => ToDoViewModel.ToggleComplete(_toDoService, id, completed);

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) => ToDoViewModel.Delete(_toDoService, id);
    }
}
