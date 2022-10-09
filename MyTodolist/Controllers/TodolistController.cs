using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTodolist.DAL;
using MyTodolist.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTodolist.Controllers
{
    [Route("api/[controller]")]
    public class TodolistController : Controller
    {
        TodolistDAL dal = new TodolistDAL();
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(dal.Get());
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(string id)
        {
            try
            {
                Todolist todolist = dal.Get(id);
                return todolist == null ? NotFound() : Ok(todolist);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Post(TodolistVM todolistVM)
        {
            try
            {
                return dal.Create(todolistVM) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult Put(string id, TodolistVM todolistVM)
        {
            try
            {
                return dal.Update(id,todolistVM) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

