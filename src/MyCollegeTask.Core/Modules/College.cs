using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyCollegeTask.Modules
{


    public class College : FullAuditedEntity<int>, IPassivable
    {
        public College()
        {
            this.IsActive = true;
            this.CreationTime = DateTime.Now;
        }
        public string Name { get; set; }       
        public string Address { get; set; }
        public string Description { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public bool IsActive { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    
}
}
