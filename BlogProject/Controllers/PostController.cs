using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Models;
using BlogProject.Data;

namespace BlogProject.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PostController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            IEnumerable<Post> objList = _db.Post;
            return View(objList);

        }


       
        //GET-CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST-CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post obj)
        {
            if (ModelState.IsValid)
            {
                _db.Post.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET-EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Post.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST-EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post obj)
        {
            if (ModelState.IsValid)
            {
                _db.Post.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET-DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Post.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST-DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Post.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Post.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        // GET: POST-DETAILS
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _db.Post.Find(id);
                
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
