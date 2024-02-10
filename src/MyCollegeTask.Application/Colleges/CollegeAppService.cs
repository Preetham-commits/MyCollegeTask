using Abp.Application.Services;
using Abp.Domain.Repositories;
using MyCollegeTask.Colleges.Dto;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.ObjectMapping;
using MyCollegeTask.Modules;

namespace MyCollegeTask.Colleges
{
    public class CollegeAppService : ApplicationService, ICollegeAppService // Assuming ICollegeAppService is your custom interface
    {
        private readonly IRepository<College, int> _collegeRepository;
        private readonly IObjectMapper _objectMapper;

        public CollegeAppService(IRepository<College, int> collegeRepository, IObjectMapper objectMapper)
        {
            _collegeRepository = collegeRepository;
            _objectMapper = objectMapper;
        }

        public async Task<ListResultDto<CollegeDto>> GetAll()
        {
            var colleges = await _collegeRepository.GetAllListAsync();
            return new ListResultDto<CollegeDto>(_objectMapper.Map<List<CollegeDto>>(colleges));
        }

        public async Task<CollegeDto> GetById(int collegeId)
        {
            var college = await _collegeRepository.GetAsync(collegeId);
            return _objectMapper.Map<CollegeDto>(college);
        }


        public async Task<int> Create(CreateCollegeDto input)
        {
            var college = new College
            {
                Name = input.Name,
                Address = input.Address,
                Description = input.Description,
                latitude = input.Latitude,
                longitude = input.Longitude,
                IsActive = input.IsActive,
                Contact = input.Contact,
                Email = input.Email,

            };

            college = await _collegeRepository.InsertAsync(college);
            return college.Id;
        }

        public async Task Update(CollegeDto input)
        {
            var college = await _collegeRepository.GetAsync(input.Id);
            _objectMapper.Map(input, college); 
            await _collegeRepository.UpdateAsync(college);
            await CurrentUnitOfWork.SaveChangesAsync(); 
        }

        public async Task Delete(int collegeId)
        {
            await _collegeRepository.DeleteAsync(collegeId);
            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}
