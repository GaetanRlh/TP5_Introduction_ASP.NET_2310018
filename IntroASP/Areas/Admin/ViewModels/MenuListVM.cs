using IntroASP.Models;
using Org.BouncyCastle.Asn1.Mozilla;

namespace IntroASP.Areas.Admin.ViewModels
{
    public class MenuListVM
    {
        public IEnumerable<Menu> Menus { get; set; } = new List<Menu>();
    }
}
