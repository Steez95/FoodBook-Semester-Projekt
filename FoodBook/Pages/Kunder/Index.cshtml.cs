using FoodBook.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodBook.Pages.Kunder
{
    public class IndexModel : PageModel
    {

        public List<Kunde> Kunder { get; set; } = new List<Kunde>();

        [BindProperty]
        public Kunde NyKunde { get; set; }
        public Kunde Kunde { get; private set; }

        public void OnGet()
        {
            Kunde = NyKunde;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage();
        }
    }
}
