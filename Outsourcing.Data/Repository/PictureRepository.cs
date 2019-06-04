using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Models;
using System;
using System.Linq.Expressions;
namespace Outsourcing.Data.Repository
{
    public class PictureRepository : RepositoryBase<Picture>, IPictureRepository
    {
        public PictureRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IPictureRepository : IRepository<Picture>
    {

    }
}
