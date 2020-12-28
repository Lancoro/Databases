using System;
using System.Collections.Generic;

#nullable disable

namespace LehaLab3_1
{
    public partial class Cabinet
    {
        public int Id { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Client IdNavigation { get; set; }
    }
}
