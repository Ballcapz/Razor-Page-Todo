using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorTodo.Models;
using RazorTodo.Services;

namespace Razor_Page_Todo.Services
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _dbContext;
        public TodoRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task Add([Bind(nameof(Todo.Description))] Todo todo)
        {
            _dbContext.Todos.Add(todo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Todo> Find(Guid id)
        {
            return await _dbContext.Todos.FindAsync(id);
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            return await _dbContext.Todos.ToListAsync();
        }

        public async Task Remove(Guid id)
        {
            var todo = await _dbContext.Todos.FindAsync(id);
            _dbContext.Todos.Remove(todo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Todo todo)
        {
            Todo toUpdate = await _dbContext.Todos.FindAsync(todo.Id);
            if (toUpdate != null)
            {
                toUpdate.Description = todo.Description;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}