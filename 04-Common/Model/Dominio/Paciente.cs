using Common;
using Common.IdentidadPersonalizada;
using Model.Complementos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Dominio
{
    public class Paciente:  Persona, ISoftDeleted, EntidadBase
    {
        public Paciente()
        {
            AtencionesAdmision= new HashSet<AtencionAdmision>();
        }
        public int Id { get; set; }
        [StringLength(45)]
        public string AreaTrabajo { get; set; }
        public int? HistoriaClinica { get; set; }
        
        public ICollection<AtencionAdmision> AtencionesAdmision{ get; set; }
        public bool Deleted { get; set; }
    }
}
