using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab_2
{
    class KnowledgeBase
    {
        //Знания хранятся в виде списка правил в xml(json)
        //Этот класс будет работать с xml(json)
        NewKnowledge newKnowledge;
        List<Rule> rules;

        public KnowledgeBase()
        {
            newKnowledge = new NewKnowledge();
        }

        public void LoadOut(string path)
        {
            rules = new List<Rule>();
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

                rules.Add(rule);
            }
        }

        public void LoadIn()
        {

        }
    }
}
