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
    public interface IProductCategoryService
    {

        IEnumerable<ProductCategory> GetProductCategories();
        ProductCategory GetProductCategoryById(int productCategoryId);
        void CreateProductCategory(ProductCategory productCategory);
        void EditProductCategory(ProductCategory productCategoryToEdit);
        void DeleteProductCategories(int productCategoryId);
        void SaveProductCategory();
        IEnumerable<ValidationResult> CanAddProductCategory(ProductCategory productCategory);

    }
    public class ProductCategoryService : IProductCategoryService
    {
        #region Field
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region BaseMethod

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            var productCategorys = productCategoryRepository.GetAll().Where(p=>p.Deleted==false && p.Id!=7);
            return productCategorys;
        }

        public ProductCategory GetProductCategoryById(int productCategoryId)
        {
            var productCategory = productCategoryRepository.GetById(productCategoryId);
            return productCategory;
        }

        public void CreateProductCategory(ProductCategory productCategory)
        {
            productCategoryRepository.Add(productCategory);
            SaveProductCategory();
        }

        public void EditProductCategory(ProductCategory productCategoryToEdit)
        {
            productCategoryRepository.Update(productCategoryToEdit);
            SaveProductCategory();
        }

        public void DeleteProductCategories(int productCategoryId)
        {
            //Get productCategory by id.
            var productCategory = productCategoryRepository.GetById(productCategoryId);
            if (productCategory != null)
            {
                productCategoryRepository.Delete(productCategory);
                SaveProductCategory();
            }
        }

        public void SaveProductCategory()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<ValidationResult> CanAddProductCategory(ProductCategory productCategory)
        {
        
            //    yield return new ValidationResult("ProductCategory", "ErrorString");
            return null;
        }

        #endregion
    }
}
