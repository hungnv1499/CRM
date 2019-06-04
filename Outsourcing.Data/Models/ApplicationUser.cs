using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsourcing.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            DateCreated = DateTime.Now;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public bool Activated { get; set; }

        public Gender Gender { get; set; }

        public SystemRoles RoleId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool Deleted { get; set; }

        public string DisplayName
        {
            get { return LastName + " " + FirstName; }
        }
    }
    public enum SystemRoles
    {
        [Description("Admin")]
        Role01 = 0
    }
    public enum Gender
    {
        [Description("Nam")]
        Male = 0,
        [Description("Nữ")]
        Female = 1
    }
}
