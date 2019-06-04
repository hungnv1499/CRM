using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outsourcing.Core.Common;
using Outsourcing.Data.Models;
using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Repository;
using Outsourcing.Service.Properties;

namespace Outsourcing.Service
{
    public interface IProductRelationshipService
    {
        IEnumerable<ProductRelationship> GetProductRelationships();
        void CreateProductRelationship(ProductRelationship obj);
        void EditProductRelationship(ProductRelationship obj);
        IEnumerable<ProductRelationship> GetProductById(int id);
        void SaveProductRelationship();

    }
    class ProductRelationshipService :IProductRelationshipService
    {
                #region Field
        private readonly IProductRelationshipRepository productRelationshipRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public ProductRelationshipService(IProductRelationshipRepository productRelationshipRepository, IUnitOfWork unitOfWork)
        {
            this.productRelationshipRepository = productRelationshipRepository;
            this.unitOfWork = unitOfWork;
        }
        #endregion

        public IEnumerable<ProductRelationship> GetProductRelationships()
        {
            return productRelationshipRepository.GetAll().Where(p => p.isAvailable == true);
        }

        public void CreateProductRelationship(ProductRelationship obj)
        {
            productRelationshipRepository.Add(obj);
            SaveProductRelationship();
        }

        public void EditProductRelationship(ProductRelationship obj)
        {
            var item = productRelationshipRepository.GetById(obj.Id);
            item.isAvailable = obj.isAvailable;
            item.ProductId = obj.ProductId;
            item.ProductRelateId = obj.ProductRelateId;
            productRelationshipRepository.Update(item);
            SaveProductRelationship();
        }

        public void SaveProductRelationship()
        {

            try
            {
                unitOfWork.Commit();
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public IEnumerable<ProductRelationship> GetProductById(int id)
        {
            return productRelationshipRepository.GetAll().Where(p => p.ProductId == id);
        }
    }
}
