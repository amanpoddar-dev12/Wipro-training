using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationTest.Models;

namespace WebApplicationTest.Areas.Identity.Pages.Org
{
    public class CreateModel : PageModel
    {
        private readonly OrgContext _context;

        public CreateModel(OrgContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Organization Organization { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.organizations.Add(Organization);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
