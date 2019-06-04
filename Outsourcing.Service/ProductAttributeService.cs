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
    public interface IProductAttributeService
    {

        IEnumerable<ProductAttribute> GetProductAttributes();
        ProductAttribute GetProductAttributeById(int productAttributeId);
        void CreateProductAttribute(ProductAttribute productAttribute);
        void EditProductAttribute(ProductAttribute productAttributeToEdit);
        void DeleteProductAttribute(int productAttributeId);
        void SaveProductAttribute();
        IEnumerable<ValidationResult> CanAddProductAttribute(ProductAttribute productAttribute);

    }
    public class ProductAttributeService : IProductAttributeService
    {
        #region Field
        private readonly IProductAttributeRepository productAttributeRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public ProductAttributeService(IProductAttributeRepository productAttributeRepository, IUnitOfWork unitOfWork)
        {
            this.productAttributeRepository = productAttributeRepository;
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region BaseMethod

        public IEnumerable<ProductAttribute> GetProductAttributes()
        {
            var productAttributes = productAttributeRepository.GetAll();
            return productAttributes;
        }

        public ProductAttribute GetProductAttributeById(int productAttributeId)
        {
            var productAttribute = productAttributeRepository.GetById(productAttributeId);
            return productAttribute;
        }

        public void CreateProductAttribute(ProductAttribute productAttribute)
        {
            productAttributeRepository.Add(productAttribute);
            SaveProductAttribute();
        }

        public void EditProductAttribute(ProductAttribute productAttributeToEdit)
        {
            productAttributeRepository.Update(productAttributeToEdit);
            SaveProductAttribute();
        }

        public void DeleteProductAttribute(int productAttributeId)
        {
            //Get productAttribute by id.
            var productAttribute = productAttributeRepository.GetById(productAttributeId);
            if (productAttribute != null)
            {
                productAttributeRepository.Delete(productAttribute);
                SaveProductAttribute();
            }
        }

        public void SaveProductAttribute()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<ValidationResult> CanAddProductAttribute(ProductAttribute productAttribute)
        {
        
            //    yield return new ValidationResult("ProductAttribute", "ErrorString");
            return null;
        }

        #endregion
    }
}
