using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Form1 : Form
    {
        KnowledgeBase knowledgeBase;
        LogicalInferenceMachine inferenceMachine;

        public Form1()
        {
            InitializeComponent();
            knowledgeBase = new KnowledgeBase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }

            textBox1.SelectionStart = textBox1.Text.Length - 1;
            knowledgeBase.LoadOut(textBox1.Text);
            DVGFilling();

            #region EnabledControls
            button2.Enabled = true;
            button3.Enabled = true;
            checkBox1.Enabled = true;
            #endregion
        }

        private void button2_Click(object sender, EventArgs e) // Начать
        {
            EnabledControls(false);

            inferenceMachine = new LogicalInferenceMachine(knowledgeBase);
            if (checkBox1.Checked == false)
            {
                inferenceMachine.LogicalInferenceStart();
            }
            else
            {
                inferenceMachine.LogicalInverseInferenceStart();
            }
        }

        private void button3_Click(object sender, EventArgs e) // Сбросить
        {
            EnabledControls(true);

            inferenceMachine = null;
            knowledgeBase.Clear();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) // Обновить базу знаний
        {
            knowledgeBase.LoadIn(textBox1.Text, FileSwap());
        }

        private void удалитьСтрокуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCellAddress.Y);
        }

        private void EnabledControls(bool x)
        {
            button1.Enabled = x;
            button2.Enabled = x;
            checkBox1.Enabled = x;
            dataGridView1.Enabled = x;
            button4.Enabled = x;
        }

        private void DVGFilling()
        {
            for (int i = 0; i < knowledgeBase.Rules.Count; i++)
            {
                dataGridView1.Rows.Add(knowledgeBase.Rules[i].Name, knowledgeBase.Rules[i].Ancendant, knowledgeBase.Rules[i].Consequent);
            }
        }

        private List<Rule> FileSwap()
        {
            List<Rule> rules = new List<Rule>();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                rules.Add(new Rule {
                    Name = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    Ancendant = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    Consequent = dataGridView1.Rows[i].Cells[2].Value.ToString()
                });
            }

            File.Delete(textBox1.Text);
            return rules;
        }
    }
}
