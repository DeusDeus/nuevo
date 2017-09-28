using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos
{
   public class ActividadDto
    {
        public int IdActividad { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaInicial { get; set; }

        public int idtipexam { get; set; }

        public int IdEmpresa { get; set; }

        public string nombre { get; set; }

        public string NombreTipo { get; set; }

        public string Telefono { get; set; }

        public string Emails { get; set; }

        public String CreatedBy { get; set; }
    }
}
