using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Models
{
    abstract class Model
    {
        public List<Expert> Experts { get; set; }

        public Model()
        {
            Experts = new List<Expert>();
        }

        public abstract string Execute();
    }
}
