using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class LogicalInferenceMachine
    {
        RuleWorkList ruleWorkList;
        KnowledgeBase knowledgeBase;

        public LogicalInferenceMachine(KnowledgeBase knowledgeBase)
        {
            ruleWorkList = new RuleWorkList();
            this.knowledgeBase = knowledgeBase;
        }
    }
}
