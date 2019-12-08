using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml;
using System.Linq;

namespace Lab_2
{
    class LogicalInferenceMachine
    {
        public bool CheckAnswer { get; set; } = false;
        public string UserResponce { get; set; } = "";

        #region
        public TextBox question;
        public RichTextBox dialog;
        public RichTextBox reasoning;
        public ComboBox answer;
        #endregion

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
            dialog.Invoke(new Action(() => dialog.AppendText("Начало" + "\n\n")));
            reasoning.Invoke(new Action(() => reasoning.AppendText("Получение фактов...\n\n")));

            for (int i = 0; i < knowledgeBase.Rules.Count; i++)
            {
                Rule rule = knowledgeBase.Rules[i];

                if (!(from XmlNode node in rule.Antecedent.ChildNodes select node.Name).Contains("not"))
                {
                    if (ReadChildNodesRec(rule.Antecedent.FirstChild))
                    {

                        Explanation(rule);
                    }
                    else
                    {

                    }
                }
                else
                {
                    rule.Consequent = RuleManager.Sequentialization(rule.Consequent);
                    string waitAnswerResult = AskQuestion(rule);

                    rule.Consequent[0] += ": " + waitAnswerResult;
                    dialog.Invoke(new Action(() => dialog.AppendText(rule.Consequent[1] + "\n" + waitAnswerResult + "\n\n")));
                    workMember.Facts.Add(rule.Consequent[0]);
                    Explanation(rule);
                }
            }

            dialog.Invoke(new Action(() => dialog.AppendText("Конец")));
        }

        public void LogicalInverseInferenceStart()
        {
            dialog.Invoke(new Action(() => dialog.AppendText("Начало" + "\n\n")));
            question.Invoke(new Action(() => question.Text = "Выберите вариант."));



            dialog.Invoke(new Action(() => dialog.AppendText("Конец")));

            #region Управление работой обратного логического вывода

            #endregion
        }

        private void Explanation(Rule rule)
        {

        }

        private bool And(object[] array)
        {
            int coincedence = 0;
            var strs = (from str in array where str is string select str).ToArray();
            var bools = (from logic in array where logic is bool select logic).ToArray();

            for (int i = 0; i < strs.Length; i++)
            {
                if (workMember.Facts.Contains(strs[i]))
                {
                    coincedence++;
                }
            }

            for (int i = 0; i < bools.Length; i++)
            {
                if (bools.Contains(true))
                {
                    coincedence++;
                }
            }

            if (coincedence == array.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Or(object[] array)
        {
            var strs = (from str in array where str is string select str).ToArray();
            var bools = (from logic in array where logic is bool select logic).ToArray();

            for (int i = 0; i < strs.Length; i++)
            {
                if (workMember.Facts.Contains(strs[i]))
                {
                    return true;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (bools.Contains(true))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ReadChildNodesRec(XmlNode xmlNode)
        {
            List<object> facts = new List<object>();

            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.Name == "or" || node.Name == "and")
                {
                    facts.Add(ReadChildNodesRec(node));
                }
                else
                {
                    facts.Add(node.InnerText);
                }
            }

            if (xmlNode.Name == "or")
            {
                return Or(facts.ToArray());
            }

            if (xmlNode.Name == "and")
            {
                return And(facts.ToArray());
            }

            return false;
        }

        #region Вспомогательные функции
        private void ResponseOptions(Rule rule)
        {
            string[] variousAnswers = new string[1];

            if (rule.Consequent[0].Contains("num"))
            {
                variousAnswers = new string[] { "15", "30", "60+" };
            }
            else
            {
                variousAnswers = new string[] { "Да", "Нет" };
            }

            answer.Invoke(new Action(() => answer.Items.AddRange(variousAnswers)));
        }

        private string AskQuestion(Rule rule)
        {
            ResponseOptions(rule);
            question.Invoke(new Action(() => question.Text = rule.Consequent[1]));
            UserResponce = "";
            CheckAnswer = true;
            while (CheckAnswer) { }
            UserResponce = UserResponce.ToLower();

            return UserResponce;
        }
        #endregion
    }
}
