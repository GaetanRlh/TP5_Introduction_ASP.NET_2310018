using IntroASP.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using IntroASP.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using IntroASP.Models;
using IntroASP.Areas.Admin.ViewModels;
using static IntroASP.ViewModels.ReservationDetailsVM;

namespace IntroASP.Controllers
{
    public class ReservationController : Controller
    {

        private readonly DAL _dal;

        public ReservationController()
        {
            _dal = new DAL();
        }

        public IActionResult Reservation()
        {
            ViewBag.MenuChoices = _dal.MenuFactory.GetAllMenu()
            .OrderBy(m => m.Description) 
            .Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Description
            }).ToList();

            return View(new ReservationCreateVM());
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
        public IActionResult CreateReservation()
        {
            var menus = _dal.MenuFactory.GetAllMenu()
                .OrderBy(m => m.Description)
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Description
                }).ToList();

            var viewModel = new ReservationCreateVM
            {
                MenuChoices = menus
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult CreateReservation(ReservationCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.MenuChoices = _dal.MenuFactory.GetAllMenu()
                    .OrderBy(m => m.Description)
                    .Select(m => new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = m.Description
                    }).ToList();

                return View(vm);
            }

            var reservation = new Reservation(
                0,
                vm.Name,
                vm.Email,
                vm.NumberOfPeople,
                vm.ReservationDate,
                vm.MenuChoiceId
            );

            int newId = _dal.ReservationFactory.InsertReservation(reservation);

            return RedirectToAction("Details", new { id = newId });
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                ViewBag.ErrorMessage = "Identifiant de réservation manquant.";
                return View("Details", null);
            }

            var reservation = _dal.ReservationFactory.GetReservationById(id.Value);
            if (reservation == null)
            {
                ViewBag.ErrorMessage = "Réservation introuvable.";
                return View("Details", null);
            }

            var menu = _dal.MenuFactory.GetMenuById(reservation.MenuChoiceId);

            var vm = new ReservationDetailsVM
            {
                Id = reservation.Id,
                Name = reservation.Name,
                Email = reservation.Email,
                NumberOfPeople = reservation.NumberOfPeople,
                ReservationDate = reservation.ReservationDate,
                MenuDescription = menu?.Description ?? "(Menu inconnu)"
            };

            return View(vm);
        }
    }
    
}