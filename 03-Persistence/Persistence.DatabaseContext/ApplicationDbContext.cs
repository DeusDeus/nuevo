using Microsoft.AspNet.Identity.EntityFramework;
using Common;
using System.Data.Entity;
using Model.Dominio;
using System.Reflection;
using System.Linq;
using Model.Complementos;
using System;
using EntityFramework.DynamicFilters;
using Common.IdentidadPersonalizada;
using Model.Auth;

namespace Persistence.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }

        public virtual DbSet<Student> Student { get;set; }
        public virtual DbSet<StudentPerCourse> StudentPerCourse { get; set; }
        public virtual DbSet<Course> Course { get; set; }

        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<AtencionAdmision> AtencionesAdmision { get; set; }
        public DbSet<Campania> Campanias { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EspecialidadMedica> EspecialidadesMedicas { get; set; }
        public DbSet<Examen> Examenes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<TipoExamenOcupacional> TiposExamenesOcupacionales { get; set; }
        public DbSet<Atencion> Atenciones { get; set; }
        public ApplicationDbContext()
            : base(string.Format("name={0}", Parametros.AppContext))
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            IdentidadPersonalizada(ref modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)));

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            HacerAuditoria();
            return base.SaveChanges();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        private void HacerAuditoria()
        {
            var EntityModificada = ChangeTracker.Entries().Where(
                x => x.Entity is AuditoriaEntidad
                    && (
                    x.State == EntityState.Added
                    || x.State == EntityState.Modified
                    || x.State == EntityState.Deleted
                )
            );

            foreach (var entry in EntityModificada)
            {
                var entity = entry.Entity as AuditoriaEntidad;
                if (entity != null)
                {
                    var date = DateTime.Now;
                    var userId = UsuarioActualComplementos.Get != null ? UsuarioActualComplementos.Get.UserId : null;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = date;
                        entity.CreatedBy = userId;
                    }
                    else if (entity is ISoftDeleted && ((ISoftDeleted)entity).Deleted)
                    {
                        entity.DeletedAt = date;
                        entity.DeletedBy = userId;
                    }

                    Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                    Entry(entity).Property(x => x.CreatedBy).IsModified = false;

                    entity.UpdatedAt = date;
                    entity.UpdatedBy = userId;
                }
            }
        }

        private void IdentidadPersonalizada(ref DbModelBuilder modelBuilder)
        {
            modelBuilder.Filter(Enums.MyFilters.IsDeleted.ToString(), (ISoftDeleted ea) => ea.Deleted, false);
        }
    }
}
