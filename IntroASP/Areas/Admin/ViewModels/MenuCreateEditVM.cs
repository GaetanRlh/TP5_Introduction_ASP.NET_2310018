using System.ComponentModel.DataAnnotations;

namespace IntroASP.Areas.Admin.ViewModels
{
    public class MenuCreateEditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La description est requise")]
        public string Description { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? SubmitButtonText { get; set; }

    }
}
