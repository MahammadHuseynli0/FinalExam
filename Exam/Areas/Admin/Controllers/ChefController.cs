using Exam.Business.Exceptions;
using Exam.Business.Services.Abstracts;
using Exam.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Exam.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ChefController : Controller
    {
        IChefService _chefService;

        public ChefController(IChefService chefService)
        {
            _chefService = chefService;
        }

        public IActionResult Index()
        {

            var chefs = _chefService.GetAllChef();


            return View(chefs);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Chef chef)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _chefService.AddChef(chef);
            }
            catch (ImageFileRequiredException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
            catch (FileSizeException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");

        }



        public IActionResult Update(int id)
        {
            var exist = _chefService.GetChef(x => x.Id == id);
            if (exist == null)
                return View("Error");

            return View(exist);
        }



        [HttpPost]

        public IActionResult Update(Chef chef)
        {
            if (chef == null)
                return View("Error");


            try
            {
                _chefService.UpdateChef(chef);
            }
            catch (EntityNotFoundException ex)
            {
                return View("Error");
            }
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
            catch (FileSizeException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var exist = _chefService.GetChef(x => x.Id == id);
            if (exist == null)
                return View("Error");

            return View(exist);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var exist = _chefService.GetChef(x => x.Id == id);
            if (exist == null)
                return View("Error");


            try
            {
                _chefService.RemoveChef(id);
            }
            catch (EntityNotFoundException ex)
            {
                return View("Error");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }



    }
}




