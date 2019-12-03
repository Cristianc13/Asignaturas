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
    public class IndexModel : PageModel
    {
        private readonly AFK.Data.AFKContext _context;

        public IndexModel(AFK.Data.AFKContext context)
        {
            _context = context;
        }

        public IList<Estudiante> Estudiante { get;set; }

        public async Task OnGetAsync()
        {
            Estudiante = await _context.Estudiante
                .Include(e => e.Asignatura).ToListAsync();
        }
    }
}
