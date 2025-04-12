namespace SecureNotesManager.UI
{
    partial class FormNotes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAddNote = new Button();
            txtContent = new TextBox();
            txtTitle = new TextBox();
            dataGridViewNotes = new DataGridView();
            clmnID = new DataGridViewTextBoxColumn();
            lblTitle = new Label();
            lblContent = new Label();
            btnDeleteNote = new Button();
            rdoDark = new RadioButton();
            rdoLight = new RadioButton();
            btnEditNote = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotes).BeginInit();
            SuspendLayout();
            // 
            // btnAddNote
            // 
            btnAddNote.Location = new Point(80, 30);
            btnAddNote.Name = "btnAddNote";
            btnAddNote.Size = new Size(200, 46);
            btnAddNote.TabIndex = 0;
            btnAddNote.Text = "Add";
            btnAddNote.UseVisualStyleBackColor = true;
            btnAddNote.Click += btnAddNote_Click;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(285, 201);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(200, 39);
            txtContent.TabIndex = 1;
            txtContent.TextChanged += txtContent_TextChanged;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(285, 124);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(200, 39);
            txtTitle.TabIndex = 2;
            txtTitle.TextChanged += txtTitle_TextChanged;
            // 
            // dataGridViewNotes
            // 
            dataGridViewNotes.AllowDrop = true;
            dataGridViewNotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewNotes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNotes.Columns.AddRange(new DataGridViewColumn[] { clmnID });
            dataGridViewNotes.Location = new Point(80, 334);
            dataGridViewNotes.Name = "dataGridViewNotes";
            dataGridViewNotes.ReadOnly = true;
            dataGridViewNotes.RowHeadersWidth = 82;
            dataGridViewNotes.Size = new Size(1102, 300);
            dataGridViewNotes.TabIndex = 3;
            dataGridViewNotes.TabStop = false;
            dataGridViewNotes.CellContentClick += dataGridViewNotes_CellContentClick;
            // 
            // clmnID
            // 
            clmnID.HeaderText = "ID";
            clmnID.MinimumWidth = 10;
            clmnID.Name = "clmnID";
            clmnID.ReadOnly = true;
            clmnID.Visible = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(80, 131);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(65, 32);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "TItle:";
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Location = new Point(80, 204);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(105, 32);
            lblContent.TabIndex = 5;
            lblContent.Text = "Content:";
            // 
            // btnDeleteNote
            // 
            btnDeleteNote.Location = new Point(311, 30);
            btnDeleteNote.Name = "btnDeleteNote";
            btnDeleteNote.Size = new Size(200, 46);
            btnDeleteNote.TabIndex = 6;
            btnDeleteNote.Text = "Delete";
            btnDeleteNote.UseVisualStyleBackColor = true;
            btnDeleteNote.Click += btnDeleteNote_Click;
            // 
            // rdoDark
            // 
            rdoDark.AutoSize = true;
            rdoDark.Location = new Point(1057, 40);
            rdoDark.Name = "rdoDark";
            rdoDark.Size = new Size(164, 36);
            rdoDark.TabIndex = 7;
            rdoDark.TabStop = true;
            rdoDark.Text = "Dark Mode";
            rdoDark.UseVisualStyleBackColor = true;
            // 
            // rdoLight
            // 
            rdoLight.AutoSize = true;
            rdoLight.Location = new Point(1057, 98);
            rdoLight.Name = "rdoLight";
            rdoLight.Size = new Size(168, 36);
            rdoLight.TabIndex = 8;
            rdoLight.TabStop = true;
            rdoLight.Text = "Light Mode";
            rdoLight.UseVisualStyleBackColor = true;
            rdoLight.CheckedChanged += rdoLight_CheckedChanged;
            // 
            // btnEditNote
            // 
            btnEditNote.Location = new Point(545, 30);
            btnEditNote.Name = "btnEditNote";
            btnEditNote.Size = new Size(200, 46);
            btnEditNote.TabIndex = 9;
            btnEditNote.Text = "Edit";
            btnEditNote.UseVisualStyleBackColor = true;
            btnEditNote.Click += btnEditNote_Click;
            // 
            // FormNotes
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1287, 708);
            Controls.Add(btnEditNote);
            Controls.Add(rdoLight);
            Controls.Add(rdoDark);
            Controls.Add(btnDeleteNote);
            Controls.Add(lblContent);
            Controls.Add(lblTitle);
            Controls.Add(dataGridViewNotes);
            Controls.Add(txtTitle);
            Controls.Add(txtContent);
            Controls.Add(btnAddNote);
            Name = "FormNotes";
            Text = "FormNotes";
            Load += FormNotes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddNote;
        private TextBox txtContent;
        private TextBox txtTitle;
        private DataGridView dataGridViewNotes;
        private Label lblTitle;
        private Label lblContent;
        private Button btnDeleteNote;
        private DataGridViewTextBoxColumn clmnID;
        private RadioButton rdoDark;
        private RadioButton rdoLight;
        private Button btnEditNote;
    }
}