using System.Collections.Generic;

namespace Lab_2
{
    class RuleWorkList
    {
        WorkMember workMember;
        public List<Rule> ItWorked;

        public RuleWorkList(ref WorkMember workMember)
        {
            ItWorked = new List<Rule>();
            this.workMember = workMember;
        }
    }
}
