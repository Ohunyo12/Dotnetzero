using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using CRUDProject.Exam.Dto;
using CRUDProject.StaffInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDProject.Exam
{
    public class staffManager : CRUDProjectAppServiceBase , IStaffInterface
    {
        private readonly IRepository<staff> _staffRepository;
        //private readonly IMapper ObjectMapper;
        
        public staffManager(
            IRepository<staff> staffRepo
            // IMapper _mapper
            )
        {
            _staffRepository = staffRepo;
            //ObjectMapper = _mapper;
        }

       public async Task<List<staffdto>> GetStaffDetailsAsync()
        {
            var records = await _staffRepository.GetAll().Where(x => !x.IsDeleted).ToListAsync();

            //select * from student details where isdelete = 0
            var dataRecords = ObjectMapper.Map<List<staffdto>>(records);
            return dataRecords;
        }


        public async Task CreateStafftRecordsAsync(staffdto input)
        {
            try
            {
                //Converting the parameter from DTO to table data

                var records = ObjectMapper.Map<staff>(input);
                records.TenantId = 1;
                records.IsDeleted = false;

                await _staffRepository.InsertAsync(records);

                //Saving the data into our table
                await CurrentUnitOfWork.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                //Audit log to be provided
                throw new UserFriendlyException($"An error has occured : {ex.Message}");
            }
        }

        public async Task UpdateStaffRecordAsync(staffdto input)
        {
            try
            {
                var records = await _staffRepository.FirstOrDefaultAsync(x => x.Id == input.Id && !x.IsDeleted && x.Age==50 && x.Salary<50000);

                //declare @records varchar(200); 
                //  @records = (select top 1  from student a repository where a.id = input.id and a.isDeleted =  0)



                if (records != null)
                {
                    var data = ObjectMapper.Map<staff>(input);

                    data.Id = records.Id;


                    await _staffRepository.UpdateAsync(data);
                    await CurrentUnitOfWork.SaveChangesAsync();
                }
                else
                {
                    //throw new UserFriendlyException($"Student with username {records.Username} does not exist in the application");
                }
            }
            catch (Exception ex)
            {
                //Audit log to be provided
                throw new UserFriendlyException($"An error has occured : {ex.Message}");
            }
        }


       public async Task DeleteStaffRecordAsyc(int id)
        {
            try
            {
                var records = await _staffRepository.FirstOrDefaultAsync(x => x.Id == id);

                //declare @records varchar(200); 
                //  @records = (select top 1  from student a repository where a.id = input.id and a.isDeleted =  0)

                if (records != null)
                {
                    //Soft Delete  => This one will update the records 
                    records.IsDeleted = true;
                    await _staffRepository.UpdateAsync(records);
                    await CurrentUnitOfWork.SaveChangesAsync();



                    //Hard Delete  => Delete the record permanently from the table
                    await _staffRepository.DeleteAsync(records);
                    await CurrentUnitOfWork.SaveChangesAsync();

                }
                else
                {
                    // throw new UserFriendlyException($"Student with username {records.Username} does not exist in the application");
                }
            }
            catch (Exception ex)
            {
                //Audit log to be provided
                throw new UserFriendlyException($"An error has occured : {ex.Message}");
            }
        }

    }
}