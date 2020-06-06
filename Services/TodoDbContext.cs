
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorTodo.Models;

namespace RazorTodo.Services
{
    public class TodoDbContext : DbContext, ITodoRepository
    {

        public DbSet<Todo> Todos { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().ToTable("Todo").HasKey(todo => todo.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Todo");
        }

        public async Task Add([Bind(nameof(Todo.Description))] Todo todo)
        {
            Todos.Add(todo);
            await SaveChangesAsync();
        }

        public async Task<Todo> Find(Guid id)
        {
            return await Todos.FindAsync(id);
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            return await Todos.ToListAsync();
        }

        public async Task Remove(Guid id)
        {
            var todo = await Todos.FindAsync(id);
            Todos.Remove(todo);
            await SaveChangesAsync();
        }

        public async Task Update(Todo todo)
        {
            Todo toUpdate = await Todos.FindAsync(todo.Id);
            if (toUpdate != null)
            {
                toUpdate.Description = todo.Description;
                await SaveChangesAsync();
            }
        }
    }
}