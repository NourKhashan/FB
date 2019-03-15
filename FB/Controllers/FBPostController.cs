using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FB.Models;
using System.Data.Entity;

namespace FB.Controllers
{
    public class FBPostController : Controller
    {
        Modeldb db = new Modeldb();
        // GET: FBPost
        public ActionResult Index()
        {
            FBCommentsModel fBCommentsModel = new FBCommentsModel();
            fBCommentsModel.Posts = db.FBPosts.ToList();
            fBCommentsModel.FBPost = new FBPost();
            return View(fBCommentsModel);
        }


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

            return View("_Posts", db.FBPosts.ToList());
        }

        public ActionResult AddComments(int? id)
        {
            ViewBag.Post = db.FBPosts.SingleOrDefault(po=>po.Id == id);  
            return View(db.Comments.Include(pp=>pp.FBPost).Where(co=> co.FbPostsId == id));
        }

        [HttpPost]
        public ActionResult AddComments(int? id, string Description)
        {
            ViewBag.desc = Description;
            ViewBag.Post = db.FBPosts.SingleOrDefault(po => po.Id == id);
            db.Comments.Add(new Comment() { Description = Description, FbPostsId = ViewBag.Post.Id });
            db.SaveChanges();
            return PartialView("_Comments",db.Comments.Include(pp => pp.FBPost).Where(co => co.FbPostsId == id));
            //return View(db.Comments.Include(pp => pp.FBPost).Where(co => co.FbPostsId == id));
        }

        
        public ActionResult Like(int? id)
        {
            FBPost post = db.FBPosts.SingleOrDefault(pp => pp.Id == id);
               post.Like= post.Like + 1;
            db.SaveChanges();
            ViewBag.like = post.Like;
            return PartialView();
        }


        public ActionResult DisLike(int? id)
        {
            FBPost post = db.FBPosts.SingleOrDefault(pp => pp.Id == id);
            post.DisLike = post.DisLike + 1;
            db.SaveChanges();
            ViewBag.Dislike = post.DisLike;
            return PartialView();
        }



        public ActionResult Delete(int? id)
        {
            List<Comment> comments =  db.Comments.Where(a=>a.FbPostsId == id).ToList();
            db.Comments.RemoveRange(comments);
            var post = db.FBPosts.SingleOrDefault(a=>a.Id == id);
            db.FBPosts.Remove(post);

            db.SaveChanges();

            FBCommentsModel fBCommentsModel = new FBCommentsModel();
            fBCommentsModel.Posts = db.FBPosts.ToList();
            fBCommentsModel.FBPost = new FBPost();
            return View("Index", fBCommentsModel);
        }



    }
}