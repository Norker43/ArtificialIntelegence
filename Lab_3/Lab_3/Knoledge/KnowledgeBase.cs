using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab_3
{
    class KnowledgeBase
    {
        public List<Frame> Frames { get; set; }
        public TreeView FrameTree { get; set; }

        public KnowledgeBase()
        {
            Frames = new List<Frame>();
        }

        public void LoadOut(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);

            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xNode in xRoot)
            {
                Frame frame = new Frame();

                if (xNode.Attributes.Count > 0)
                {
                    XmlNode frameName = xNode.Attributes.GetNamedItem("name");
                    if (frameName != null)
                    {
                        frame.Name = frameName.Value;
                    }

                    XmlNode frameParent = xNode.Attributes.GetNamedItem("parent");
                    if (frameParent != null)
                    {
                        foreach (Frame parent in Frames)
                        {
                            if (frameParent.Value == parent.Name)
                            {
                                frame.Parent = parent;
                            }
                        }
                    }
                }

                frame.Slots = (from XmlNode slot in xNode.ChildNodes //слоты
                               from XmlNode val in slot.ChildNodes    //значение слота
                               from XmlNode type in slot.ChildNodes   //тип слота
                               from XmlNode demon in slot.ChildNodes  //процедура
                               where slot.Name == "Slot" && slot.Attributes.Count > 0
                               where val.Name == "value"
                               where type.Name == "datatype"
                               where demon.Name == "demon"
                               select new Slot
                               {
                                   Name = slot.Attributes.GetNamedItem("name").Value,
                                   Value = val.InnerText,
                                   DataType = type.InnerText,
                                   Demon = demon.InnerText
                               }).ToList();

                Frames.Add(frame);
            }

            Treefication();
        }

        public void LoadIn(string path)
        {

        }

        private void Treefication()
        {
            List<Frame> frames = new List<Frame>();
            frames.AddRange(Frames);
            List<Frame> workedFrames = new List<Frame>();

            for (int i = 0; i < frames.Count; i++)
            {
                if (frames[i].Parent == null)
                {
                    FrameTree.Nodes.Add(frames[i].Name);
                    workedFrames.Add(frames[i]);
                }
            }

            TreeNodeCollection nodes = FrameTree.Nodes;
            Stack<TreeNodeCollection> stack = new Stack<TreeNodeCollection>();

            while (frames.Count != 0)
            {
                frames = frames.Except(workedFrames).ToList();

                for (int i = 0; i < nodes.Count; i++)
                {
                    TreeNode node = nodes[i];

                    if (node.Nodes.Count == 0)
                    {
                        List<Frame> childs = (from frame in frames
                                              where frame.Parent.Name == node.Text
                                              select frame).ToList();
                        node.Nodes.AddRange((from child in childs
                                             select new TreeNode()
                                             {
                                                 Text = child.Name
                                             }).ToArray());
                        workedFrames.AddRange(childs);

                        if (childs.Count != 0)
                        {
                            stack.Push(nodes);
                            nodes = node.Nodes;
                            break;
                        }
                    }

                    if (i == nodes.Count - 1)
                    {
                        nodes = stack.Pop();
                    }
                }
            }
        }
    }
}
