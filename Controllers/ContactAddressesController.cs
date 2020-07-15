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
    public class ContactAddressesController : Controller
    {
        private ContactDirectoryDbContext db = new ContactDirectoryDbContext();

        // GET: ContactAddresses
        public ActionResult Index()
        {
            var contactAddresses = db.ContactAddresses.Include(c => c.ContactDirectory);
            return View(contactAddresses.ToList());
        }

        // GET: ContactAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactAddress contactAddress = db.ContactAddresses.Find(id);
            if (contactAddress == null)
            {
                return HttpNotFound();
            }
            return View(contactAddress);
        }

        // GET: ContactAddresses/Create
        public ActionResult Create()
        {
            ViewBag.ContactDirectoryId = new SelectList(db.ContactDirectories, "Id", "Name");
            return View();
        }

        // POST: ContactAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address,City,Pincode,ContactDirectoryId")] ContactAddress contactAddress)
        {
            if (ModelState.IsValid)
            {
                db.ContactAddresses.Add(contactAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactDirectoryId = new SelectList(db.ContactDirectories, "Id", "Name", contactAddress.ContactDirectoryId);
            return View(contactAddress);
        }

        // GET: ContactAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactAddress contactAddress = db.ContactAddresses.Find(id);
            if (contactAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactDirectoryId = new SelectList(db.ContactDirectories, "Id", "Name", contactAddress.ContactDirectoryId);
            return View(contactAddress);
        }

        // POST: ContactAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address,City,Pincode,ContactDirectoryId")] ContactAddress contactAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactDirectoryId = new SelectList(db.ContactDirectories, "Id", "Name", contactAddress.ContactDirectoryId);
            return View(contactAddress);
        }

        // GET: ContactAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactAddress contactAddress = db.ContactAddresses.Find(id);
            if (contactAddress == null)
            {
                return HttpNotFound();
            }
            return View(contactAddress);
        }

        // POST: ContactAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactAddress contactAddress = db.ContactAddresses.Find(id);
            db.ContactAddresses.Remove(contactAddress);
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
