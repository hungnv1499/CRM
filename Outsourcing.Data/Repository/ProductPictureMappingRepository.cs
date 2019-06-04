using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Models;
using System;
using System.Linq.Expressions;
namespace Outsourcing.Data.Repository
{
    public class ProductPictureMappingRepository : RepositoryBase<ProductPictureMapping>, IProductPictureMappingRepository
        {
        public ProductPictureMappingRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }        
        }
    public interface IProductPictureMappingRepository : IRepository<ProductPictureMapping>
    {
        
    }
}