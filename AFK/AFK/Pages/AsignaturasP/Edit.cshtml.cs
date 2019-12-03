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

namespace AFK.Pages.AsignaturasP
{
    public class EditModel : PageModel
    {
        private readonly AFK.Data.AFKContext _context;

        public EditModel(AFK.Data.AFKContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Asignatura Asignatura { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Asignatura = await _context.Asignatura.FirstOrDefaultAsync(m => m.IDAsignatura == id);

            if (Asignatura == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Asignatura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignaturaExists(Asignatura.IDAsignatura))
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

        private bool AsignaturaExists(int id)
        {
            return _context.Asignatura.Any(e => e.IDAsignatura == id);
        }
    }
}
