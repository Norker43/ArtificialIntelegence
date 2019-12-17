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
        private KnowledgeBase knoledgeBase;

        public DataGridView DialogDGV { get; set; }
        public RichTextBox Reasoning { get; set; }

        public LogicalInferenceMachine(KnowledgeBase knoledgeBase)
        {
            this.knoledgeBase = knoledgeBase;
        }

        public void LogicalInferenceStart()
        {
            List<Frame> frames = (from frame in knoledgeBase.Frames select frame).ToList();


        }
    }
}
