using Common;
using Common.IdentidadPersonalizada;
using Model.Complementos;
using System;
using System.Collections.Generic;

namespace Model.Dominio
{
    public class Campania : AuditoriaEntidad, ISoftDeleted,EntidadBase
    {
        public Campania()
        {
            Actividades = new HashSet<Actividad>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaPlan { get; set; }
        public DateTime Fecha { get; set; }
        public bool Publicada { get; set; }
        public virtual ICollection<Actividad> Actividades { get; set; }
        public bool Deleted { get; set; }

       
    }
}
