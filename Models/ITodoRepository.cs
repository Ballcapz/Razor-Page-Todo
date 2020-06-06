
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorTodo.Models
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAll();
        Task Add(Todo todo);
        Task Remove(Guid id);
        Task<Todo> Find(Guid id);
        Task Update(Todo todo);
    }

}