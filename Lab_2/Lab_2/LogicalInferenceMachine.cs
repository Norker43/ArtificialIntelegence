using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Xml.Linq;

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
            string result = null;
            dialog.Invoke(new Action(() => dialog.AppendText("Начало" + "\n\n")));
            reasoning.Invoke(new Action(() => reasoning.AppendText("Получение фактов...\n\n")));

            //workMember.Facts.Add("dancing: no");
            //workMember.Facts.Add("listening-music: no");

            while (result == null)
            {
                knowledgeBase.Rules = knowledgeBase.Rules.Except(ruleWorkList.ItWorked).ToList();

                for (int i = 0; i < knowledgeBase.Rules.Count; i++)//foreach(Rule rule in knowledgeBase.Rules)
                {
                    Rule rule = knowledgeBase.Rules[i];

                    if (ReadChildNodesRec(rule.Antecedent.FirstChild))
                    {
                        if (rule.Consequent[0].Contains('?'))
                        {
                            rule.Consequent = RuleManager.Sequentialization(rule.Consequent);
                            string waitAnswerResult = AskQuestion(rule);

                            rule.Consequent[0] += ": " + waitAnswerResult;
                            dialog.Invoke(new Action(() => dialog.AppendText(rule.Consequent[1] + "\n" + waitAnswerResult + "\n\n")));
                            workMember.Facts.Add(rule.Consequent[0]);
                        }

                        if (rule.Consequent[0].Contains('.'))
                        {
                            result = rule.Consequent[0];
                            dialog.Invoke(new Action(() => dialog.AppendText(result + "\n\n")));
                        }
                        else
                        {
                            workMember.Facts.Add(rule.Consequent[0]);
                        }

                        ruleWorkList.ItWorked.Add(rule);
                        Explanation(rule);
                        break;
                    }
                }
            }

            dialog.Invoke(new Action(() => dialog.AppendText("Конец")));
        }

        public void LogicalInverseInferenceStart()
        {
            dialog.Invoke(new Action(() => dialog.AppendText("Начало" + "\n\n")));
            question.Invoke(new Action(() => question.Text = "Выберите вариант."));

            #region Выбор гипотезы
            List<Rule> results = new List<Rule>();

            foreach (Rule rule in knowledgeBase.Rules)
            {
                if (!rule.Consequent[0].Contains(':'))
                {
                    results.Add(rule);
                }
            }

            answer.Invoke(new Action(() => answer.Items.AddRange((from res in results select res.Name).ToArray())));

            Rule selectedRule = new Rule();
            string name = AskQuestion();
            foreach (Rule rule in results)
            {
                if (rule.Name == name)
                {
                    selectedRule = rule;
                }
            }
            #endregion

            List<string> result = null;

            while (result == null)
            {
                knowledgeBase.Rules = knowledgeBase.Rules.Except(ruleWorkList.ItWorked).ToList();

            }

            dialog.Invoke(new Action(() => dialog.AppendText("Конец")));
        }

        private void Explanation(Rule rule)
        {

        }

        #region Обход антецедента

        #region Для прямого вывода
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
                if ((bool)bools[i])
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

            for (int i = 0; i < bools.Length; i++)
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
                else if (node.Name == "not")
                {
                    facts.Add(ReadChildNodesRec(node));
                }
                else if (node.Name == "fact")
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

            if (xmlNode.Name == "not")
            {
                bool contains = false;

                for (int i = 0; i < workMember.Facts.Count; i++)
                {
                    if (!workMember.Facts[i].Contains(xmlNode.InnerText))
                    {
                        contains = true;
                    }
                    else
                    {
                        contains = false;
                        break;
                    }
                }

                if (contains)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region Для обратного вывода

        #endregion

        #endregion

        #region Вспомогательные функции
        private void ResponseOptions(Rule rule)
        {
            string[] variousAnswers = new string[] { "yes", "no" };

            if (rule.Antecedent.FirstChild.Attributes.Count > 0)
            {
                if (rule.Antecedent.FirstChild.Attributes.GetNamedItem("value").Value.Contains("num"))
                {
                    variousAnswers = new string[] { "15", "30", "60" };
                }
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

        private string AskQuestion()
        {
            UserResponce = "";
            CheckAnswer = true;
            while (CheckAnswer) { }
            UserResponce = UserResponce.ToLower();

            return UserResponce;
        }
        #endregion
    }
}
