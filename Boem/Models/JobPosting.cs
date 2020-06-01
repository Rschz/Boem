using System;
using System.Collections.Generic;

namespace Boem.Models
{
    public partial class JobPosting
    {
        public int JobPostingId { get; set; }
        public int CategoryId { get; set; }
        public int JobType { get; set; }
        public string Company { get; set; }
        public byte[] Logo { get; set; }
        public string Url { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int PersonalId { get; set; }

        public Category Category { get; set; }
        public JobType JobTypeNavigation { get; set; }
        public User Personal { get; set; }
    }
}
