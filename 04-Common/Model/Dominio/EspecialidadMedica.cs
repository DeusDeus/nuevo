using Common;
using Common.IdentidadPersonalizada;
using Model.Complementos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Dominio
{
    public class EspecialidadMedica : AuditoriaEntidad, ISoftDeleted, EntidadBase
    {
        public EspecialidadMedica()
        {
            Perfiles = new HashSet<Perfil>();
            Medicos= new HashSet<Medico>();
        }
        public int Id { get; set; }
        [StringLength(45)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }
        public ICollection<Perfil> Perfiles { get; set; }
        public ICollection<Medico> Medicos { get; set; }
        public bool Deleted { get; set; }
    }
}
