using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IntroASP.ViewModels
{
    public class ReservationCreateVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(20, ErrorMessage = "Le nom ne peut pas dépasser 20 caractères")]
        [Display(Name = "Nom")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le courriel est requis")]
        [EmailAddress(ErrorMessage = "Adresse courriel invalide")]
        [StringLength(50)]
        [Display(Name = "Courriel")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le nombre de personnes est requis")]
        [Range(1, 50, ErrorMessage = "Le nombre de personnes doit être entre 1 et 50")]
        [Display(Name = "Nombre de personnes")]
        public int NumberOfPeople { get; set; }

        [Required(ErrorMessage = "La date de réservation est requise")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date de réservation")]
        public DateTime ReservationDate { get; set; }

        [Required(ErrorMessage = "Le choix de menu est requis")]
        [Display(Name = "Menu")]
        public int MenuChoiceId { get; set; }

        public string? MenuDescription
        {
            get; set;
        }

        public List<SelectListItem> MenuChoices { get; set; } = new List<SelectListItem>();

        public ReservationCreateVM()
        {
            ReservationDate = DateTime.Today;
        }
    }
}
