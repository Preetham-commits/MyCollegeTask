using Abp.Application.Services;
using Abp.Domain.Repositories;
using MyCollegeTask.Students.Dto;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.ObjectMapping;
using System;
using Abp.UI;
using MyCollegeTask.Modules;

namespace MyCollegeTask.Students
{
    public class StudentAppService : ApplicationService, IStudentAppService // Assuming IStudentAppService is your custom interface
    {
        private readonly IRepository<Student, int> _studentRepository;
        private readonly IObjectMapper _objectMapper;

        public StudentAppService(IRepository<Student, int> studentRepository, IObjectMapper objectMapper)
        {
            _studentRepository = studentRepository;
            _objectMapper = objectMapper;
        }

        public async Task<ListResultDto<StudentDto>> GetAll()
        {
            var students = await _studentRepository.GetAllListAsync();
            return new ListResultDto<StudentDto>(_objectMapper.Map<List<StudentDto>>(students));
        }

        public async Task<StudentDto> GetById(int id)
        {
            var student = await _studentRepository.GetAsync(id);
            return _objectMapper.Map<StudentDto>(student);
        }

        public async Task<int> Create(CreateStudentDto input)
        {
            try
            {
                // Validate CollegeId
                if (input.CollegeId == null || input.CollegeId == 0)
                {
                    throw new ArgumentException("A college for the student is mandatory.");
                }
                var student = new Student
                {
                    CollegeId = input.CollegeId,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Address = input.Address,
                    IsActive = input.IsActive,
                    ProgramName = input.ProgramName,
                    DoB = input.DoB,

                };

                student = await _studentRepository.InsertAsync(student);
                return student.Id;
            }
            catch (ArgumentException ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        public async Task Update(StudentDto input)
        {
            var student = await _studentRepository.GetAsync(input.Id);
            _objectMapper.Map(input, student); 
            await _studentRepository.UpdateAsync(student);
            await CurrentUnitOfWork.SaveChangesAsync(); 
        }

        public async Task Delete(int id)
        {
            await _studentRepository.DeleteAsync(id);
            await CurrentUnitOfWork.SaveChangesAsync(); 
        }
    }
}
