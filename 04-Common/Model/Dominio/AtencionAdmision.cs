using Common;
using Common.IdentidadPersonalizada;
using Model.Complementos;
using System;
using System.Collections.Generic;
using static Common.Enums;

namespace Model.Dominio
{
    public class AtencionAdmision: AuditoriaEntidad, ISoftDeleted, EntidadBase
    {
        
        public int Id { get; set; }

        public DateTime FechaAtencion { get; set; }
         
        public ECalificacionAtencion Calificacion { get; set; }//calificacion del medico
        public EEstadoAtencion Estado { get; set; }// entregado pendiente
        public string Local { get; set; }
        public int? PerfilId { get; set; }
        public Perfil Perfil { get; set; }
        public int? ExamenId { get; set; }
        public Examen Examen { get; set; }
        public int? TipoExamenOcupacionalId { get; set; }
        public TipoExamenOcupacional TipoExamenOcupacional { get; set; }
        public int? PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int? EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public bool Deleted { get; set; }
    }
}
