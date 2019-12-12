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

            while (result == null)
            {
                knowledgeBase.Rules = knowledgeBase.Rules.Except(ruleWorkList.ItWorked).ToList();

                for (int i = 0; i < knowledgeBase.Rules.Count; i++)//foreach(Rule rule in knowledgeBase.Rules)
                {
                    Rule rule = knowledgeBase.Rules[i];

                    if (ReadChildNodesRec(rule.Antecedent.FirstChild))
                    {
                        if (rule.Consequent[0].Contains('?')) //Добавляем факт из вопроса
                        {
                            rule.Consequent = RuleManager.Sequentialization(rule.Consequent);
                            string waitAnswerResult = AskQuestion(rule);

                            rule.Consequent[0] += ": " + waitAnswerResult;
                            dialog.Invoke(new Action(() => dialog.AppendText(rule.Consequent[1] + "\n" + waitAnswerResult + "\n\n")));
                            workMember.Facts.Add(rule.Consequent[0]);
                        }
                        else if (rule.Consequent[0].Contains('.')) //Результат
                        {
                            result = rule.Consequent[0];
                            dialog.Invoke(new Action(() => dialog.AppendText(result + "\n\n")));
                        }
                        else //Добавляем факт промежуточной гипотезы
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
                if (rule.Consequent[0].Contains('.'))
                {
                    results.Add(rule);
                }
            }

            answer.Invoke(new Action(() => answer.Items.AddRange((from res in results select res.Name).ToArray())));

            Rule selectedRule = new Rule();
            string name = AskQuestion();
            #endregion
            
            // 1. Обход антецедента(-ов) гипотез(-ы) и сбор фактов
            // 2. Сбор правил, консеквенты которых, удовлетворяют фактам
            // 3. Пока результат null, возвращаться на (1)
            // 4. Присвоить результату список фактов, которые указывают на правило с вопросом

            foreach (Rule rule in results) // находим и запоминаем правила-ответ, которое выбрал пользователь 
            {
                if (rule.Name == name)
                {
                    selectedRule = rule;
                }
            }

            List<string> startQuestions = new List<string>();
            for (int i = 0; i < knowledgeBase.Rules.Count; i++)
            {
                if (knowledgeBase.Rules[i].Consequent[0].Contains("?"))
                {
                    startQuestions.Add(RuleManager.Sequentialization(knowledgeBase.Rules[i].Consequent)[0]);
                }
            }
            List<string> mainFactsRule = FindFactsInRules(selectedRule);

            List<string> finalResults = new List<string>();
            for(int i = 0; i < mainFactsRule.Count; i++)
            {
                for (int j = 0; j < startQuestions.Count; j++)
                {
                    if (mainFactsRule[i].Contains(startQuestions[j]))
                    {
                        finalResults.Add(mainFactsRule[i]);
                    }
                }
            }

            for (int i = 0; i < finalResults.Count; i++)
            {
                dialog.Invoke(new Action(() => dialog.AppendText(finalResults[i] + "\n")));
            }

            dialog.Invoke(new Action(() => dialog.AppendText("\nКонец")));
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
            if (xmlNode.Name == "fact")
            {
                if (workMember.Facts.Contains(xmlNode.InnerText))
                {
                    return true;
                }
            }

            List<object> facts = new List<object>();

            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.Name == "or" || node.Name == "and" || node.Name == "not")
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
                bool contains = true;

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
        private string[] ReadFactsRec(XmlNode xmlNode)
        {
            List<string> facts = new List<string>();

            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.Name == "not") continue;

                if (node.Name == "or" || node.Name == "and")
                {
                    facts.AddRange(ReadFactsRec(node));
                }
                else if (node.Name == "fact")
                {
                    facts.Add(node.InnerText);
                }
            }

            return facts.ToArray();
        }

        private void FindFactsInRules(Rule selectedRule, ref List<string> mainListFacts)
        {
            string[] tempFacts = ReadFactsRec(selectedRule.Antecedent);
            for (int i = 0; i < tempFacts.Length; i++) // проходимся по списку правил Базы Знаний
            {
                for (int j = 0; j < knowledgeBase.Rules.Count; j++) // сравниваем консеквент правила БЗ со списком 
                {
                    if (knowledgeBase.Rules[j].Consequent.Contains(tempFacts[i]))
                    {
                        FindFactsInRules(knowledgeBase.Rules[j], ref mainListFacts);
                    }
                }
                if (!mainListFacts.Contains(tempFacts[i]))
                {
                    mainListFacts.Add(tempFacts[i]);
                }               

            }
        }

        private List<string> FindFactsInRules(Rule selectedRule)
        {
            List<string> tempList = new List<string>();
            string[] tempFacts = ReadFactsRec(selectedRule.Antecedent);
            for (int i = 0; i < tempFacts.Length; i++) // проходимся по списку правил Базы Знаний
            {
                for (int j = 0; j < knowledgeBase.Rules.Count; j++) // сравниваем консеквент правила БЗ со списком 
                {
                    if (knowledgeBase.Rules[j].Consequent.Contains(tempFacts[i]))
                    {
                        tempList.AddRange(FindFactsInRules(knowledgeBase.Rules[j]));
                    }
                }

                if (!tempList.Contains(tempFacts[i]))
                {
                    tempList.Add(tempFacts[i]);
                }
            }

            return tempList;
        }
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
