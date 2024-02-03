using Abp.Authorization.Users;
using MyCollegeTask.Colleges.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollegeTask.Students.Dto
{
    public class CreateStudentDto
    {
        [Required]
        public int? CollegeId { get; set; }
        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ProgramName { get; set; }
        public string DoB { get; set; }
        public bool IsActive { get; set; }



    }
}
