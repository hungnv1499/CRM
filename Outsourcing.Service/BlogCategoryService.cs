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
    public interface IBlogCategoryService
    {
        IEnumerable<BlogCategory> GetBlogCategories();
        BlogCategory GetBlogCategoryById(int blogId);
        BlogCategory GetBlogCategoryByUrl(string url);
        void CreateBlogCategory(BlogCategory obj);
        void EditBlogCategory(BlogCategory obj);
        void DeleteBlogCategory(string urlName);
        void DeleteBlogCategory(int id);

        void SaveChange();
    }
    public class BlogCategoryService : IBlogCategoryService
    {
        #region Field
        private readonly IBlogTypeRepository blogCategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public BlogCategoryService(IBlogTypeRepository blogCategoryRepository, IUnitOfWork unitOfWork)
        {
            this.blogCategoryRepository = blogCategoryRepository;
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region [base Method]
        public IEnumerable<BlogCategory> GetBlogCategories()
        {
            var list = blogCategoryRepository.GetAll().Where(p => p.Status && !p.IsStaticPage).OrderByDescending(p => p.CategoryParentId).ToList();
            return list;
        }

        public BlogCategory GetBlogCategoryByUrl(string slug)
        {
            try
            {
                var item = blogCategoryRepository.Get(p => p.Slug.Equals(slug));
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public BlogCategory GetBlogCategoryById(int blogId)
        {
            try
            {
                var item = blogCategoryRepository.GetById(blogId);
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void CreateBlogCategory(BlogCategory obj)
        {
            try
            {
                blogCategoryRepository.Add(obj);
                SaveChange();

            }
            catch (Exception)
            {

            }
        }

        public void EditBlogCategory(BlogCategory obj)
        {
            try
            {
                var item = blogCategoryRepository.Get(p => p.Id == obj.Id);
                item.Name = obj.Name;
                item.Slug = obj.Slug;
                item.Status = obj.Status;
                item.DisplayOrder = obj.DisplayOrder;
                item.CategoryParentId = obj.CategoryParentId;
                blogCategoryRepository.Update(item);
                SaveChange();
            }
            catch (Exception)
            {

            }
        }

        public void DeleteBlogCategory(string slugName)
        {
            try
            {
                var item = blogCategoryRepository.Get(p => p.Slug.Equals(slugName));
                item.Status = false;
                blogCategoryRepository.Update(item);
                SaveChange();
            }
            catch (Exception)
            {

            }
        }


        public void SaveChange()
        {
            try
            {
                unitOfWork.Commit();
            }
            catch (Exception)
            {

            }
        }
        #endregion


        public void DeleteBlogCategory(int id)
        {
            var item = blogCategoryRepository.Get(p => p.Id == id);
            item.Status = false;
            blogCategoryRepository.Update(item);
            SaveChange();
        }
    }
}
