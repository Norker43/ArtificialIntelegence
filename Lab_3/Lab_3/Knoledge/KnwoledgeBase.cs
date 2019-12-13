using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab_3
{
    class KnoledgeBase
    {
        public List<Frame> Frames { get; set; }
        public TreeView FrameTree { get; set; }

        public KnoledgeBase()
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
        }

        public void LoadIn(string path)
        {

        }

        private void FrameTreeFilling()
        {
            Frame root = new Frame();

            for (int i = 0; i < Frames.Count; i++)
            {
                if (Frames[i].Parent == null)
                {
                    root = Frames[i];
                    FrameTree.Nodes.Add(root.Name);
                }
            }

            List<TreeNode> childs = (from frame in Frames
                                  where frame.Parent.Name == root.Name
                                  select new TreeNode 
                                  { 
                                      Text = frame.Name
                                  }).ToList();
            FrameTree.Nodes.AddRange(childs.ToArray());
        }
    }
}
