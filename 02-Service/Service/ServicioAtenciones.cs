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
    public interface IServicioAtenciones
    {
        IEnumerable<Atencion> GetAll();
        Atencion Get(int id);
        ComplementoDeRespuesta InsertOrUpdate(Atencion model);
        ComplementoDeRespuesta Delete(int id);
    }

    public class ServicioAtenciones : IServicioAtenciones
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Atencion> _AtencionRepository;
        private readonly IRepository<ApplicationUser> _applicationUser;
        private readonly IRepository<ApplicationRole> _applicationRole;

        public ServicioAtenciones(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Atencion> AtencionRepository,
            IRepository<ApplicationUser> applicationUser,
            IRepository<ApplicationRole> applicationRole
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _AtencionRepository = AtencionRepository;
            _applicationUser = applicationUser;
            _applicationRole = applicationRole;
        }

        /// <summary>
        /// Retorna todas las Atenciones
        /// </summary>
        /// <returns></returns>
        #region Obtener todos
        public IEnumerable<Atencion> GetAll()
        {
            var result = new List<Atencion>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _AtencionRepository.GetAll(x => x.CreatedUser).ToList();

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
        /// Retorna una Atencion por id
        /// </summary>
        /// <returns></returns>
        #region buscar un registro
        public Atencion Get(int id)
        {
            var result = new Atencion();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _AtencionRepository.SingleOrDefault(x => x.Id == id);
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
        /// inserta o elimina una Atencion
        /// </summary>
        /// <returns></returns>
        #region Insertar  o modificar
        public ComplementoDeRespuesta InsertOrUpdate(Atencion model)
        {
            var rh = new ComplementoDeRespuesta();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.Id == 0)
                    {
                        _AtencionRepository.Insert(model);
                    }
                    else
                    {
                        _AtencionRepository.Update(model);
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
                    var model = _AtencionRepository.Single(x => x.Id == id);
                    _AtencionRepository.Delete(model);
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
