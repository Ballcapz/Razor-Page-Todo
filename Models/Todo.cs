
using System;
using System.ComponentModel.DataAnnotations;

namespace RazorTodo.Models
{
    public class Todo
    {
        public Todo()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        public string Description { get; set; }

    }
}