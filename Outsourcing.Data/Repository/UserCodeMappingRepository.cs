using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Models;
using System;
using System.Linq.Expressions;


namespace Outsourcing.Data.Repository
{
    public class UserDataMappingRepository : RepositoryBase<UserDataMapping>, IUserDataMappingRepository
    {
        public UserDataMappingRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IUserDataMappingRepository : IRepository<UserDataMapping>
    {

    }


}
