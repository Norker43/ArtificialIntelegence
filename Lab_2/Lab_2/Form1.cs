using System;
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
        WorkMember workMember;
        KnowledgeBase knowledgeBase;
        LogicalInferenceMachine inferenceMachine;

        public Form1()
        {
            InitializeComponent();
            knowledgeBase = new KnowledgeBase();
            inferenceMachine = new LogicalInferenceMachine(knowledgeBase);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }

            textBox1.SelectionStart = textBox1.Text.Length - 1;

            #region EnabledControls
            button2.Enabled = true;
            button3.Enabled = true;
            checkBox1.Enabled = true;
            #endregion
        }

        private void button2_Click(object sender, EventArgs e) //Начать
        {
            EnabledControls(false);

        }

        private void button3_Click(object sender, EventArgs e) //Сбросить
        {
            EnabledControls(true);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void EnabledControls(bool x)
        {
            button1.Enabled = x;
            button2.Enabled = x;
            checkBox1.Enabled = x;
        }
    }
}
