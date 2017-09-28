using Common;
using Common.IdentidadPersonalizada;
using Model.Complementos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Dominio
{
    public class Perfil : AuditoriaEntidad, ISoftDeleted, EntidadBase
    {

        public Perfil()
        {
            AtencionesAdmision = new HashSet<AtencionAdmision>();
            Examenes = new HashSet<Examen>();
        }
        public int Id { get; set; }
        [StringLength(45)]
        public string NombrePerfil { get; set; }
        public double Costo { get; set; }
        [StringLength(45)]
        public string Estado { get; set; }
      
        public ICollection<AtencionAdmision> AtencionesAdmision { get; set; } 
        public ICollection<Examen> Examenes { get; set; }
        public bool Deleted { get; set; }
    }
}
