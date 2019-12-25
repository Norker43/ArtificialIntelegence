namespace Lab_4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.alternatives_count = new System.Windows.Forms.NumericUpDown();
            this.experts_count = new System.Windows.Forms.NumericUpDown();
            this.discard = new System.Windows.Forms.Button();
            this.begin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.genarate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.current_expert_name = new System.Windows.Forms.TextBox();
            this.to_vote = new System.Windows.Forms.Button();
            this.alternatives = new System.Windows.Forms.ListBox();
            this.relative_majority_dgv = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vote_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vote_percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.clear_winner_ready = new System.Windows.Forms.Button();
            this.clear_winner_dgv = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.kopland_ready = new System.Windows.Forms.Button();
            this.kopland_dgv = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.simpson_ready = new System.Windows.Forms.Button();
            this.simpson_dgv = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.board_ready = new System.Windows.Forms.Button();
            this.board_dgv = new System.Windows.Forms.DataGridView();
            this.winners = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alternatives_count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.experts_count)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.relative_majority_dgv)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clear_winner_dgv)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kopland_dgv)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simpson_dgv)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.board_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.alternatives_count);
            this.groupBox1.Controls.Add(this.experts_count);
            this.groupBox1.Controls.Add(this.discard);
            this.groupBox1.Controls.Add(this.begin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Свойства";
            // 
            // alternatives_count
            // 
            this.alternatives_count.Location = new System.Drawing.Point(142, 45);
            this.alternatives_count.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.alternatives_count.Name = "alternatives_count";
            this.alternatives_count.Size = new System.Drawing.Size(301, 21);
            this.alternatives_count.TabIndex = 6;
            this.alternatives_count.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // experts_count
            // 
            this.experts_count.Location = new System.Drawing.Point(142, 19);
            this.experts_count.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.experts_count.Name = "experts_count";
            this.experts_count.Size = new System.Drawing.Size(301, 21);
            this.experts_count.TabIndex = 3;
            this.experts_count.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // discard
            // 
            this.discard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.discard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discard.Location = new System.Drawing.Point(449, 43);
            this.discard.Name = "discard";
            this.discard.Size = new System.Drawing.Size(92, 23);
            this.discard.TabIndex = 5;
            this.discard.Text = "Сбросить";
            this.discard.UseVisualStyleBackColor = true;
            this.discard.Click += new System.EventHandler(this.discard_Click);
            // 
            // begin
            // 
            this.begin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.begin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.begin.Location = new System.Drawing.Point(449, 17);
            this.begin.Name = "begin";
            this.begin.Size = new System.Drawing.Size(92, 23);
            this.begin.TabIndex = 4;
            this.begin.Text = "Начать";
            this.begin.UseVisualStyleBackColor = true;
            this.begin.Click += new System.EventHandler(this.begin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Кол-во альтернатив:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Кол-во экспертов:";
            // 
            // genarate
            // 
            this.genarate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.genarate.Enabled = false;
            this.genarate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.genarate.Location = new System.Drawing.Point(6, 311);
            this.genarate.Name = "genarate";
            this.genarate.Size = new System.Drawing.Size(536, 27);
            this.genarate.TabIndex = 5;
            this.genarate.Text = "Генерация";
            this.genarate.UseVisualStyleBackColor = true;
            this.genarate.Click += new System.EventHandler(this.genarate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.genarate);
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 344);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Модели";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(536, 286);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.current_expert_name);
            this.tabPage1.Controls.Add(this.to_vote);
            this.tabPage1.Controls.Add(this.alternatives);
            this.tabPage1.Controls.Add(this.relative_majority_dgv);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(528, 260);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Относительное большинство";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // current_expert_name
            // 
            this.current_expert_name.Enabled = false;
            this.current_expert_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.current_expert_name.Location = new System.Drawing.Point(0, 0);
            this.current_expert_name.Name = "current_expert_name";
            this.current_expert_name.Size = new System.Drawing.Size(120, 21);
            this.current_expert_name.TabIndex = 3;
            // 
            // to_vote
            // 
            this.to_vote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.to_vote.Enabled = false;
            this.to_vote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.to_vote.Location = new System.Drawing.Point(0, 231);
            this.to_vote.Name = "to_vote";
            this.to_vote.Size = new System.Drawing.Size(120, 29);
            this.to_vote.TabIndex = 2;
            this.to_vote.Text = "Голосовать";
            this.to_vote.UseVisualStyleBackColor = true;
            this.to_vote.Click += new System.EventHandler(this.to_vote_Click);
            // 
            // alternatives
            // 
            this.alternatives.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.alternatives.Enabled = false;
            this.alternatives.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.alternatives.FormattingEnabled = true;
            this.alternatives.ItemHeight = 15;
            this.alternatives.Location = new System.Drawing.Point(0, 26);
            this.alternatives.Name = "alternatives";
            this.alternatives.Size = new System.Drawing.Size(120, 199);
            this.alternatives.TabIndex = 1;
            // 
            // relative_majority_dgv
            // 
            this.relative_majority_dgv.AllowUserToAddRows = false;
            this.relative_majority_dgv.AllowUserToDeleteRows = false;
            this.relative_majority_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.relative_majority_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle51.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle51.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle51.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle51.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.relative_majority_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle51;
            this.relative_majority_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.relative_majority_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.vote_count,
            this.vote_percent});
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle54.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle54.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle54.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle54.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle54.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.relative_majority_dgv.DefaultCellStyle = dataGridViewCellStyle54;
            this.relative_majority_dgv.Enabled = false;
            this.relative_majority_dgv.Location = new System.Drawing.Point(126, 0);
            this.relative_majority_dgv.Name = "relative_majority_dgv";
            this.relative_majority_dgv.RowHeadersVisible = false;
            this.relative_majority_dgv.Size = new System.Drawing.Size(402, 260);
            this.relative_majority_dgv.TabIndex = 0;
            // 
            // name
            // 
            this.name.HeaderText = "Имя альтернативы";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // vote_count
            // 
            dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.vote_count.DefaultCellStyle = dataGridViewCellStyle52;
            this.vote_count.HeaderText = "Количество голосов";
            this.vote_count.Name = "vote_count";
            this.vote_count.ReadOnly = true;
            // 
            // vote_percent
            // 
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.vote_percent.DefaultCellStyle = dataGridViewCellStyle53;
            this.vote_percent.HeaderText = "Процент голосов, %";
            this.vote_percent.Name = "vote_percent";
            this.vote_percent.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.clear_winner_ready);
            this.tabPage2.Controls.Add(this.clear_winner_dgv);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(528, 260);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Явный победитель";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // clear_winner_ready
            // 
            this.clear_winner_ready.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clear_winner_ready.Enabled = false;
            this.clear_winner_ready.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clear_winner_ready.Location = new System.Drawing.Point(0, 233);
            this.clear_winner_ready.Name = "clear_winner_ready";
            this.clear_winner_ready.Size = new System.Drawing.Size(528, 27);
            this.clear_winner_ready.TabIndex = 6;
            this.clear_winner_ready.Text = "Подсчет";
            this.clear_winner_ready.UseVisualStyleBackColor = true;
            this.clear_winner_ready.Click += new System.EventHandler(this.clear_winner_ready_Click);
            // 
            // clear_winner_dgv
            // 
            this.clear_winner_dgv.AllowUserToAddRows = false;
            this.clear_winner_dgv.AllowUserToDeleteRows = false;
            this.clear_winner_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clear_winner_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle55.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle55.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle55.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle55.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle55.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clear_winner_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle55;
            this.clear_winner_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle56.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle56.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle56.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle56.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.clear_winner_dgv.DefaultCellStyle = dataGridViewCellStyle56;
            this.clear_winner_dgv.Location = new System.Drawing.Point(0, 0);
            this.clear_winner_dgv.Name = "clear_winner_dgv";
            this.clear_winner_dgv.RowHeadersVisible = false;
            this.clear_winner_dgv.Size = new System.Drawing.Size(528, 227);
            this.clear_winner_dgv.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.kopland_ready);
            this.tabPage3.Controls.Add(this.kopland_dgv);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(528, 260);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Копланд";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // kopland_ready
            // 
            this.kopland_ready.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kopland_ready.Enabled = false;
            this.kopland_ready.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kopland_ready.Location = new System.Drawing.Point(0, 233);
            this.kopland_ready.Name = "kopland_ready";
            this.kopland_ready.Size = new System.Drawing.Size(528, 27);
            this.kopland_ready.TabIndex = 7;
            this.kopland_ready.Text = "Подсчет";
            this.kopland_ready.UseVisualStyleBackColor = true;
            this.kopland_ready.Click += new System.EventHandler(this.kopland_ready_Click);
            // 
            // kopland_dgv
            // 
            this.kopland_dgv.AllowUserToAddRows = false;
            this.kopland_dgv.AllowUserToDeleteRows = false;
            this.kopland_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kopland_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle57.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle57.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle57.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle57.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle57.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.kopland_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle57;
            this.kopland_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle58.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle58.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle58.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle58.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle58.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle58.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.kopland_dgv.DefaultCellStyle = dataGridViewCellStyle58;
            this.kopland_dgv.Location = new System.Drawing.Point(0, 0);
            this.kopland_dgv.Name = "kopland_dgv";
            this.kopland_dgv.RowHeadersVisible = false;
            this.kopland_dgv.Size = new System.Drawing.Size(528, 227);
            this.kopland_dgv.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.simpson_ready);
            this.tabPage4.Controls.Add(this.simpson_dgv);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(528, 260);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Симпсон";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // simpson_ready
            // 
            this.simpson_ready.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpson_ready.Enabled = false;
            this.simpson_ready.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.simpson_ready.Location = new System.Drawing.Point(0, 233);
            this.simpson_ready.Name = "simpson_ready";
            this.simpson_ready.Size = new System.Drawing.Size(528, 27);
            this.simpson_ready.TabIndex = 7;
            this.simpson_ready.Text = "Подсчет";
            this.simpson_ready.UseVisualStyleBackColor = true;
            this.simpson_ready.Click += new System.EventHandler(this.simpson_ready_Click);
            // 
            // simpson_dgv
            // 
            this.simpson_dgv.AllowUserToAddRows = false;
            this.simpson_dgv.AllowUserToDeleteRows = false;
            this.simpson_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpson_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle59.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle59.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle59.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle59.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.simpson_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle59;
            this.simpson_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle60.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle60.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle60.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle60.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle60.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.simpson_dgv.DefaultCellStyle = dataGridViewCellStyle60;
            this.simpson_dgv.Location = new System.Drawing.Point(0, 0);
            this.simpson_dgv.Name = "simpson_dgv";
            this.simpson_dgv.RowHeadersVisible = false;
            this.simpson_dgv.Size = new System.Drawing.Size(528, 227);
            this.simpson_dgv.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.board_ready);
            this.tabPage5.Controls.Add(this.board_dgv);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(528, 260);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Борд";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // board_ready
            // 
            this.board_ready.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.board_ready.Enabled = false;
            this.board_ready.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.board_ready.Location = new System.Drawing.Point(0, 233);
            this.board_ready.Name = "board_ready";
            this.board_ready.Size = new System.Drawing.Size(528, 27);
            this.board_ready.TabIndex = 7;
            this.board_ready.Text = "Подсчет";
            this.board_ready.UseVisualStyleBackColor = true;
            this.board_ready.Click += new System.EventHandler(this.board_ready_Click);
            // 
            // board_dgv
            // 
            this.board_dgv.AllowUserToAddRows = false;
            this.board_dgv.AllowUserToDeleteRows = false;
            this.board_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.board_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle49.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.board_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle49;
            this.board_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle50.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle50.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle50.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle50.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.board_dgv.DefaultCellStyle = dataGridViewCellStyle50;
            this.board_dgv.Location = new System.Drawing.Point(0, 0);
            this.board_dgv.Name = "board_dgv";
            this.board_dgv.RowHeadersVisible = false;
            this.board_dgv.Size = new System.Drawing.Size(528, 227);
            this.board_dgv.TabIndex = 1;
            // 
            // winners
            // 
            this.winners.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winners.Enabled = false;
            this.winners.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.winners.FormattingEnabled = true;
            this.winners.ItemHeight = 16;
            this.winners.Location = new System.Drawing.Point(13, 443);
            this.winners.Name = "winners";
            this.winners.Size = new System.Drawing.Size(548, 84);
            this.winners.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 547);
            this.Controls.Add(this.winners);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voting";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alternatives_count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.experts_count)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.relative_majority_dgv)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clear_winner_dgv)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kopland_dgv)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.simpson_dgv)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.board_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button begin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView relative_majority_dgv;
        private System.Windows.Forms.DataGridView clear_winner_dgv;
        private System.Windows.Forms.DataGridView kopland_dgv;
        private System.Windows.Forms.DataGridView simpson_dgv;
        private System.Windows.Forms.DataGridView board_dgv;
        private System.Windows.Forms.ListBox alternatives;
        private System.Windows.Forms.Button to_vote;
        private System.Windows.Forms.TextBox current_expert_name;
        private System.Windows.Forms.Button genarate;
        private System.Windows.Forms.Button discard;
        private System.Windows.Forms.Button clear_winner_ready;
        private System.Windows.Forms.Button kopland_ready;
        private System.Windows.Forms.Button simpson_ready;
        private System.Windows.Forms.Button board_ready;
        private System.Windows.Forms.ListBox winners;
        private System.Windows.Forms.NumericUpDown experts_count;
        private System.Windows.Forms.NumericUpDown alternatives_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn vote_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn vote_percent;
    }
}

