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
    public interface IServicioCampanias
    {
        IEnumerable<Campania> GetAll();
        Campania Get(int id);
        ComplementoDeRespuesta Delete(int id);
        ComplementoDeRespuesta InsertOrUpdate(Campania model);


    }
    public class ServicioCampanias : IServicioCampanias
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Campania> _CampaniaRepository;
        private readonly IRepository<ApplicationUser> _applicationUser;
        private readonly IRepository<ApplicationRole> _applicationRole;

        public ServicioCampanias(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Campania> CampaniaRepository,
            IRepository<ApplicationUser> applicationUser,
            IRepository<ApplicationRole> applicationRole
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _CampaniaRepository = CampaniaRepository;
            _applicationUser = applicationUser;
            _applicationRole = applicationRole;
        }
        /// <summary>
        /// Retorna todas las Campanias
        /// </summary>
        /// <returns></returns>
        #region Obtener todos
        public IEnumerable<Campania> GetAll()
        {
            var result = new List<Campania>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _CampaniaRepository.GetAll(x => x.CreatedUser).ToList();

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
        /// Retorna una Campania por id
        /// </summary>
        /// <returns></returns>
        #region buscar un registro
        public Campania Get(int id)
        {
            var result = new Campania();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _CampaniaRepository.SingleOrDefault(x => x.Id == id);
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
        /// inserta o elimina una Campania
        /// </summary>
        /// <returns></returns>
        #region Insertar  o modificar
        public ComplementoDeRespuesta InsertOrUpdate(Campania model)
        {
            var rh = new ComplementoDeRespuesta();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.Id == 0)
                    {
                        //Campania campania = new Campania();
                        //campania.Nombre = campaniavm.Nombre;
                        //campania.Fecha = campaniavm.Fecha;
                        //campania.FechaPlan = campaniavm.Fecha;
                        //campania.Publicada = false;
                        //if (campaniavm.IncluyeProspectos)
                        //{
                        //    var prospectos = (from c in db.Clientes
                        //                      where c.TipoClienteId == 1
                        //                      select c).ToList();
                        //    foreach (var item in prospectos)
                        //    {
                        //        campania.Actividades.Add(new Actividad
                        //        {
                        //            ClienteId = item.ClienteId,
                        //            FechaFinal = campania.Fecha.AddDays(-15),
                        //            FechaFinalPlan = campania.Fecha.AddDays(-15),
                        //            FechaInicial = campania.Fecha.AddDays(-15),
                        //            FechaInicialPlan = campania.Fecha.AddDays(-15),
                        //            Descripcion = "Llamar por telefono al cliente para la campaña " + campania.Nombre,
                        //            TipoActividadId = 6,
                        //            Estado = 0
                        //        });
                        //    }
                        //}

                        _CampaniaRepository.Insert(model);
                    }
                    else
                    {
                        _CampaniaRepository.Update(model);
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
                    var model = _CampaniaRepository.Single(x => x.Id == id);
                    _CampaniaRepository.Delete(model);
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
