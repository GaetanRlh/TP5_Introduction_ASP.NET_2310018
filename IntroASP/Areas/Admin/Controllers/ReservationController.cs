using IntroASP.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using IntroASP.ViewModels;
using IntroASP.Areas.Admin.ViewModels;

namespace IntroASP.Areas.Admin.Controllers { 
    [Area("Admin")]
    public class ReservationController : Controller
    {

        private readonly DAL _dal;

        public ReservationController()
        {
            _dal = new DAL();
        }

        public IActionResult List()
        {
            var Reservations = _dal.ReservationFactory.GetAllReservations();

            var vm = new ReservationListVM
            {
                Reservations = Reservations
            };

            return View(vm);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var reservation = _dal.ReservationFactory.GetReservationById(id);
            if (reservation == null)
                return NotFound();

            var vm = new ReservationDeleteVM
            {
                Id = reservation.Id,
                Nom = reservation.Name,
                Courriel = reservation.Email,
                NombreDePersonnes = reservation.NumberOfPeople,
                DateReservation = reservation.ReservationDate,
                MenuId = reservation.MenuChoiceId
            };

            return View("Delete", vm);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _dal.ReservationFactory.DeleteReservation(id);
            return RedirectToAction("List");
        }
    }
    
}