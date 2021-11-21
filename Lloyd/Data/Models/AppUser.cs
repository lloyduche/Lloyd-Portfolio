using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloyd.Data.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string JobTitle { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<Project> Projects { get; set; }

        public ICollection<Experience> Experiences { get; set; }

        public ICollection<Education> Educations { get; set; }

    }
}
