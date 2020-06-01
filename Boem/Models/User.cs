using System;
using System.Collections.Generic;

namespace Boem.Models
{
    public partial class User
    {
        public User()
        {
            JobPosting = new HashSet<JobPosting>();
        }

        public int PersonalId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }

        public UserTypes UserNavigation { get; set; }
        public ICollection<JobPosting> JobPosting { get; set; }
    }
}
