using Common;
using Model.Dominio;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;

namespace Service
{
    public interface IStudentPerCourseService
    {
        ComplementoDeRespuesta Insert(StudentPerCourse model);
    }

    public class StudentPerCourseService : IStudentPerCourseService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<StudentPerCourse> _studentPerCourseRepository;

        public StudentPerCourseService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<StudentPerCourse> studentPerCourseRepository
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _studentPerCourseRepository = studentPerCourseRepository;
        }

        public ComplementoDeRespuesta Insert(StudentPerCourse model)
        {
            var rh = new ComplementoDeRespuesta();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    _studentPerCourseRepository.Insert(model);

                    ctx.SaveChanges();
                    rh.SetRespuesta(true);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return rh;
        }
    }
}
