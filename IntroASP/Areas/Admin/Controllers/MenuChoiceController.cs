using IntroASP.Areas.Admin.ViewModels;
using IntroASP.DataAccessLayer;
using IntroASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace IntroASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuChoiceController : Controller
    {

        private readonly DAL _dal;

        public MenuChoiceController()
        {
            _dal = new DAL();
        }

        public IActionResult List()
        {
            var menus = _dal.MenuFactory.GetAllMenu();

            var vm = new MenuListVM
            {
                Menus = menus
      
            };

            return View(vm); 
        }


        [HttpGet]
        public IActionResult Create()
        {
            var vm = new MenuCreateEditVM
            {
                Title = "Créer un menu",
                SubmitButtonText = "Créer",
            };

            return View("CreateEdit", vm);
        }

        [HttpPost]
        public IActionResult Create(MenuCreateEditVM vm) 
        {
            if (!ModelState.IsValid)
                return View("CreateEdit", vm);

            var exists = _dal.MenuFactory.GetAllMenu()
                .Any(m => m.Description == vm.Description);
            if (exists)
            {
                ModelState.AddModelError("Description", "Ce Choix de menu exist deja.");
                return View("CreateEdit", vm);

            }

            _dal.MenuFactory.InsertMenu(vm.Description);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var menu = _dal.MenuFactory.GetMenuById(id);
            if (menu == null)
                return NotFound();

            var vm = new MenuCreateEditVM
            {
                Id = menu.Id,
                Description = menu.Description,
                Title = "Modifier un menu",
                SubmitButtonText = "Modifier"
            };

            return View("CreateEdit", vm);
        }


        [HttpPost]
        public IActionResult Edit(MenuCreateEditVM vm) 
        {
            if(!ModelState.IsValid)
                return View("CreateEdit", vm);

            var exists = _dal.MenuFactory.GetAllMenu()
                .Any(m => m.Description == vm.Description);
            if (exists)
            {
                ModelState.AddModelError("Description", "Ce Choix de menu exist deja.");
                return View("CreateEdit", vm);

            }

            Menu EditedMenu = new Menu(vm.Id, vm.Description);

            _dal.MenuFactory.UpdateMenu(EditedMenu);
            return RedirectToAction("List"); 
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var menu = _dal.MenuFactory.GetMenuById(id);
            if (menu == null)
                return NotFound();

            var vm = new MenuDeleteVM
            {
                Id = menu.Id,
                Description = menu.Description
            };

            return View("Delete",vm);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _dal.MenuFactory.DeleteMenu(id);
            return RedirectToAction("List", "MenuChoice");
        }
    }
}
