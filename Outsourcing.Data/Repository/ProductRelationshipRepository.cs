using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Models;
using System;
using System.Linq.Expressions;

namespace Outsourcing.Data.Repository
{

    public class ProductRelationshipRepository : RepositoryBase<ProductRelationship>, IProductRelationshipRepository
    {
        public ProductRelationshipRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IProductRelationshipRepository : IRepository<ProductRelationship>
    {

    }
}
