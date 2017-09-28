using Common;
using Common.IdentidadPersonalizada;
using Model.Complementos;
using System;
using System.Collections.Generic;

namespace Model.Dominio
{
    public class Atencion : AuditoriaEntidad, ISoftDeleted, EntidadBase
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        // formulario de atencion  7c
    }
}
