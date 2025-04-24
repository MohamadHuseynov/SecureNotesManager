using SecureNotesManager.BLL;
using SecureNotesManager.Models;

namespace SecureNotesManager.UI
{
    public partial class FormNotes : Form
    {
        #region [-Fields & Constructor-]

        private readonly NoteService _noteService;
        private int selectedRowIndex = -1;

        public FormNotes()
        {
            InitializeComponent();
            _noteService = new NoteService();
            btnEditNote.Enabled = false;
            btnDeleteNote.Enabled = false;
        }

        #endregion

        #region [-Form Load-]

        private void FormNotes_Load(object sender, EventArgs e)
        {
            LoadNotes();
            ApplyLightTheme();
            rdoLight.Checked = true;

            rdoDark.CheckedChanged += (s, e) =>
            {
                if (rdoDark.Checked) ApplyDarkTheme();
            };

            rdoLight.CheckedChanged += (s, e) =>
            {
                if (rdoLight.Checked) ApplyLightTheme();
            };
        }

        #endregion

        #region [-Button Events-]

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var note = new Note
            {
                Title = txtTitle.Text.Trim(),
                Content = txtContent.Text.Trim()
            };

            _noteService.AddNote(note);
            MessageBox.Show("Note added successfully ✅", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearForm();
            LoadNotes();
        }

        private void btnEditNote_Click(object sender, EventArgs e)
        {
            var selectedRow = GetCheckedRow();
            if (selectedRow == null)
            {
                MessageBox.Show("Please select a note to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

            var note = new Note
            {
                Id = id,
                Title = txtTitle.Text.Trim(),
                Content = txtContent.Text.Trim()
            };

            _noteService.UpdateNote(note);

            ClearForm();
            LoadNotes();
            MessageBox.Show("Note updated successfully!");
        }

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            List<int> selectedNoteIds = new List<int>();

            foreach (DataGridViewRow row in dataGridViewNotes.Rows)
            {
                var checkBox = row.Cells[0] as DataGridViewCheckBoxCell;
                if (checkBox != null && checkBox.Value != null && (bool)checkBox.Value)
                {
                    int noteId = (int)row.Cells["Id"].Value;
                    selectedNoteIds.Add(noteId);
                }
            }

            if (selectedNoteIds.Count == 0)
            {
                MessageBox.Show("Please select at least one note to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete the selected notes?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                foreach (int id in selectedNoteIds)
                {
                    _noteService.DeleteNote(id);
                }

                LoadNotes();
                MessageBox.Show("Selected notes deleted successfully.");
            }

            txtTitle.Clear();
            txtContent.Clear();
        }


        #endregion

        #region [-DataGridView Events-]

        private void dataGridViewNotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                var cell = (DataGridViewCheckBoxCell)dataGridViewNotes.Rows[e.RowIndex].Cells[0];
                cell.Value = !(cell.Value != null && (bool)cell.Value);
                dataGridViewNotes.EndEdit();

                UpdateButtonStates();
                UpdateTextBoxes();
            }
        }

        #endregion

        #region [-Helpers-]

        private void LoadNotes()
        {
            var notes = _noteService.GetAllNotes();

            dataGridViewNotes.DataSource = null;
            dataGridViewNotes.Columns.Clear();
            dataGridViewNotes.DataSource = notes;

            if (dataGridViewNotes.Columns.Contains("Id"))
                dataGridViewNotes.Columns["Id"].Visible = false;

            // اضافه کردن ستون چک‌باکس
            if (!dataGridViewNotes.Columns.Contains("Select"))
            {
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                checkBoxColumn.Name = "Select";
                checkBoxColumn.HeaderText = "";
                checkBoxColumn.Width = 50; // 👈 عرض ستون به پیکسل
                checkBoxColumn.MinimumWidth = 50;
                checkBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridViewNotes.Columns.Insert(0, checkBoxColumn);

            }




            dataGridViewNotes.ClearSelection();
        }

        private void UpdateButtonStates()
        {
            int checkedCount = dataGridViewNotes.Rows.Cast<DataGridViewRow>()
                .Count(row => Convert.ToBoolean(row.Cells[0].Value));

            btnEditNote.Enabled = checkedCount == 1;
            btnDeleteNote.Enabled = checkedCount >= 1;
        }

        private void UpdateTextBoxes()
        {
            var row = GetCheckedRow();
            if (row != null)
            {
                txtTitle.Text = row.Cells["Title"].Value?.ToString() ?? "";
                txtContent.Text = row.Cells["Content"].Value?.ToString() ?? "";
            }
            else
            {
                ClearForm();
            }
        }

        private void ClearForm()
        {
            txtTitle.Clear();
            txtContent.Clear();
            selectedRowIndex = -1;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtContent.Text))
            {
                MessageBox.Show("Both title and content are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private DataGridViewRow? GetCheckedRow()
        {
            return dataGridViewNotes.Rows.Cast<DataGridViewRow>()
                .FirstOrDefault(row => Convert.ToBoolean(row.Cells[0].Value));
        }

        #endregion

        #region [-Theming-]

        private void ApplyDarkTheme()
        {
            var dgv = dataGridViewNotes;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.BackgroundColor = Color.FromArgb(40, 40, 40);
            dgv.GridColor = Color.FromArgb(60, 60, 60);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void ApplyLightTheme()
        {
            var dgv = dataGridViewNotes;
            dgv.BorderStyle = BorderStyle.None;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;

            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.LightGray;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        #endregion
    }
}
