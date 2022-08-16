using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDProject.StudentInfo
{
    [Table("tbl_studentdetails")]
    public class student : Entity<int>, ISoftDelete, IMustHaveTenant
    {
        [Required]
        [MaxLength(50)]
        public virtual string FirstName { get; set; }
        [Required]
        public virtual string LastName { get; set; }
        public virtual string Age { get; set; }
        [Required]
        [MaxLength(50)]
        public virtual string Username { get; set; }
        public virtual string Address { get; set; }
        [Required]
        public virtual string BriefDescription { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual int TenantId { get; set; }


    }
}
