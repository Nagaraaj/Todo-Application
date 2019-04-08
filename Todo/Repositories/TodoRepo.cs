using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Todo.Models;

namespace Todo.Repositories
{
    public class TodoRepo
    {
        private TodosDBContext db = new TodosDBContext();

        public List<Todos> GetAllTodos()
        {
          return  db.Todo.ToList();
        }

        public Todos GetTodosbyID(int id)
        {
           return db.Todo.Find(id);
        }

        public void UpdateTodos(Todos todos)
        {            
                db.Entry(todos).State = EntityState.Modified;
                db.SaveChanges(); 
        }

        public void DeleteTodos(int id)
        {
            Todos todos = db.Todo.Find(id);
            db.Todo.Remove(todos);
            db.SaveChanges();
        }

        public void SaveTodos(Todos todo)
        {
            db.Todo.Add(todo);
            db.SaveChanges();
        }
    }
}