using System;

namespace Lloyd.Data.Models
{
    public class Project
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string PhotoUrlsm { get; set; }
        public string PhotoUrlbg { get; set; }
        public string YearCreated { get; set; }
        public string Link { get; set; }

        public AppUser AppUser { get; set; }
    }
}