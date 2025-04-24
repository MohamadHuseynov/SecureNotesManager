namespace SecureNotesManager.UI
{
    partial class FormNotes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnAddNote = new Button();
            txtContent = new TextBox();
            txtTitle = new TextBox();
            dataGridViewNotes = new DataGridView();
            lblTitle = new Label();
            lblContent = new Label();
            btnDeleteNote = new Button();
            rdoDark = new RadioButton();
            rdoLight = new RadioButton();
            btnEditNote = new Button();
            clmnID = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotes).BeginInit();
            SuspendLayout();
            // 
            // btnAddNote
            // 
            btnAddNote.Location = new Point(12, 30);
            btnAddNote.Name = "btnAddNote";
            btnAddNote.Size = new Size(200, 46);
            btnAddNote.TabIndex = 3;
            btnAddNote.Text = "Add";
            btnAddNote.UseVisualStyleBackColor = true;
            btnAddNote.Click += btnAddNote_Click;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(161, 201);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(200, 39);
            txtContent.TabIndex = 2;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(161, 127);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(200, 39);
            txtTitle.TabIndex = 1;
            // 
            // dataGridViewNotes
            // 
            dataGridViewNotes.AllowDrop = true;
            dataGridViewNotes.AllowUserToAddRows = false;
            dataGridViewNotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNotes.Columns.AddRange(new DataGridViewColumn[] { clmnID });
            dataGridViewNotes.Location = new Point(12, 300);
            dataGridViewNotes.Name = "dataGridViewNotes";
            dataGridViewNotes.RowHeadersVisible = false;
            dataGridViewNotes.RowHeadersWidth = 82;
            dataGridViewNotes.Size = new Size(948, 300);
            dataGridViewNotes.TabIndex = 4;
            dataGridViewNotes.TabStop = false;
            dataGridViewNotes.CellContentClick += dataGridViewNotes_CellContentClick;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 127);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(65, 32);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Title:";
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Location = new Point(12, 201);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(105, 32);
            lblContent.TabIndex = 6;
            lblContent.Text = "Content:";
            // 
            // btnDeleteNote
            // 
            btnDeleteNote.Location = new Point(469, 30);
            btnDeleteNote.Name = "btnDeleteNote";
            btnDeleteNote.Size = new Size(200, 46);
            btnDeleteNote.TabIndex = 5;
            btnDeleteNote.Text = "Delete";
            btnDeleteNote.UseVisualStyleBackColor = true;
            btnDeleteNote.Click += btnDeleteNote_Click;
            // 
            // rdoDark
            // 
            rdoDark.AutoSize = true;
            rdoDark.Location = new Point(792, 197);
            rdoDark.Name = "rdoDark";
            rdoDark.Size = new Size(164, 36);
            rdoDark.TabIndex = 6;
            rdoDark.Text = "Dark Mode";
            rdoDark.UseVisualStyleBackColor = true;
            // 
            // rdoLight
            // 
            rdoLight.AutoSize = true;
            rdoLight.Location = new Point(792, 125);
            rdoLight.Name = "rdoLight";
            rdoLight.Size = new Size(168, 36);
            rdoLight.TabIndex = 5;
            rdoLight.Text = "Light Mode";
            rdoLight.UseVisualStyleBackColor = true;
            // 
            // btnEditNote
            // 
            btnEditNote.Location = new Point(239, 30);
            btnEditNote.Name = "btnEditNote";
            btnEditNote.Size = new Size(200, 46);
            btnEditNote.TabIndex = 4;
            btnEditNote.Text = "Edit";
            btnEditNote.UseVisualStyleBackColor = true;
            btnEditNote.Click += btnEditNote_Click;
            // 
            // clmnID
            // 
            clmnID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmnID.DividerWidth = 10;
            clmnID.FillWeight = 10F;
            clmnID.Frozen = true;
            clmnID.HeaderText = "ID";
            clmnID.MinimumWidth = 50;
            clmnID.Name = "clmnID";
            clmnID.Visible = false;
            // 
            // FormNotes
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1003, 643);
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
        private RadioButton rdoDark;
        private RadioButton rdoLight;
        private Button btnEditNote;
        private DataGridViewTextBoxColumn clmnID;
    }
}
