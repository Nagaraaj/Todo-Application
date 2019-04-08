using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public class Todos
    {
        public int ID { get; set; }
        [Required]
        [Display(Name="Task Details")]
        public string Name { get; set; }
        public string Status { get; set; }

    }

    public class TodosDBContext : DbContext
    {
        public TodosDBContext()
            : base("MyConnection")
        {

        }
        public DbSet<Todos> Todo { get; set; }
    }
}