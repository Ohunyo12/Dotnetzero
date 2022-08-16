using CRUDProject.Exam.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDProject.Exam
{
    public interface IStaffInterface
    
            {
        Task<List<staffdto>> GetStaffDetailsAsync();
        Task CreateStafftRecordsAsync(staffdto input);
        Task UpdateStaffRecordAsync(staffdto input);
        Task DeleteStaffRecordAsyc(int id);

    }
}


