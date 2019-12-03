using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AFK.Data;
using AFK.Models;

namespace AFK.Pages.EstudiantesP
{
    public class EditModel : PageModel
    {
        private readonly AFK.Data.AFKContext _context;

        public EditModel(AFK.Data.AFKContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Estudiante Estudiante { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Estudiante = await _context.Estudiante
                .Include(e => e.Asignatura).FirstOrDefaultAsync(m => m.ID == id);

            if (Estudiante == null)
            {
                return NotFound();
            }
           ViewData["IDAsignatura"] = new SelectList(_context.Set<Asignatura>(), "IDAsignatura", "IDAsignatura");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(Estudiante.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiante.Any(e => e.ID == id);
        }
    }
}
