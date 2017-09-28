using Common;
using Common.IdentidadPersonalizada;
using Model.Complementos;
using System;
using System.Collections.Generic;

namespace Model.Dominio
{
    public class Student : AuditoriaEntidad, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public Enums.Genero Genre { get; set; }
        public Enums.Status CurrentStatus { get; set; }
        public DateTime? LastVisit { get; set; }

        public ICollection<StudentPerCourse> StudentPerCourses { get; set; }

        public bool Deleted { get; set; } 
    }
}
