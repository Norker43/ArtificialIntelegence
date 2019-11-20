using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Lab_2
{
    class KnowledgeBase
    {
        //Знания хранятся в виде списка правил в xml(json)
        //Этот класс будет работать с xml(json)

        public List<Rule> Rules { get; set; }

        public KnowledgeBase()
        {
            Rules = new List<Rule>();
        }

        public void LoadOut(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);

            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xNode in xRoot)
            {
                Rule rule = new Rule();

                if (xNode.Attributes.Count > 0)
                {
                    XmlNode attribute = xNode.Attributes.GetNamedItem("name");
                    if (attribute != null)
                    {
                        rule.Name = attribute.Value;
                    }
                }

                foreach (XmlNode childNode in xNode.ChildNodes)
                {
                    if (childNode.Name == "ancendant")
                    {
                        rule.Ancendant = childNode.InnerText;
                    }

                    if (childNode.Name == "consequent")
                    {
                        rule.Consequent = childNode.InnerText;
                    }
                }

                Rules.Add(rule);
            }
        }

        public void LoadIn(string path, List<Rule> rules)
        {
            XDocument xDoc = new XDocument();
            XElement Rules = new XElement("Rules");

            foreach (Rule rule in rules)
            {
                XElement xRule = new XElement("Rule");
                xRule.Add(new XAttribute("name", rule.Name));
                xRule.Add(new XElement("ancendant", rule.Ancendant));
                xRule.Add(new XElement("consequent", rule.Consequent));
                Rules.Add(xRule);
            }

            xDoc.Add(Rules);
            xDoc.Save(path);

            LoadOut(path);
        }

        public void Clear()
        {
            Rules.Clear();
        }
    }
}
