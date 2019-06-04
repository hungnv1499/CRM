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
    public interface IWebsiteAttributeService
    {

        IEnumerable<WebsiteAttribute> GetWebsiteAttributes();
        WebsiteAttribute GetWebsiteAttributeById(int websiteAttributeId);
        WebsiteAttribute GetWebsiteAttributeByName(string Name);

        void CreateWebsiteAttribute(WebsiteAttribute websiteAttribute);
        void EditWebsiteAttribute(WebsiteAttribute websiteAttributeToEdit);
        void DeleteWebsiteAttribute(int websiteAttributeId);
        void SaveWebsiteAttribute();

        //WebsiteAttribute GetCategoryByUrlName(string );

    }
    class WebsiteAttributeService : IWebsiteAttributeService
    {
        #region Field
        private readonly IWebsiteAttributeRepository _websiteAttributeRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Ctor
        public WebsiteAttributeService(IWebsiteAttributeRepository websiteAttributeRepository, IUnitOfWork unitOfWork)
        {
            this._websiteAttributeRepository = websiteAttributeRepository;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        public IEnumerable<WebsiteAttribute> GetAvailableCategorys()
        {
            var list = _websiteAttributeRepository.GetAll().Where(p=>p.Deleted==true);
            return list;
        }

        public IEnumerable<WebsiteAttribute> GetWebsiteAttributes()
        {
            var list = _websiteAttributeRepository.GetAll().Where(p => p.Deleted == false);
            return list;
        }

        public WebsiteAttribute GetWebsiteAttributeById(int websiteAttributeId)
        {
            var item = _websiteAttributeRepository.Get(p => p.Id == websiteAttributeId);
            return item;
        }
        public WebsiteAttribute GetWebsiteAttributeByName(string  name)
        {
            var item = _websiteAttributeRepository.Get(p => p.Name == name);
            return item;
        }

        public void CreateWebsiteAttribute(WebsiteAttribute websiteAttribute)
        {
            if (websiteAttribute != null)
            {
                _websiteAttributeRepository.Add(websiteAttribute);
                SaveWebsiteAttribute();
            }
        }

        public void EditWebsiteAttribute(WebsiteAttribute websiteAttributeToEdit)
        {
            if (websiteAttributeToEdit != null)
            {
                _websiteAttributeRepository.Update(websiteAttributeToEdit);
                SaveWebsiteAttribute();
            }
        }

        public void DeleteWebsiteAttribute(int websiteAttributeId)
        {
            var item = _websiteAttributeRepository.Get(p => p.Id == websiteAttributeId);
           // websiteAttributeRepository.Delete(item);
            item.Deleted = true;
            _websiteAttributeRepository.Update(item);
            SaveWebsiteAttribute();
        }

        public void SaveWebsiteAttribute()
        {
            _unitOfWork.Commit();
        }
    }
}
