using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form1 : Form
    {
        KnoledgeBase knoledgeBase;
        LogicalInferenceMachine inferenceMachine;

        public Form1()
        {
            InitializeComponent();
        }

        private void read_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path.Text = openFileDialog.FileName;
            }
            path.SelectionStart = path.Text.Length - 1;

            knoledgeBase = new KnoledgeBase()
            {
                FrameTree = frames_tree
            };
            knoledgeBase.LoadOut(path.Text);

            #region EnabledControlsInit
            begin.Enabled = true;
            frames_tree.Enabled = true;
            edit_dvg.Enabled = true;
            #endregion
        }

        private void begin_Click(object sender, EventArgs e)
        {
            EnabledControls(false);
            helper.Text = "Заполните, что можете.";
        }

        private void discard_Click(object sender, EventArgs e)
        {
            EnabledControls(true);
            helper.Text = "";
            inferenceMachine = null;
        }

        private void apply_Click(object sender, EventArgs e)
        {
            inferenceMachine = new LogicalInferenceMachine(knoledgeBase)
            {
                DialogDGV = dialog_dvg,
                Reasoning = reasoning
            };
            inferenceMachine.LogicalInferenceStart();
        }

        private void EnabledControls(bool x)
        {
            if (x)
            {
                read.Enabled = x;
                begin.Enabled = x;
                discard.Enabled = !x;
                dialog_dvg.Enabled = !x;
                apply.Enabled = !x;
                frames_tree.Enabled = x;
                edit_dvg.Enabled = x;
            }
            else
            {
                read.Enabled = x;
                begin.Enabled = x;
                discard.Enabled = !x;
                dialog_dvg.Enabled = !x;
                apply.Enabled = !x;
                frames_tree.Enabled = x;
                edit_dvg.Enabled = x;
            }
        }
    }
}
