using System.Xml;

namespace Lab_2
{
    class Rule
    {
        public string Name { get; set; }
        public XmlNode Antecedent { get; set; }
        public string[] Consequent { get; set; }
    }
}
