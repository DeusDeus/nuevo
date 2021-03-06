﻿using Common;
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
    public interface IServicioEspecialidadMedicas
    {
        IEnumerable<EspecialidadMedica> GetAll();
        EspecialidadMedica Get(int id);
        ComplementoDeRespuesta Delete(int id);
        ComplementoDeRespuesta InsertOrUpdate(EspecialidadMedica model);


    }
    public class ServicioEspecialidadMedicas : IServicioEspecialidadMedicas
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<EspecialidadMedica> _EspecialidadMedicaRepository;
        private readonly IRepository<ApplicationUser> _applicationUser;
        private readonly IRepository<ApplicationRole> _applicationRole;

        public ServicioEspecialidadMedicas(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<EspecialidadMedica> EspecialidadMedicaRepository,
            IRepository<ApplicationUser> applicationUser,
            IRepository<ApplicationRole> applicationRole
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _EspecialidadMedicaRepository = EspecialidadMedicaRepository;
            _applicationUser = applicationUser;
            _applicationRole = applicationRole;
        }
        /// <summary>
        /// Retorna todas las EspecialidadMedicas
        /// </summary>
        /// <returns></returns>
        #region Obtener todos
        public IEnumerable<EspecialidadMedica> GetAll()
        {
            var result = new List<EspecialidadMedica>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _EspecialidadMedicaRepository.GetAll(x => x.CreatedUser).ToList();

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
        /// Retorna una EspecialidadMedica por id
        /// </summary>
        /// <returns></returns>
        #region buscar un registro
        public EspecialidadMedica Get(int id)
        {
            var result = new EspecialidadMedica();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _EspecialidadMedicaRepository.SingleOrDefault(x => x.Id == id);
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
        /// inserta o elimina una EspecialidadMedica
        /// </summary>
        /// <returns></returns>
        #region Insertar  o modificar
        public ComplementoDeRespuesta InsertOrUpdate(EspecialidadMedica model)
        {
            var rh = new ComplementoDeRespuesta();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.Id == 0)
                    {
                        _EspecialidadMedicaRepository.Insert(model);
                    }
                    else
                    {
                        _EspecialidadMedicaRepository.Update(model);
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
                    var model = _EspecialidadMedicaRepository.Single(x => x.Id == id);
                    _EspecialidadMedicaRepository.Delete(model);
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
