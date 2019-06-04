using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Models;
using System;
using System.Linq.Expressions;
namespace Outsourcing.Data.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
        {
        public OrderRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }        
        }
    public interface IOrderRepository : IRepository<Order>
    {
        
    }
}