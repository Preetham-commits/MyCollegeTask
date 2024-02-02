using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyCollegeTask.Modules
{
    public class Student : FullAuditedEntity<int>, IPassivable
    {

        // Foreign key for College
        public int? CollegeId { get; set; }
        public Student()
        {
            this.IsActive = true;
            this.CreationTime = DateTime.Now;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string ProgramName { get; set; }

        public string DoB { get; set; }

        public bool IsActive { get; set; }

        // Navigation property
        public College College { get; set; }

    }
}
