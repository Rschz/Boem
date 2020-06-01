using System;
using System.Collections.Generic;

namespace Boem.Models
{
    public partial class Category
    {
        public Category()
        {
            JobPosting = new HashSet<JobPosting>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<JobPosting> JobPosting { get; set; }
    }
}
