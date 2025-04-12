using SecureNotesManager.BLL;
using SecureNotesManager.Models;

namespace SecureNotesManager.UI
{
    public partial class FormNotes : Form
    {
        private NoteService _noteService;
        public FormNotes()
        {
            InitializeComponent();
            _noteService = new NoteService();
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {

        }



        private void btnAddNote_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtContent.Text))
            {
                MessageBox.Show("Both title and content are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var note = new Note
            {
                Title = txtTitle.Text.Trim(),
                Content = txtContent.Text.Trim()
            };

            _noteService.AddNote(note);

            MessageBox.Show("Note added successfully ✅", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtTitle.Clear();
            txtContent.Clear();

            LoadNotes();
        }

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            if (dataGridViewNotes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a note to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // گرفتن Id یادداشت انتخاب‌شده
            var selectedRow = dataGridViewNotes.SelectedRows[0];
            int noteId = (int)selectedRow.Cells["Id"].Value;

            // تأیید حذف
            var confirm = MessageBox.Show("Are you sure you want to delete this note?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                _noteService.DeleteNote(noteId);
                LoadNotes(); // رفرش لیست یادداشت‌ها
            }
            txtTitle.Clear();
            txtContent.Clear();
        }

        private void btnEditNote_Click(object sender, EventArgs e)
        {
            if (dataGridViewNotes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a note to edit.");
                return;
            }

            var selectedRow = dataGridViewNotes.SelectedRows[0];
            int id = (int)selectedRow.Cells["Id"].Value;

            var note = new Note
            {
                Id = id,
                Title = txtTitle.Text.Trim(),
                Content = txtContent.Text.Trim()
            };

            _noteService.UpdateNote(note);
            txtTitle.Clear();
            txtContent.Clear();

            LoadNotes();

            MessageBox.Show("Note updated successfully!");
        }

        private void LoadNotes()
        {
            var notes = _noteService.GetAllNotes();
            dataGridViewNotes.DataSource = null;
            dataGridViewNotes.DataSource = notes;
            dataGridViewNotes.Columns["Id"].Visible = false;

        }

        private void FormNotes_Load(object sender, EventArgs e)
        {
            LoadNotes();
            StyleDataGridViewLight();

            rdoLight.Checked = true; // حالت پیش‌فرض

            rdoDark.CheckedChanged += (s, e) =>
            {
                if (rdoDark.Checked)
                    StyleDataGridViewDark();
            };

            rdoLight.CheckedChanged += (s, e) =>
            {
                if (rdoLight.Checked)
                    StyleDataGridViewLight();
            };

        }

        private void dataGridViewNotes_CellContentClick(object sender, DataGridViewCellEventArgs e)

        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridViewNotes.Rows[e.RowIndex];
                txtTitle.Text = selectedRow.Cells["Title"].Value.ToString();
                txtContent.Text = selectedRow.Cells["Content"].Value.ToString();
            }
            dataGridViewNotes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewNotes.MultiSelect = false;

        }


        private void dataGridViewNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditNote.PerformClick(); // یعنی با دوبار کلیک، کاربر انگار دکمه Edit رو زده
        }

        private void dataGridViewNotes_SelectionChanged(object sender, EventArgs e)
        {
            btnEditNote.Enabled = dataGridViewNotes.SelectedRows.Count > 0;
            btnDeleteNote.Enabled = dataGridViewNotes.SelectedRows.Count > 0;
        }


        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }


        private void StyleDataGridViewDark()
        {
            var dgv = dataGridViewNotes;

            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30); // سرستون‌ها
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45); // ردیف‌ها
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70); // رنگ انتخاب
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.BackgroundColor = Color.FromArgb(40, 40, 40);
            dgv.GridColor = Color.FromArgb(60, 60, 60);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);

        }

        private void StyleDataGridViewLight()
        {
            var dgv = dataGridViewNotes;

            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;

            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.LightGray;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void rdoLight_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}


