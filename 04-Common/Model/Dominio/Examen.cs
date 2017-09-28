using Common;
using Common.IdentidadPersonalizada;
using Model.Complementos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Dominio
{
    public partial class Examen : AuditoriaEntidad, ISoftDeleted, EntidadBase
    { 
        public Examen()
        {
            AtencionesAdmision= new HashSet<AtencionAdmision>();
            Perfil = new HashSet<Perfil>();
        }
         public int Id { get; set; }
        [StringLength(45)]
        public string NombreExamen { get; set; }
        public double Costo { get; set; }
        [StringLength(45)]
        public string Recomendaciones { get; set; }
        public int EspecialidadId { get; set; }
        public EspecialidadMedica Especialidad { get; set; }
        public ICollection<AtencionAdmision> AtencionesAdmision{ get; set; }
        public virtual ICollection<Perfil> Perfil { get; set; }
        public bool Deleted { get; set; }
    }
}
