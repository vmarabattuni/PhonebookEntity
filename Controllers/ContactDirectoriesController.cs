using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhonebookEntity;

namespace PhonebookEntity.Controllers
{
    public class ContactDirectoriesController : Controller
    {
        private ContactDirectoryDbContext db = new ContactDirectoryDbContext();

        // GET: ContactDirectories
        public ActionResult Index()
        {
            return View(db.ContactDirectories.ToList());
        }

        // GET: ContactDirectories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDirectory contactDirectory = db.ContactDirectories.Find(id);
            if (contactDirectory == null)
            {
                return HttpNotFound();
            }
            return View(contactDirectory);
        }

        // GET: ContactDirectories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactDirectories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PhoneNumber,Email")] ContactDirectory contactDirectory)
        {
            if (ModelState.IsValid)
            {
                db.ContactDirectories.Add(contactDirectory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactDirectory);
        }

        // GET: ContactDirectories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDirectory contactDirectory = db.ContactDirectories.Find(id);
            if (contactDirectory == null)
            {
                return HttpNotFound();
            }
            return View(contactDirectory);
        }

        // POST: ContactDirectories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PhoneNumber,Email")] ContactDirectory contactDirectory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactDirectory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactDirectory);
        }

        // GET: ContactDirectories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDirectory contactDirectory = db.ContactDirectories.Find(id);
            if (contactDirectory == null)
            {
                return HttpNotFound();
            }
            return View(contactDirectory);
        }

        // POST: ContactDirectories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactDirectory contactDirectory = db.ContactDirectories.Find(id);
            db.ContactDirectories.Remove(contactDirectory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
