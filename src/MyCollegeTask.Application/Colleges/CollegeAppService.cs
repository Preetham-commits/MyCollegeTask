using Abp.Application.Services;
using MyCollegeTask.Colleges.Dto;
using MyCollegeTask.Modules;
using Abp.Domain.Repositories;
using MyCollegeTask.Colleges;
using Abp.ObjectMapping;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCollegeTask.Colleges
{
    public class CollegeAppService : AsyncCrudAppService<College, CollegeDto, int, PagedCollegeResultRequestDto, CreateCollegeDto, CollegeDto>
    {
      

        private readonly IRepository<College, int> _collegeRepository;
        private readonly IObjectMapper _objectMapper;

        public CollegeAppService(IRepository<College, int> repository, IRepository<College, int> collegeRepository, IObjectMapper objectMapper)
            : base(repository)
        {
            _collegeRepository = collegeRepository;
            _objectMapper = objectMapper;
        }

        public async Task<ListResultDto<CollegeDto>> GetAllColleges()
        {
            var colleges = await _collegeRepository.GetAllListAsync();
            return new ListResultDto<CollegeDto>(_objectMapper.Map<List<CollegeDto>>(colleges));
        }

        public async Task<CollegeDto> GetCollegeById(int collegeId)
        {
            var college = await _collegeRepository.GetAsync(collegeId);
            return _objectMapper.Map<CollegeDto>(college);
        }

        //public async Task<int> CreateCollege(CreateCollegeDto input)
        //{
        //    var college = MapToEntity(input);
        //    college = await _collegeRepository.InsertAsync(college);
        //    return college.Id;
        //}

        public async Task<int> CreateCollege(CreateCollegeDto input)
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
                // Assuming CreationTime and IsActive are handled in the College constructor
            };

            // Add any additional logic or validation here if needed

            college = await _collegeRepository.InsertAsync(college);
            return college.Id;
        }

        public async Task UpdateCollege(CollegeDto input)
        {
            var college = await _collegeRepository.GetAsync(input.Id);
            MapToEntity(input, college);
            await _collegeRepository.UpdateAsync(college);
        }

        public async Task DeleteCollege(int collegeId)
        {
            await _collegeRepository.DeleteAsync(collegeId);
        }
    }
}
