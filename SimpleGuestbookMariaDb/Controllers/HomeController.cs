using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleGuestbookMariaDb.Dto;
using SimpleGuestbookMariaDb.Models;
using SimpleGuestbookMariaDb.Repositories;

namespace SimpleGuestbookMariaDb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PostsRepository _postsRepository;

        public HomeController(ILogger<HomeController> logger, PostsRepository postsRepository)
        {
            _logger = logger;
            _postsRepository = postsRepository;
        }

        public IActionResult Index()
        {
            var posts = _postsRepository.GetAll();
            var model = new GuestbookViewModel() { AllPosts = posts };
            return View(model);
        }

        [HttpPost("add")]
        public IActionResult AddPost(PostDto post)
        {
            post.CreatedOn = DateTime.UtcNow;
            _postsRepository.Add(post);

            var posts = _postsRepository.GetAll();
            var model = new GuestbookViewModel() { AllPosts = posts };
            return View("Index", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
