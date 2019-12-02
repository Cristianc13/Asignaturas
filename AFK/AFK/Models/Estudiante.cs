using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AFK.Models
{
    public class Estudiante
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }


        //Llave foranea
        [ForeignKey("Asignatura")]
        public int? IDAsignatura { get; set; }

        [ForeignKey("IDAsignatura")]
        public virtual Asignatura Asignatura { get; set; }

    }
}
