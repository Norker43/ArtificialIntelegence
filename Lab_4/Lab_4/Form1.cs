using Lab_4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_4
{
    public partial class Form1 : Form
    {
        RelativeMajority relativeMajority;
        ClearWinner clearWinner;
        Kopland kopland;
        Simpson simpson;
        Board board;
        DataGridView[] dgvs;
        List<Expert> experts;

        public Form1()
        {
            InitializeComponent();
            experts = new List<Expert>();
            dgvs = new DataGridView[] { clear_winner_dgv, kopland_dgv, simpson_dgv, board_dgv };
        }

        private void begin_Click(object sender, EventArgs e)
        {
            EnabledControls(true);
            relativeMajority = new RelativeMajority((int)alternatives_count.Value);
            clearWinner = new ClearWinner();
            kopland = new Kopland();
            simpson = new Simpson();
            board = new Board();

            for (int i = 0; i < (int)experts_count.Value; i++)
            {
                Expert expert = new Expert("Эксперт " + (i + 1), (int)alternatives_count.Value);
                experts.Add(expert);
            }
            relativeMajority.Experts = experts;
            current_expert_name.Text = experts[0].Name;

            for (int i = 0; i < (int)alternatives_count.Value; i++)
            {
                alternatives.Items.Add("Альтернатива " + (i + 1));
                relative_majority_dgv.Rows.Add(alternatives.Items[i].ToString(), "0", "0,00");
            }

            for (int i = 0; i < dgvs.Length; i++)
            {
                for (int j = 0; j < (int)experts_count.Value; j++)
                {
                    dgvs[i].Columns.Add("expert" + j, "Эксперт " + (j + 1));
                }
                dgvs[i].Rows.Add((int)alternatives_count.Value);
            }
        }

        private void discard_Click(object sender, EventArgs e)
        {
            EnabledControls(false);
            relative_majority_dgv.Rows.Clear();
            alternatives.Items.Clear();
            for (int i = 0; i < dgvs.Length; i++)
            {
                dgvs[i].Rows.Clear();
                dgvs[i].Columns.Clear();
            }
            winners.Items.Clear();
            experts.Clear();
        }

        private void genarate_Click(object sender, EventArgs e)
        {
            experts.Clear();
            Random random = new Random();
            List<int> numbers = new List<int>();

            for (int i = 1; i < (int)alternatives_count.Value + 1; i++)
            {
                numbers.Add(i);
            }

            for (int i = 0; i < (int)experts_count.Value; i++)
            {
                List<int> temp = new List<int>();
                temp.AddRange(numbers);
                Expert expert = new Expert("Эксперт " + (i + 1), (int)alternatives_count.Value);

                for (int j = 0; j < alternatives_count.Value; j++)
                {
                    int p = random.Next(0, temp.Count);
                    expert.Preferences[j] = temp[p];
                    temp.RemoveAt(p);
                }

                experts.Add(expert);
            }

            clearWinner.Experts = experts;
            kopland.Experts = experts;
            simpson.Experts = experts;
            board.Experts = experts;

            for (int i = 0; i < dgvs.Length; i++)
            {
                for (int j = 0; j < dgvs[i].Columns.Count; j++)
                {
                    for (int k = 0; k < experts[j].Preferences.Length; k++)
                    {
                        dgvs[i].Rows[k].Cells[j].Value = experts[j].Preferences[k];
                    }
                }
            }

            genarate.Enabled = false;
        }

        private void to_vote_Click(object sender, EventArgs e)
        {
            if (alternatives.SelectedIndex > -1)
            {
                double[,] values = relativeMajority.Execute(alternatives.SelectedIndex);

                for (int i = 0; i < (int)alternatives_count.Value; i++)
                {
                    for (int j = 1; j < 3; j++)
                    {
                        relative_majority_dgv.Rows[i].Cells[j].Value = values[i, j - 1];
                    }
                }

                if (relativeMajority.Index >= (int)experts_count.Value)
                {
                    int count = 0;
                    string winner = "";
                    for (int i = 0; i < (int)alternatives_count.Value; i++)
                    {
                        if (count < Convert.ToInt32(relative_majority_dgv.Rows[i].Cells[1].Value))
                        {
                            count = Convert.ToInt32(relative_majority_dgv.Rows[i].Cells[1].Value);
                            winner = relative_majority_dgv.Rows[i].Cells[0].Value.ToString();
                        }
                    }

                    to_vote.Enabled = false;
                    winners.Items.Add("Относительное большинство, победитель: " + winner);
                    current_expert_name.Text = "";
                    return;
                }

                current_expert_name.Text = relativeMajority.Experts[relativeMajority.Index].Name.ToString();
            }
            else
            {
                MessageBox.Show("Альтернатива не выбрана.", "Важно", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EnabledControls(bool x)
        {
            if (x)
            {
                begin.Enabled = !x;
                relative_majority_dgv.Enabled = x;
                alternatives.Enabled = x;
                to_vote.Enabled = x;
                genarate.Enabled = x;
                clear_winner_dgv.Enabled = x;
                kopland_dgv.Enabled = x;
                simpson_dgv.Enabled = x;
                board_dgv.Enabled = x;
                clear_winner_ready.Enabled = x;
                simpson_ready.Enabled = x;
                kopland_ready.Enabled = x;
                board_ready.Enabled = x;
            }
            else
            {
                begin.Enabled = !x;
                relative_majority_dgv.Enabled = x;
                alternatives.Enabled = x;
                to_vote.Enabled = x;
                genarate.Enabled = x;
                clear_winner_dgv.Enabled = x;
                kopland_dgv.Enabled = x;
                simpson_dgv.Enabled = x;
                board_dgv.Enabled = x;
                clear_winner_ready.Enabled = x;
                simpson_ready.Enabled = x;
                kopland_ready.Enabled = x;
                board_ready.Enabled = x;
            }
        }

        private void clear_winner_ready_Click(object sender, EventArgs e)
        {
            winners.Items.Add("Явный победитель, победитель:" + clearWinner.Execute());
        }

        private void kopland_ready_Click(object sender, EventArgs e)
        {
            winners.Items.Add("Явный победитель, победитель:" + clearWinner.Execute());
        }

        private void simpson_ready_Click(object sender, EventArgs e)
        {

        }

        private void board_ready_Click(object sender, EventArgs e)
        {

        }
    }
}
