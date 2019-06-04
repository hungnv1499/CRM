using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Models;
using System;
using System.Linq.Expressions;
namespace Outsourcing.Data.Repository
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
        {
        public ProductCategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }        
        }
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        
    }
}