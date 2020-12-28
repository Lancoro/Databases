using System;
using System.Collections.Generic;

#nullable disable

namespace LehaLab3_1
{
    public partial class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual Cabinet Cabinet { get; set; }
    }
}
