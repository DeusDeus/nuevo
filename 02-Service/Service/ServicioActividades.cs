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
using System.Web.Mvc;

namespace Service
{
    /// <summary>
    /// Logica para las activiades
    /// </summary>
    /// <returns></returns>
    public interface IServicioActividades
    {
        IEnumerable<Actividad> GetAll();
        Actividad Get(int id);
        ComplementoDeRespuesta create(ActividadDto model);
        ComplementoDeRespuesta Delete(int id);
    }
    public class ServicioActividades : IServicioActividades
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Actividad> _actividadRepository;
        private readonly IRepository<ApplicationUser> _applicationUser;
        private readonly IRepository<ApplicationRole> _applicationRole;
        public ServicioActividades(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Actividad> actividadRepository,
            IRepository<ApplicationUser> applicationUser,
            IRepository<ApplicationRole> applicationRole
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _actividadRepository = actividadRepository;
            _applicationUser = applicationUser;
            _applicationRole = applicationRole;
        }
        //
        /// <summary>
        /// Retorna todas las actividades
        /// </summary>
        /// <returns></returns>
        #region Obtener todos
        //public IEnumerable<ActividadDto> GetAll()
        //{
        //    var result = new List<ActividadDto>();

        //    try
        //    {
        //        using (var ctx = _dbContextScopeFactory.CreateReadOnly())
        //        {
        //            result = _actividadRepository.GetAll(x => x.Empresa, x => x.CreatedUser)
        //                .Select(x => new ActividadDto
        //            {
        //                IdActividad = x.Id,
        //                Descripcion = x.Descripcion,
        //                FechaInicial = x.FechaInicial,
        //                idtipexam = x.TipoExamenOcupacionalId,
        //                IdEmpresa = x.EmpresaId,
        //                CreatedBy=x.CreatedUser.UserName
        //            }
        //            ).ToList();

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        logger.Error(e.Message);
        //    }

        //    return result;

        //}
        public IEnumerable<Actividad> GetAll()
        {
            var result = new List<Actividad>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _actividadRepository.GetAll(x => x.CreatedUser).ToList();

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
        /// Retorna una actividad por su id
        /// </summary>
        /// <returns></returns>
       #region buscar un registro
        public Actividad Get(int id)
        {
            var result = new Actividad();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _actividadRepository.SingleOrDefault(x => x.Id == id);
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
        /// Inserta  o actualiza la tabla de actividades
        /// </summary>
        /// <returns></returns>
        #region Inserta
        public ComplementoDeRespuesta create(ActividadDto model)
        {
            var rh = new ComplementoDeRespuesta();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                     Actividad actividad = new Actividad();

                    actividad.Id = model.IdActividad;
                    actividad.FechaInicial = model.FechaInicial;
                    actividad.FechaFinal = model.FechaInicial;
                    actividad.FechaInicialPlan = model.FechaInicial;
                    actividad.FechaFinalPlan = model.FechaInicial;
                    actividad.EmpresaId = model.IdEmpresa;
                    actividad.TipoExamenOcupacionalId = model.IdActividad;
                    actividad.Descripcion = model.Descripcion;
                    actividad.Estado = 0;
                    _actividadRepository.Insert(actividad);
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
        /// eliminacion logica de actividad por  id
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
                    var model = _actividadRepository.SingleOrDefault(x => x.Id == id);
                    _actividadRepository.Delete(model);

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
