using System;
using System.Collections.Generic;

namespace MyTodolist.Models
{
    public class TodolistVM
    {
        public string? Title { get; set; }
        public string? Note { get; set; }

    }

    public partial class Todolist : TodolistVM
    {
        public string Id { get; set; } = null!;
    }
    
}
