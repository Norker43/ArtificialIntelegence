using System;
using System.Threading;
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
        Thread lim;
        KnowledgeBase knowledgeBase;
        LogicalInferenceMachine inferenceMachine;

        public Form1()
        {
            InitializeComponent();
            knowledgeBase = new KnowledgeBase();
            response.Items.Clear();
        }

        private void read_Click(object sender, EventArgs e) // Прочитать файл
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }

            textBox1.SelectionStart = textBox1.Text.Length - 1;
            knowledgeBase.LoadOut(textBox1.Text);
            DVGFilling();

            begin.Enabled = true;
            checkBox1.Enabled = true;
        }

        private void begin_Click(object sender, EventArgs e) // Начать
        {
            discard.Enabled = true;
            EnabledControls(false);

            inferenceMachine = new LogicalInferenceMachine(knowledgeBase)
            {
                question = textBox2,
                answer = response,
                dialog = richTextBox1,
                reasoning = richTextBox2
            };
            
            if (checkBox1.Checked == false)
            {
                lim = new Thread(inferenceMachine.LogicalInferenceStart);
            }
            else
            {
                lim = new Thread(inferenceMachine.LogicalInverseInferenceStart);
            }

            lim.Start();
        }

        private void discard_Click(object sender, EventArgs e) // Сбросить
        {
            lim.Abort();
            textBox2.Text = "";
            response.Items.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            discard.Enabled = false;
            EnabledControls(true);
            inferenceMachine = null;
            knowledgeBase.Clear();
            knowledgeBase.LoadOut(textBox1.Text);
        }

        private void response_SelectionChangeCommitted(object sender, EventArgs e)
        {
            inferenceMachine.UserResponce = response.SelectedItem.ToString();
            textBox2.Text = "";
            response.Items.Clear();
            inferenceMachine.CheckAnswer = false;
        }

        private void refresh_Click(object sender, EventArgs e) // Обновить базу знаний
        {
            knowledgeBase.LoadIn(textBox1.Text, FileSwap());
        }

        private void удалитьСтрокуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCellAddress.Y);
            }
            else
            {
                MessageBox.Show("Выделите всю строку.");
            }
        }

        private void EnabledControls(bool x)
        {
            read.Enabled = x;
            begin.Enabled = x;
            checkBox1.Enabled = x;
            dataGridView1.Enabled = x;
            refresh.Enabled = x;
        }

        private void DVGFilling()
        {
            for (int i = 0; i < knowledgeBase.Rules.Count; i++)
            {
                dataGridView1.Rows.Add(
                    knowledgeBase.Rules[i].Name, 
                    knowledgeBase.Rules[i].Antecedent, 
                    knowledgeBase.Rules[i].Consequent
                    );
            }
        }

        private List<Rule> FileSwap()
        {
            List<Rule> rules = new List<Rule>();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                rules.Add(new Rule {
                    Name = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    //Antecedent = new string[] { dataGridView1.Rows[i].Cells[2].Value.ToString() },
                    Consequent = new string[] { dataGridView1.Rows[i].Cells[3].Value.ToString() }
                });
            }

            File.Delete(textBox1.Text);
            return rules;
        }
    }
}
