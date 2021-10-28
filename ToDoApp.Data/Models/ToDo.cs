using System;
namespace ToDoApp.Data.Models
{
    public partial class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Due { get; set; }
        public bool Completed { get; set; }
        public DateTimeOffset Created_Dt { get; set; }
        public DateTimeOffset Updated_Dt { get; set; }
    }
}
