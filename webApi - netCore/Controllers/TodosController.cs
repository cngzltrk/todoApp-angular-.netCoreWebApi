using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodosController(TodoService todoService)
        {
            _todoService = todoService;
        }
        [EnableCors("MyPolicy")]
        [HttpGet]
        public ActionResult<List<Todo>> Get() =>
            _todoService.Get();
        
        [EnableCors("MyPolicy")]
        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Todo> Get(string id)
        {
            var todo = _todoService.Get(id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }
        [EnableCors("MyPolicy")]
        [HttpPost]
        public ActionResult<Todo> upp(Todo todoIn)
        {
            var todo= _todoService.Get("5d7e1fbbd964a722fcb89b18");
            if (todo == null)
            {
                return NotFound();
            }

            _todoService.Update("5d7e1fbbd964a722fcb89b18", todoIn);

            return NoContent();
        }
       /*  [HttpPost]
        public ActionResult<Todo> Create(Todo todo)
        {
            _todoService.Create(todo);

            return CreatedAtRoute("GetBook", new { id = todo.Id.ToString() }, todo);
        }*/
/* 
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Todo todoIn)
        {
            var todo = _todoService.Get(id);

            if (todo == null)
            {
                return NotFound();
            }

            _todoService.Update(id, todoIn);

            return NoContent();
        }*/
/*
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var todo = _todoService.Get(id);

            if (todo == null)
            {
                return NotFound();
            }

            _todoService.Remove(todo.Id);

            return NoContent();
        }*/
    }
}