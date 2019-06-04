using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsourcing.Data.Repository
{
    public class RoleRepository : RepositoryBase<AspNetRole>, IRolesRepository
    {
        public RoleRepository(IDatabaseFactory databaseFactory)
          : base(databaseFactory)
        {
        }
    }
    public interface IRolesRepository : IRepository<AspNetRole>
    {

    }
}
