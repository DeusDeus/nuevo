using LightInject;
using Model.Auth;
using Model.Dominio;
using Persistence.DbContextScope;
using Persistence.Repository;

namespace Service.Config
{
    //para usar   inyeccion de dependencia  y que todas las  interfaces esten disponibles en el proyecto
    public class ServiceRegister : ICompositionRoot
    {               
        public void Compose(IServiceRegistry container)
        {
            var ambientDbContextLocator = new AmbientDbContextLocator();

            container.Register<IDbContextScopeFactory>((x) => new DbContextScopeFactory(null));
            container.Register<IAmbientDbContextLocator, AmbientDbContextLocator>(new PerScopeLifetime());

            container.Register<IRepository<ApplicationUser>>((x) => new Repository<ApplicationUser>(ambientDbContextLocator));
            container.Register<IRepository<ApplicationRole>>((x) => new Repository<ApplicationRole>(ambientDbContextLocator));
            container.Register<IRepository<Course>>((x) => new Repository<Course>(ambientDbContextLocator));
            container.Register<IRepository<Student>>((x) => new Repository<Student>(ambientDbContextLocator));
            container.Register<IRepository<StudentPerCourse>>((x) => new Repository<StudentPerCourse>(ambientDbContextLocator));
            container.Register<IRepository<Empresa>>((x) => new Repository<Empresa>(ambientDbContextLocator));
            container.Register<IRepository<Actividad>>((x) => new Repository<Actividad>(ambientDbContextLocator));
            container.Register<IRepository<Atencion>>((x) => new Repository<Atencion>(ambientDbContextLocator));
            container.Register<IRepository<AtencionAdmision>>((x) => new Repository<AtencionAdmision>(ambientDbContextLocator));
            container.Register<IRepository<Campania>>((x) => new Repository<Campania>(ambientDbContextLocator));
            container.Register<IRepository<EspecialidadMedica>>((x) => new Repository<EspecialidadMedica>(ambientDbContextLocator));
            container.Register<IRepository<Examen>>((x) => new Repository<Examen>(ambientDbContextLocator));
            container.Register<IRepository<Medico>>((x) => new Repository<Medico>(ambientDbContextLocator));
            container.Register<IRepository<Paciente>>((x) => new Repository<Paciente>(ambientDbContextLocator));
            container.Register<IRepository<Perfil>>((x) => new Repository<Perfil>(ambientDbContextLocator));
            container.Register<IRepository<TipoExamenOcupacional>>((x) => new Repository<TipoExamenOcupacional>(ambientDbContextLocator));



            container.Register<IServicioTipoExamenOcupacionales, ServicioTipoExamenOcupacionales>();
            container.Register<IServicioPerfiles, ServicioPerfiles>();
            container.Register<IServicioPacientes, ServicioPacientes>();
            container.Register<IServicioMedicos, ServicioMedicos>();
            container.Register<IServicioExamenes, ServicioExamenes>();
            container.Register<IServicioEspecialidadMedicas, ServicioEspecialidadMedicas>();
            container.Register<IServicioCampanias, ServicioCampanias>();
            container.Register<IServicioAtencionAdmision, ServicioAtencionAdmisions>();
            container.Register<IServicioActividades, ServicioActividades>();
            container.Register<IServicioEmpresas, ServicioEmpresas>();
            container.Register<IStudentService, StudentService>();
            container.Register<IStudentPerCourseService, StudentPerCourseService>();
            container.Register<ICourseService, CourseService>();
            container.Register<IUserService, UserService>();
            container.Register<IRolService, RolService>();
        }
    }
}
