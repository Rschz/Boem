using System;
using System.Collections.Generic;

namespace Boem.Models
{
    public partial class JobType
    {
        public JobType()
        {
            JobPosting = new HashSet<JobPosting>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<JobPosting> JobPosting { get; set; }
    }
}
