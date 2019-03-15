using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FB.Models;

namespace FB.Controllers
{
    public class FBPostsController : Controller
    {
        private Modeldb db = new Modeldb();

        // GET: FBPosts
        public ActionResult Index()
        {
            return View(db.FBPosts.ToList());
        }

        // GET: FBPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FBPost fBPost = db.FBPosts.Find(id);
            if (fBPost == null)
            {
                return HttpNotFound();
            }
            return View(fBPost);
        }

        // GET: FBPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FBPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Like,DisLike")] FBPost fBPost)
        {
            if (ModelState.IsValid)
            {
                db.FBPosts.Add(fBPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fBPost);
        }

        // GET: FBPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FBPost fBPost = db.FBPosts.Find(id);
            if (fBPost == null)
            {
                return HttpNotFound();
            }
            return View(fBPost);
        }

        // POST: FBPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Like,DisLike")] FBPost fBPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fBPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fBPost);
        }

        // GET: FBPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FBPost fBPost = db.FBPosts.Find(id);
            if (fBPost == null)
            {
                return HttpNotFound();
            }
            return View(fBPost);
        }

        // POST: FBPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FBPost fBPost = db.FBPosts.Find(id);
            db.FBPosts.Remove(fBPost);
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
