using Common.IdentidadPersonalizada;
using Model.Complementos;
using System.Collections.Generic;

namespace Model.Dominio
{
    public class Course : AuditoriaEntidad, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<StudentPerCourse> StudentPerCourses { get; set; }

        public bool Deleted { get; set; }
    }
}
