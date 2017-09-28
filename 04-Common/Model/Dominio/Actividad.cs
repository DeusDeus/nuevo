using Common;
using Common.IdentidadPersonalizada;
using Model.Complementos;
using System;
using System.Collections.Generic;

namespace Model.Dominio
{
    public class Actividad: AuditoriaEntidad, ISoftDeleted,EntidadBase
    {


        public int Id { get; set; }
        public string Descripcion { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public DateTime FechaInicialPlan { get; set; }

        public DateTime FechaFinalPlan { get; set; }

        public int Estado { get; set; } 

        public int? CampaniaId { get; set; }
        public Campania Campania { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; } 
        public int TipoExamenOcupacionalId { get; set; }
        public TipoExamenOcupacional TipoExamenOcupacional { get; set; }
        public bool Deleted { get; set; }

    }
}
