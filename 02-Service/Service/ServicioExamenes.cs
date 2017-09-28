using Common;
using Model.Auth;
using Model.Dtos;
using Model.Dominio;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IServicioExamenes
    {
        IEnumerable<Examen> GetAll();
        Examen Get(int id);
        ComplementoDeRespuesta Delete(int id);
        ComplementoDeRespuesta InsertOrUpdate(Examen model);


    }
    public class ServicioExamenes : IServicioExamenes
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Examen> _ExamenRepository;
        private readonly IRepository<ApplicationUser> _applicationUser;
        private readonly IRepository<ApplicationRole> _applicationRole;

        public ServicioExamenes(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Examen> ExamenRepository,
            IRepository<ApplicationUser> applicationUser,
            IRepository<ApplicationRole> applicationRole
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _ExamenRepository = ExamenRepository;
            _applicationUser = applicationUser;
            _applicationRole = applicationRole;
        }
        /// <summary>
        /// Retorna todas los Examenes
        /// </summary>
        /// <returns></returns>
        #region Obtener todos
        public IEnumerable<Examen> GetAll()
        {
            var result = new List<Examen>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _ExamenRepository.GetAll(x => x.CreatedUser).ToList();

                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;

        }
        #endregion

        /// <summary>
        /// Retorna una Examen por id
        /// </summary>
        /// <returns></returns>
        #region buscar un registro
        public Examen Get(int id)
        {
            var result = new Examen();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _ExamenRepository.SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }
        #endregion

        /// <summary>
        /// inserta o elimina una Examen
        /// </summary>
        /// <returns></returns>
        #region Insertar  o modificar
        public ComplementoDeRespuesta InsertOrUpdate(Examen model)
        {
            var rh = new ComplementoDeRespuesta();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.Id == 0)
                    {
                        _ExamenRepository.Insert(model);
                    }
                    else
                    {
                        _ExamenRepository.Update(model);
                    }

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
        #endregion

        /// <summary>
        /// eliminacion logica 
        /// </summary>
        /// <returns></returns>
        #region Eliminar
        public ComplementoDeRespuesta Delete(int id)
        {
            var rh = new ComplementoDeRespuesta();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _ExamenRepository.Single(x => x.Id == id);
                    _ExamenRepository.Delete(model);
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


        #endregion

    }
}

