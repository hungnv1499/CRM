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
    public interface IStaffService
    {
        IEnumerable<Staff> GetAvailableCategorys();

        IEnumerable<Staff> GetStaffs();
        Staff GetStaffById(int StaffId);
        void CreateStaff(Staff Staff);
        void EditStaff(Staff StaffToEdit);
        void DeleteStaff(int StaffId);
        void SaveStaff();

        //Staff GetCategoryByUrlName(string );

    }
    class StaffService : IStaffService
    {
        #region Field
        private readonly IStaffRepository staffRepository;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Ctor
        public StaffService(IStaffRepository staffRepository, IUnitOfWork unitOfWork)
        {
            this.staffRepository = staffRepository;
            this.unitOfWork = unitOfWork;
        }
        #endregion

        public IEnumerable<Staff> GetAvailableCategorys()
        {
            var list = staffRepository.GetAll().Where(p=>p.Deleted==true);
            return list;
        }

        public IEnumerable<Staff> GetStaffs()
        {
            try
            {
                var list = staffRepository.GetAll().Where(p => p.Deleted == false);
                return list;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public Staff GetStaffById(int staffId)
        {
            var item = staffRepository.Get(p => p.Id == staffId);
            return item;
        }

        public void CreateStaff(Staff staff)
        {
            if (staff != null)
            {
                staffRepository.Add(staff);
                SaveStaff();
            }
        }

        public void EditStaff(Staff staffToEdit)
        {
            if (staffToEdit != null)
            {
                staffRepository.Update(staffToEdit);
                SaveStaff();
            }
        }

        public void DeleteStaff(int staffId)
        {
            var item = staffRepository.Get(p => p.Id == staffId);
           // staffRepository.Delete(item);
            item.Deleted = true;
            staffRepository.Update(item);
            SaveStaff();
        }

        public void SaveStaff()
        {
            unitOfWork.Commit();
        }
    }
}
