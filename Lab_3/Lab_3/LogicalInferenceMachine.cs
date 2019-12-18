using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class LogicalInferenceMachine
    {
        private KnowledgeBase knowledgeBase;

        public DataGridView DialogDGV { get; set; }
        public RichTextBox Reasoning { get; set; }

        public LogicalInferenceMachine(KnowledgeBase knowledgeBase)
        {
            this.knowledgeBase = knowledgeBase;
        }

        public void LogicalInferenceStart(Frame userFrame)
        {
            List<Frame> frames = (from frame in knowledgeBase.Frames select frame).ToList();

            for (int i = 0; i < userFrame.Slots.Count; i++)
            {

            }
        }

        private void Explanation()
        {

        }
    }
}
