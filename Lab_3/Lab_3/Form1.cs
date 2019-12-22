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
        Frame viewFrame;
        KnowledgeBase knowledgeBase;
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

            knowledgeBase = new KnowledgeBase()
            {
                FrameTree = frames_tree
            };
            knowledgeBase.LoadOut(path.Text);

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

            viewFrame = new Frame()
            {
                Name = "UserFrame"
            };

            foreach (Slot slot in knowledgeBase.Frames[0].Slots)
            {
                viewFrame.Slots.Add(new Slot()
                {
                    Name = slot.Name,
                    Value = slot.Value,
                    DataType = slot.DataType,
                    Demon = slot.Demon
                });
            }

            for (int i = 0; i < viewFrame.Slots.Count; i++)
            {
                dialog_dvg.Rows.Add(viewFrame.Slots[i].Name, "",
                    viewFrame.Slots[i].DataType, viewFrame.Slots[i].Demon);
            }

            dialog_dvg.Rows[0].Cells[1].Value = "Методическое пособие";
            dialog_dvg.Rows[1].Cells[1].Value = "Малых А. А.";
            dialog_dvg.Rows[2].Cells[1].Value = "Лаб. практикум";
            dialog_dvg.Rows[3].Cells[1].Value = "38";
        }

        private void discard_Click(object sender, EventArgs e)
        {
            EnabledControls(true);
            helper.Text = "";
            dialog_dvg.Rows.Clear();
            viewFrame = null;
            inferenceMachine = null;
        }

        private void apply_Click(object sender, EventArgs e)
        {
            inferenceMachine = new LogicalInferenceMachine(knowledgeBase)
            {
                DialogDGV = dialog_dvg,
                Reasoning = reasoning
            };

            for (int i = 0; i < dialog_dvg.Rows.Count; i++)
            {
                viewFrame.Slots[i].Value = dialog_dvg.Rows[i].Cells[1].Value.ToString();
            }

            inferenceMachine.LogicalInferenceStart(viewFrame);
        }

        private void save_Click(object sender, EventArgs e)
        {
            List<Slot> slots = new List<Slot>();

            for (int i = 0; i < edit_dvg.Rows.Count; i++)
            {
                if (edit_dvg.Rows[i].Cells[0].Value != null)
                {
                    slots.Add(new Slot()
                    {
                        Name = edit_dvg.Rows[i].Cells[0].Value.ToString(),
                        Value = edit_dvg.Rows[i].Cells[1].Value.ToString(),
                        DataType = edit_dvg.Rows[i].Cells[2].Value.ToString(),
                        Demon = edit_dvg.Rows[i].Cells[3].Value.ToString()
                    });
                }
            }
            viewFrame.Slots = slots;

            for (int i = 0; i < knowledgeBase.Frames.Count; i++)
            {
                if (knowledgeBase.Frames[i].Name == viewFrame.Name)
                {
                    knowledgeBase.Frames[i] = viewFrame;
                }
            }

            knowledgeBase.LoadIn(path.Text);
            save.Enabled = false;
        }

        private void frames_tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            edit_dvg.Rows.Clear();
            save.Enabled = true;

            if (frames_tree.SelectedNode != null)
            {
                for (int i = 0; i < knowledgeBase.Frames.Count; i++)
                {
                    if (knowledgeBase.Frames[i].Name == frames_tree.SelectedNode.Text)
                    {
                        viewFrame = knowledgeBase.Frames[i];
                        break;
                    }
                }

                for (int i = 0; i < viewFrame.Slots.Count; i++)
                {
                    edit_dvg.Rows.Add(viewFrame.Slots[i].Name, viewFrame.Slots[i].Value,
                        viewFrame.Slots[i].DataType, viewFrame.Slots[i].Demon);
                }
            }
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
