using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Frame
    {
        public string Name { get; set; }
        public Frame Parent { get; set; }
        public List<Slot> Slots { get; set; }
    }
}
