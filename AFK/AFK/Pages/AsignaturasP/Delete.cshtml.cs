using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AFK.Data;
using AFK.Models;

namespace AFK.Pages.AsignaturasP
{
    public class DeleteModel : PageModel
    {
        private readonly AFK.Data.AFKContext _context;

        public DeleteModel(AFK.Data.AFKContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Asignatura = await _context.Asignatura.FindAsync(id);

            if (Asignatura != null)
            {
                _context.Asignatura.Remove(Asignatura);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
