using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Models;
using Todo.Repositories;

namespace Todo.Controllers
{
    public class ToDoController : Controller
    {
        //
        // GET: /ToDo/
        private TodoRepo todoRepo = new TodoRepo();
        List<Todos> lst = new List<Todos>()
        {
            new Todos(){Name = "TV", Status = "Active"},
            new Todos(){Name = "TV", Status = "Active"},
            new Todos(){Name = "TV", Status = "Active"},
        };
        public ActionResult Index()
        {
            return View(todoRepo.GetAllTodos());
        }

        public ActionResult Edit(int id) 
        {
            return View(todoRepo.GetTodosbyID(id));
        }

        public ActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNew(Todos obj)
        {
            if (ModelState.IsValid)
            {
                obj.Status = "TBD";
                todoRepo.SaveTodos(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(Todos obj)
        {
            if (ModelState.IsValid)
            {
                obj.Status = "TBD";
                todoRepo.UpdateTodos(obj);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View(todoRepo.GetTodosbyID(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            todoRepo.DeleteTodos(Id);
            return RedirectToAction("Index");
        }

        
        public ActionResult MarkStatusDone(int id)
        {
            Todos todo = todoRepo.GetTodosbyID(id);
            todo.Status = "Done";
            todoRepo.UpdateTodos(todo);
           return RedirectToAction("Index");
        }

    }
}
