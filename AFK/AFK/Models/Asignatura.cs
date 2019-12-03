using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFK.Models
{
    public class Asignatura
    {
        [Key]
        public int IDAsignatura { get; set; }
        public string NombreAsignatura { get; set; }
    }
}
