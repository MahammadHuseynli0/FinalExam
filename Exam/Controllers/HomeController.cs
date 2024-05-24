
using Exam.Business.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exam.Controllers
{
    public class HomeController : Controller
    {


        private readonly IChefService _chefService;

        public HomeController(IChefService chefService)
        {
            _chefService = chefService;
        }

        public IActionResult Index()
        {
            var chefs = _chefService.GetAllChef().ToList();
            return View(chefs);
        }




    }
}
