using System;
using System.Collections.Generic;

#nullable disable

namespace LehaLab3_1
{
    public partial class Course
    {
        public Course()
        {
            Cabinets = new HashSet<Cabinet>();
        }

        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Language { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Cabinet> Cabinets { get; set; }
    }
}
