using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Models;
using System;
using System.Linq.Expressions;
namespace Outsourcing.Data.Repository
{
    public class ProductAttributeMappingRepository : RepositoryBase<ProductAttributeMapping>, IProductAttributeMappingRepository
        {
        public ProductAttributeMappingRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }        
        }
    public interface IProductAttributeMappingRepository : IRepository<ProductAttributeMapping>
    {
        
    }
}