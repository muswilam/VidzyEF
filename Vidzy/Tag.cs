﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidzy
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //nav props
        public ICollection<Video> Videos { get; set; }
    }
}
