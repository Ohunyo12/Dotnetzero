using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDProject.Exam.Dto
{
    public class staffdto : EntityDto<int>
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string OtherNames { get; set; }
        public virtual int Age { get; set; }
        public virtual string TelephoneNumber { get; set; }
        public virtual string AlternativePhone { get; set; }
        public virtual int Grade { get; set; }
        public virtual string HomeAddress { get; set; }
        public virtual string MaritalStatus { get; set; }
        public virtual decimal Salary { get; set; }
        public virtual DateTime EmploymentDate { get; set; }
        public virtual string Next_Of_Kin { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual int TenantId { get; set; }
    }
}
