using System;

namespace Lloyd.Data.Models
{
    public class Education
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Degree { get; set; }
        public string InstitutionName { get; set; }
        public string Discipline { get; set; }
        
        public string YearStarted { get; set; }
        
        public string YearEnded { get; set; }

        public AppUser AppUser { get; set; }
    }
}