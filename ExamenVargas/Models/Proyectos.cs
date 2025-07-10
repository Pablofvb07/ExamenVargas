using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ExamenVargas.Models
{
    public class Proyectos
    {
        public int id { get; set; }
        public string NombreProyecto { get; set; }
        public string Responsable { get; set; }
        public decimal Progreso { get; set; }
        public int DuracionDias { get;set; }
    }
}
