using System;
using System.Collections.Generic;

namespace Boem.Models
{
    public partial class UserTypes
    {
        public UserTypes()
        {
            User = new HashSet<User>();
        }

        public int UserId { get; set; }
        public string UserType { get; set; }

        public ICollection<User> User { get; set; }
    }
}
