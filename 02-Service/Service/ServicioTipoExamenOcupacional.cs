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
    public interface IServicioTipoExamenOcupacionales
    {
        IEnumerable<TipoExamenOcupacional> GetAll();
        TipoExamenOcupacional Get(int id);
        ComplementoDeRespuesta Delete(int id);
        ComplementoDeRespuesta InsertOrUpdate(TipoExamenOcupacional model);


    }
    public class ServicioTipoExamenOcupacionales : IServicioTipoExamenOcupacionales
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<TipoExamenOcupacional> _TipoExamenOcupacionalRepository;
        private readonly IRepository<ApplicationUser> _applicationUser;
        private readonly IRepository<ApplicationRole> _applicationRole;

        public ServicioTipoExamenOcupacionales(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<TipoExamenOcupacional> TipoExamenOcupacionalRepository,
            IRepository<ApplicationUser> applicationUser,
            IRepository<ApplicationRole> applicationRole
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _TipoExamenOcupacionalRepository = TipoExamenOcupacionalRepository;
            _applicationUser = applicationUser;
            _applicationRole = applicationRole;
        }
        /// <summary>
        /// Retorna todas las TipoExamenOcupacionales
        /// </summary>
        /// <returns></returns>
        #region Obtener todos
        public IEnumerable<TipoExamenOcupacional> GetAll()
        {
            var result = new List<TipoExamenOcupacional>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _TipoExamenOcupacionalRepository.GetAll(x => x.CreatedUser).ToList();

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
        /// Retorna una TipoExamenOcupacional por id
        /// </summary>
        /// <returns></returns>
        #region buscar un registro
        public TipoExamenOcupacional Get(int id)
        {
            var result = new TipoExamenOcupacional();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _TipoExamenOcupacionalRepository.SingleOrDefault(x => x.Id == id);
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
        /// inserta o elimina una TipoExamenOcupacional
        /// </summary>
        /// <returns></returns>
        #region Insertar  o modificar
        public ComplementoDeRespuesta InsertOrUpdate(TipoExamenOcupacional model)
        {
            var rh = new ComplementoDeRespuesta();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.Id == 0)
                    {
                        _TipoExamenOcupacionalRepository.Insert(model);
                    }
                    else
                    {
                        _TipoExamenOcupacionalRepository.Update(model);
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
                    var model = _TipoExamenOcupacionalRepository.Single(x => x.Id == id);
                    _TipoExamenOcupacionalRepository.Delete(model);
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