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
    public interface IProductAttributeMappingService
    {

        IEnumerable<ProductAttributeMapping> GetProductAttributeMappings();
        ProductAttributeMapping GetProductAttributeMappingById(int productAttributeMappingId);
        void CreateProductAttributeMapping(ProductAttributeMapping productAttributeMapping);
        void EditProductAttributeMapping(ProductAttributeMapping productAttributeMappingToEdit);
        void DeleteProductAttributeMapping(int productAttributeMappingId);
        void SaveProductAttributeMapping();
        IEnumerable<ValidationResult> CanAddProductAttributeMapping(ProductAttributeMapping productAttributeMapping);

    }
    public class ProductAttributeMappingService : IProductAttributeMappingService
    {
        #region Field
        private readonly IProductAttributeMappingRepository productAttributeMappingRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public ProductAttributeMappingService(IProductAttributeMappingRepository productAttributeMappingRepository, IUnitOfWork unitOfWork)
        {
            this.productAttributeMappingRepository = productAttributeMappingRepository;
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region BaseMethod

        public IEnumerable<ProductAttributeMapping> GetProductAttributeMappings()
        {
            var productAttributeMappings = productAttributeMappingRepository.GetAll();
            return productAttributeMappings;
        }

        public ProductAttributeMapping GetProductAttributeMappingById(int productAttributeMappingId)
        {
            var productAttributeMapping = productAttributeMappingRepository.GetById(productAttributeMappingId);
            return productAttributeMapping;
        }

        public void CreateProductAttributeMapping(ProductAttributeMapping productAttributeMapping)
        {
            productAttributeMappingRepository.Add(productAttributeMapping);
            SaveProductAttributeMapping();
        }

        public void EditProductAttributeMapping(ProductAttributeMapping productAttributeMappingToEdit)
        {
            productAttributeMappingRepository.Update(productAttributeMappingToEdit);
            SaveProductAttributeMapping();
        }

        public void DeleteProductAttributeMapping(int productAttributeMappingId)
        {
            //Get productAttributeMapping by id.
            var productAttributeMapping = productAttributeMappingRepository.GetById(productAttributeMappingId);
            if (productAttributeMapping != null)
            {
                productAttributeMappingRepository.Delete(productAttributeMapping);
                SaveProductAttributeMapping();
            }
        }

        public void SaveProductAttributeMapping()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<ValidationResult> CanAddProductAttributeMapping(ProductAttributeMapping productAttributeMapping)
        {
        
            //    yield return new ValidationResult("ProductAttributeMapping", "ErrorString");
            return null;
        }

        #endregion
    }
}
