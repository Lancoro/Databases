using System;
using System.Collections.Generic;

#nullable disable

namespace LehaLab3_1
{
    public partial class Company
    {
        public Company()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCountry { get; set; }
        public int LeaderId { get; set; }

        public virtual Leader Leader { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
