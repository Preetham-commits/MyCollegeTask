using Abp.Application.Services;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using MyCollegeTask.Modules;
using MyCollegeTask.Students.Dto;
using Abp.ObjectMapping;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyCollegeTask.Colleges.Dto;
using System;
using Abp.UI;

namespace MyCollegeTask.Students
{
    public class StudentAppService : AsyncCrudAppService<Student, StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, StudentDto>
    {
        private readonly IRepository<Student, int> _studentRepository;
        private readonly IObjectMapper _objectMapper;

        public StudentAppService(IRepository<Student, int> repository, IRepository<Student, int> studentRepository, IObjectMapper objectMapper)
            : base(repository)
        {
            _studentRepository = studentRepository;
            _objectMapper = objectMapper;
        }

        public async Task<ListResultDto<StudentDto>> GetAllStudents()
        {
            var students = await _studentRepository.GetAllListAsync();
            return new ListResultDto<StudentDto>(_objectMapper.Map<List<StudentDto>>(students));
        }

        public async Task<StudentDto> GetStudentById(int studentId)
        {
            var student = await _studentRepository.GetAsync(studentId);
            return _objectMapper.Map<StudentDto>(student);
        }

        //public async Task<int> CreateStudent(CreateStudentDto input)
        //{
        //    var student = MapToEntity(input);
        //    student = await _studentRepository.InsertAsync(student);
        //    return student.Id;
        //}

        public async Task<int> CreateStudent(CreateStudentDto input)
        {
            try
            {
                // Validate CollegeId
                if (input.CollegeId == null || input.CollegeId == 0)
                {
                    throw new ArgumentException("A college for the student is mandatory.");
                }

                // Rest of the code to create the student
                var student = new Student
                {
                    CollegeId = input.CollegeId,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Address = input.Address,
                    IsActive = input.IsActive,
                    ProgramName = input.ProgramName,
                    DoB = input.DoB,
                    // Assuming CreationTime and IsActive are handled in the College constructor
                };

                // Add any additional logic or validation here if needed

                student = await _studentRepository.InsertAsync(student);
                return student.Id;
            }
            catch (ArgumentException ex)
            {
                // Catch the specific exception and return a custom response
                throw new UserFriendlyException(ex.Message);
            }
        }

        public async Task UpdateStudent(StudentDto input)
        {
            var student = await _studentRepository.GetAsync(input.Id);
            MapToEntity(input, student);
            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteStudent(int studentId)
        {
            await _studentRepository.DeleteAsync(studentId);
        }
    }
}
