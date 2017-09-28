using Model.Auth;
using Model.Dtos;
using NLog;
using Persistence.DbContextScope;
using Persistence.DbContextScope.Extensions;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    /// <summary>
    /// roles
    /// </summary>
    /// <returns></returns>
    public interface IRolService
    {
        IEnumerable<UserForGridView> GetAll(string id);
    }
    public class RolService : IRolService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<ApplicationRole> _applicationRole;
        public RolService(IDbContextScopeFactory dbContextScopeFactory,
            IRepository<ApplicationRole> applicationRole)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _applicationRole = applicationRole;
        }

        /// <summary>
        /// Retorna todos los roles 
        /// todo:no esta asignando  los rones  ausuario
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserForGridView> GetAll(string id)
        {
            var result = new List<UserForGridView>();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {

                    var roles = ctx.GetEntity<ApplicationRole>();
                    var usersPerRoles = ctx.GetEntity<ApplicationUserRole>();

                    var queryUsersPerRoles = (
                        from upr in usersPerRoles
                        from r in roles.Where(x => x.Id == upr.RoleId)
                        select new
                        {
                            upr.UserId,
                            r.Name
                        }
                    ).AsQueryable();

                    
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return result;

        }
    }
}
