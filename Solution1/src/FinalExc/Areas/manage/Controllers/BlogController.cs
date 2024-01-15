using FinalExc.Business.Services.Interfaces;
using FinalExp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinalExc.Areas.manage.Controllers
{
    [Area("Manage")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            this._blogService = blogService;
        }
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetBlogs();
            return View(blogs);
        }
        public IActionResult Create()
        {
            if(!ModelState.IsValid) return View();
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            if (!ModelState.IsValid) return View();
            _blogService.Create(blog);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            if (!ModelState.IsValid) return View();
            var blog = _blogService.GetAsync(id);
            return View(blog);
        }
        [HttpPost]
        public IActionResult Update(Blog blog)
        {
            if (!ModelState.IsValid) return View();
            _blogService.Update(blog);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
          
            _blogService.DeleteAsync(id);
            return View();
        }


    }
}
