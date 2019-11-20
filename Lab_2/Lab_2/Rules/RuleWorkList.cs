using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class RuleWorkList
    {
        WorkMember workMember;

        public List<Rule> itWorked { get; set; }

        public RuleWorkList(ref WorkMember workMember)
        {
            itWorked = new List<Rule>();
            this.workMember = workMember;
        }

    }
}
