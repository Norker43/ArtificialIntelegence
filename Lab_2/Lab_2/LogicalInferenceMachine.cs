using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class LogicalInferenceMachine
    {
        WorkMember workMember;
        RuleWorkList ruleWorkList;
        KnowledgeBase knowledgeBase;

        public LogicalInferenceMachine(KnowledgeBase knowledgeBase)
        {
            workMember = new WorkMember();
            ruleWorkList = new RuleWorkList(ref workMember);
            this.knowledgeBase = knowledgeBase;
        }

        public void LogicalInferenceStart()
        {
            foreach (Rule rule in knowledgeBase.Rules)
            {
                if (rule.Ancendant.Contains("?"))
                {

                }
            }
        }

        public void LogicalInverseInferenceStart()
        {

        }
    }
}
