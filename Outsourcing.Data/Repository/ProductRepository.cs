using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Models;
using System;
using System.Linq.Expressions;
namespace Outsourcing.Data.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
        {
        public ProductRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }        
        }
    public interface IProductRepository : IRepository<Product>
    {
        
    }
}