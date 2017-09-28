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
    public interface IServicioAtencionAdmision
    {
        IEnumerable<AtencionAdmision> GetAll();
        AtencionAdmision Get(int id);
        ComplementoDeRespuesta Delete(int id);
        ComplementoDeRespuesta InsertOrUpdate(AtencionAdmision model);


    }
    public class ServicioAtencionAdmisions : IServicioAtencionAdmision
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<AtencionAdmision> _AtencionAdmisionRepository;
        private readonly IRepository<ApplicationUser> _applicationUser;
        private readonly IRepository<ApplicationRole> _applicationRole;

        public ServicioAtencionAdmisions(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<AtencionAdmision> AtencionAdmisionRepository,
            IRepository<ApplicationUser> applicationUser,
            IRepository<ApplicationRole> applicationRole
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _AtencionAdmisionRepository = AtencionAdmisionRepository;
            _applicationUser = applicationUser;
            _applicationRole = applicationRole;
        }
        /// <summary>
        /// Retorna todas las AtencionAdmisiones
        /// </summary>
        /// <returns></returns>
        #region Obtener todos
        public IEnumerable<AtencionAdmision> GetAll()
        {
            var result = new List<AtencionAdmision>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _AtencionAdmisionRepository.GetAll(x => x.CreatedUser).ToList();

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
        /// Retorna una AtencionAdmision por id
        /// </summary>
        /// <returns></returns>
        #region buscar un registro
        public AtencionAdmision Get(int id)
        {
            var result = new AtencionAdmision();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _AtencionAdmisionRepository.SingleOrDefault(x => x.Id == id);
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
        /// inserta o elimina una AtencionAdmision
        /// </summary>
        /// <returns></returns>
        #region Insertar  o modificar
        public ComplementoDeRespuesta InsertOrUpdate(AtencionAdmision model)
        {
            var rh = new ComplementoDeRespuesta();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.Id == 0)
                    {
                        _AtencionAdmisionRepository.Insert(model);
                    }
                    else
                    {
                        _AtencionAdmisionRepository.Update(model);
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
                    var model = _AtencionAdmisionRepository.Single(x => x.Id == id);
                    _AtencionAdmisionRepository.Delete(model);
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
