using System.Collections.Generic;

namespace Lab_2
{
    class RuleWorkList
    {
        WorkMember workMember;
        List<Rule> itWorked;

        public RuleWorkList(ref WorkMember workMember)
        {
            itWorked = new List<Rule>();
            this.workMember = workMember;
        }
    }
}
