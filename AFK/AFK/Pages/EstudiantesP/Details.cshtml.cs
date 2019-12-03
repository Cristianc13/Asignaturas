using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AFK.Data;
using AFK.Models;

namespace AFK.Pages.EstudiantesP
{
    public class DetailsModel : PageModel
    {
        private readonly AFK.Data.AFKContext _context;

        public DetailsModel(AFK.Data.AFKContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
