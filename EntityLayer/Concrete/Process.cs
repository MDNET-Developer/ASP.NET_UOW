﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Process
    {
        public int ProcessId { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
    }
}
