using Common;
using Model.Auth;
using Model.Dominio;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IServicioEmpresas
    {
        IEnumerable<Empresa> GetAll();
        Empresa Get(int id);
        ComplementoDeRespuesta Delete(int id);
        ComplementoDeRespuesta InsertOrUpdate(Empresa model);


    }
    public class ServicioEmpresas: IServicioEmpresas
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Empresa> _EmpresaRepository;
        private readonly IRepository<ApplicationUser> _applicationUser;
        private readonly IRepository<ApplicationRole> _applicationRole;

        public ServicioEmpresas(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Empresa> EmpresaRepository,
            IRepository<ApplicationUser> applicationUser,
            IRepository<ApplicationRole> applicationRole
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _EmpresaRepository = EmpresaRepository;
            _applicationUser = applicationUser;
            _applicationRole = applicationRole;
        }
        /// <summary>
        /// Retorna todas las empresas
        /// </summary>
        /// <returns></returns>
        #region Obtener todos
        public IEnumerable<Empresa> GetAll()
        {
            var result = new List<Empresa>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _EmpresaRepository.GetAll(x => x.CreatedUser).ToList();

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
        /// Retorna una empresa por id
        /// </summary>
        /// <returns></returns>
        #region buscar un registro
        public Empresa Get(int id)
        {
            var result = new Empresa();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    result = _EmpresaRepository.SingleOrDefault(x => x.Id == id);
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
        /// inserta o elimina una empresa
        /// </summary>
        /// <returns></returns>
        #region Insertar  o modificar
        public ComplementoDeRespuesta InsertOrUpdate(Empresa model)
        {
            var rh = new ComplementoDeRespuesta();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.Id == 0)
                    {
                        _EmpresaRepository.Insert(model);
                    }
                    else
                    {
                        _EmpresaRepository.Update(model);
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
                    var model = _EmpresaRepository.Single(x => x.Id == id);
                    _EmpresaRepository.Delete(model);
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
