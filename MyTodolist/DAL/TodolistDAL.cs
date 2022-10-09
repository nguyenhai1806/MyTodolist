using System;
using MyTodolist.Models;

namespace MyTodolist.DAL
{
    public class TodolistDAL
    {
        DBTodolistContext dbcontext = new DBTodolistContext();
        public TodolistDAL()
        {
           
        }
        public List<Todolist> Get()
        {
            return dbcontext.Todolists.ToList();
        }
        public Todolist Get(string id)
        {
            return dbcontext.Todolists.Where(t => t.Id == id).SingleOrDefault();
        }
        public bool Create(TodolistVM todolistVM)
        {
            try
            {
                Todolist todolist = new Todolist();
                todolist.Id = Guid.NewGuid().ToString();
                todolist.Note = todolistVM.Note;
                todolist.Title = todolistVM.Title;

                dbcontext.Todolists.Add(todolist);
                return dbcontext.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(string id,TodolistVM todolistVM)
        {
            try
            {
                Todolist todolist = dbcontext.Todolists.Where(t => t.Id == id).SingleOrDefault();
                if (todolist == null)
                    return false;
                else
                {
                    todolist.Note = todolistVM.Note;
                    todolist.Title = todolistVM.Title;
                    return dbcontext.SaveChanges() > 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

