using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskNote.Models;

namespace TaskNote.Controllers
{
    public class TasksController : Controller
    {
        private TaskContext db = new TaskContext();

        // GET: Tasks
        public ActionResult Index()
        {
            var date = DateTime.Today;
            List<Task> tasks = (db.Tasks.Where(t => t.FinishDate == date)).ToList();

            return View(tasks);
        }

        // GET: Tasks
        public ActionResult TomorrowTask()
        {
            var date = DateTime.Today;
            var tomorrowDate = date.AddDays(1);
            List<Task> tasks = (db.Tasks.Where(t => t.FinishDate == tomorrowDate)).ToList();
            return View(tasks);
        }

        // GET: Tasks
        public ActionResult OtherDayTask()
        {
            var date = DateTime.Today;
            var tomorrowDate = date.AddDays(1);
            List<Task> tasks = (db.Tasks.Where(t => t.FinishDate > tomorrowDate)).ToList();
            return View(tasks);
        }

        // GET: Tasks
        public ActionResult MissedTask()
        {
            var date = DateTime.Today;
            List<Task> tasks = (db.Tasks.Where(t => t.FinishDate < date)).ToList();
            return View(tasks);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TaskNote,FinishDate")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TaskNote,FinishDate")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
