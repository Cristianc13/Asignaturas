using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AFK.Data;
using AFK.Models;

namespace AFK.Pages.EstudiantesP
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
        ViewData["IDAsignatura"] = new SelectList(_context.Set<Asignatura>(), "IDAsignatura", "IDAsignatura");
            return Page();
        }

        [BindProperty]
        public Estudiante Estudiante { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Estudiante.Add(Estudiante);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}