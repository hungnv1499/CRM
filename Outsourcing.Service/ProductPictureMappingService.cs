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
    public interface IProductPictureMappingService
    {

        IEnumerable<ProductPictureMapping> GetProductPictureMappings();
        ProductPictureMapping GetProductPictureMappingById(int productPictureMappingId);
        void CreateProductPictureMapping(ProductPictureMapping productPictureMapping);
        void EditProductPictureMapping(ProductPictureMapping productPictureMappingToEdit);
        void DeleteProductPictureMapping(int productPictureMappingId);
        void SaveProductPictureMapping();
        IEnumerable<ValidationResult> CanAddProductPictureMapping(ProductPictureMapping productPictureMapping);

    }
    public class ProductPictureMappingService : IProductPictureMappingService
    {
        #region Field
        private readonly IProductPictureMappingRepository productPictureMappingRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public ProductPictureMappingService(IProductPictureMappingRepository productPictureMappingRepository, IUnitOfWork unitOfWork)
        {
            this.productPictureMappingRepository = productPictureMappingRepository;
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region BaseMethod

        public IEnumerable<ProductPictureMapping> GetProductPictureMappings()
        {
            var productPictureMappings = productPictureMappingRepository.GetAll();
            return productPictureMappings;
        }

        public ProductPictureMapping GetProductPictureMappingById(int productPictureMappingId)
        {
            var productPictureMapping = productPictureMappingRepository.GetById(productPictureMappingId);
            return productPictureMapping;
        }

        public void CreateProductPictureMapping(ProductPictureMapping productPictureMapping)
        {
            productPictureMappingRepository.Add(productPictureMapping);
            SaveProductPictureMapping();
        }

        public void EditProductPictureMapping(ProductPictureMapping productPictureMappingToEdit)
        {
            productPictureMappingRepository.Update(productPictureMappingToEdit);
            SaveProductPictureMapping();
        }

        public void DeleteProductPictureMapping(int productPictureMappingId)
        {
            //Get productPictureMapping by id.
            var productPictureMapping = productPictureMappingRepository.GetById(productPictureMappingId);
            if (productPictureMapping != null)
            {
                productPictureMappingRepository.Delete(productPictureMapping);
                SaveProductPictureMapping();
            }
        }

        public void SaveProductPictureMapping()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<ValidationResult> CanAddProductPictureMapping(ProductPictureMapping productPictureMapping)
        {
        
            //    yield return new ValidationResult("ProductPictureMapping", "ErrorString");
            return null;
        }

        #endregion
    }
}
