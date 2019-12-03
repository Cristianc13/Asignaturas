using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AFK.Data;
using AFK.Models;

namespace AFK.Pages.AsignaturasP
{
    public class CreateModel : PageModel
    {
        private readonly AFK.Data.AFKContext _context;

        public CreateModel(AFK.Data.AFKContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Asignatura Asignatura { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Asignatura.Add(Asignatura);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}