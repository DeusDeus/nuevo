using Common;
using Common.IdentidadPersonalizada;
using Model.Complementos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Dominio
{
    public class Medico : Persona, ISoftDeleted, EntidadBase
    {
        public int Id { get; set; }
        [StringLength(45)]
        public string RegistroCmp { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int EspecialidadId { get; set; }
        public EspecialidadMedica Especialidad { get; set; }
        public bool Deleted { get; set; }
    }
}
