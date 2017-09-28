using Common;
using Common.IdentidadPersonalizada;
using Model.Complementos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Dominio
{
    public class TipoExamenOcupacional : AuditoriaEntidad,ISoftDeleted,EntidadBase
    {
        public TipoExamenOcupacional()
        {
            Actividades = new HashSet<Actividad>();
            AtencionesAdminision = new HashSet<AtencionAdmision>();
        }
        public int Id { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
        public virtual ICollection<Actividad> Actividades { get; set; }
        public virtual ICollection<AtencionAdmision> AtencionesAdminision{ get; set; }
        public bool Deleted { get; set; }

    }
}
