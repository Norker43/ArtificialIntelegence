using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3.Knowledge;

namespace Lab_3
{
    class LogicalInferenceMachine
    {
        KnowledgeBase knowledgeBase;
        delegate string Procedure(string value);

        public DataGridView DialogDGV { get; set; }
        public RichTextBox Reasoning { get; set; }

        public LogicalInferenceMachine(KnowledgeBase knowledgeBase)
        {
            this.knowledgeBase = knowledgeBase;
        }

        public void LogicalInferenceStart(Frame userFrame)
        {
            List<Frame> frames = new List<Frame>();
            frames.AddRange((from frame in knowledgeBase.Frames select frame).ToList());

            for (int i = 0; i < frames.Count; i++)
            {
                for (int j = 0; j < userFrame.Slots.Count; j++)
                {
                    if (frames[i].Name == userFrame.Slots[j].Value)
                    {
                        userFrame.Parent = frames[i];
                    }
                }
            }

            while (userFrame.Parent != null)
            {
                if (userFrame.Slots.Count == userFrame.Parent.Slots.Count)
                {
                    for (int i = 0; i < userFrame.Slots.Count; i++)
                    {
                        if (userFrame.Slots[i].Value == "" && userFrame.Parent.Slots[i].Value != "")
                        {
                            userFrame.Slots[i].Value = userFrame.Parent.Slots[i].Value;

                            Explanation(userFrame.Slots[i], userFrame.Parent);

                            if (userFrame.Parent.Slots[i].Demon != "")
                            {
                                userFrame.Slots[i].Demon = userFrame.Parent.Slots[i].Demon;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                userFrame.Parent = userFrame.Parent.Parent;
            }

            foreach (Slot slot in userFrame.Slots)
            {
                if (slot.Demon != "")
                {
                    slot.Value = AttachedProcedureExecute(userFrame, AttachedProcedure.ProcedureParse(slot.Value));
                }
            }

            ReturnFrameIntoView(userFrame);
        }

        private void Explanation(Slot slot, Frame parent)
        {
            string explanationText = slot.Name + ": " + slot.Value + ", потому что " + parent.Name + "\n\n";
            Reasoning.Invoke(new Action(() => Reasoning.AppendText(explanationText)));
        }

        private void ReturnFrameIntoView(Frame userFrame)
        {
            DialogDGV.Rows.Clear();

            for (int i = 0; i < userFrame.Slots.Count; i++)
            {
                DialogDGV.Rows.Add(userFrame.Slots[i].Name, userFrame.Slots[i].Value, userFrame.Slots[i].DataType, userFrame.Slots[i].Demon);
            }
        }

        private string AttachedProcedureExecute(Frame userFrame, string[] names)
        {
            string value = "";
            Procedure procedure = null;

            foreach (Slot slot in userFrame.Slots)
            {
                if (slot.Name == names[1])
                {
                    value = slot.Value;
                }
            }

            if (names[0] == "GetTime")
            {
                procedure = AttachedProcedure.GetTime;
            }

            return procedure(value);
        }
    }
}
