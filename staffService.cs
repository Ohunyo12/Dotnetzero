using CRUDProject.Exam.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDProject.Exam
{
    public class staffService : CRUDProjectAppServiceBase
    {
        private readonly IStaffInterface _StudentsInterface;

        //It does the work of  controller

        public staffService(IStaffInterface manager)
        {
            this._StudentsInterface = manager;
        }



        public async Task<List<staffdto>> GetStaffRecordsAsync()
        {
            return await _StudentsInterface.GetStaffDetailsAsync();
        }

        public async Task CreateStaff(staffdto input)
        {
            await _StudentsInterface.CreateStafftRecordsAsync(input);
        }

        public async Task EditStaff(staffdto input)
        {
            await _StudentsInterface.UpdateStaffRecordAsync(input);
        }

        public async Task DeleteStaff(int Id)
        {
            await _StudentsInterface.DeleteStaffRecordAsyc(Id);
        }

        public async Task DeleteBulkStaff(List<staffdto> input)
        {
            foreach (var item in input)
            {
                await _StudentsInterface.DeleteStaffRecordAsyc(item.Id);
            }
        }
    }
}
