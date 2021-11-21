using System;

namespace Lloyd.Data.Models
{
    public class Experience
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Employer { get; set; }
        public string YearStarted { get; set; }
        public string YearEnded { get; set; }
        public AppUser AppUser { get; set; }

       
    }
}