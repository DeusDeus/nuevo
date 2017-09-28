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
    public interface IServicioPerfiles
    {
        IEnumerable<Perfil> GetAll();
        Perfil Get(int id);
        ComplementoDeRespuesta Delete(int id);
        ComplementoDeRespuesta InsertOrUpdate(Perfil model);


    }
    public class ServicioPerfiles : IServicioPerfiles
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Perfil> _PerfilRepository;
        private readonly IRepository<ApplicationUser> _applicationUser;
        private readonly IRepository<ApplicationRole> _applicationRole;

        public ServicioPerfiles(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Perfil> PerfilRepository,
            IRepository<ApplicationUser> applicationUser,
            IRepository<ApplicationRole> applicationRole
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _PerfilRepository = PerfilRepository;
            _applicationUser = applicationUser;
            _applicationRole = applicationRole;
        }
        /// <summary>
        /// Retorna todas los Perfiles
        /// </summary>
        /// <returns></returns>
        #region Obtener todos
        public IEnumerable<Perfil> GetAll()
        {
            var result = new List<Perfil>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _PerfilRepository.GetAll(x => x.CreatedUser).ToList();

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
        /// Retorna un Perfil por id
        /// </summary>
        /// <returns></returns>
        #region buscar un registro
        public Perfil Get(int id)
        {
            var result = new Perfil();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _PerfilRepository.SingleOrDefault(x => x.Id == id);
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
        /// inserta o elimina una Perfil
        /// </summary>
        /// <returns></returns>
        #region Insertar  o modificar
        public ComplementoDeRespuesta InsertOrUpdate(Perfil model)
        {
            var rh = new ComplementoDeRespuesta();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.Id == 0)
                    {
                        _PerfilRepository.Insert(model);
                    }
                    else
                    {
                        _PerfilRepository.Update(model);
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
                    var model = _PerfilRepository.Single(x => x.Id == id);
                    _PerfilRepository.Delete(model);
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