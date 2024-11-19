using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFS_DZ_7_1
{
    public partial class TaskForm : Form
    {
        public Task Task { get; private set; }
        public TaskForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            Task = new Task();
        }
        public TaskForm(Task task) : this()
        {
            Task = task;
            txtTitle.Text = task.Title;
            txtDescription.Text = task.Description;
            dtpDueDate.Value = task.DueDate;
            txtFile.Text = task.AttachedFile;
        }

        private TextBox txtTitle;
        private TextBox txtDescription;
        private DateTimePicker dtpDueDate;
        private TextBox txtFile;

        private void InitializeCustomComponents()
        {
            this.Text = "Task Form";
            this.Size = new System.Drawing.Size(400, 300);

            var lblTitle = new Label { Text = "Title:", Left = 10, Top = 20 };
            txtTitle = new TextBox { Left = 100, Top = 20, Width = 250 };
            this.Controls.Add(lblTitle);
            this.Controls.Add(txtTitle);

            var lblDescription = new Label { Text = "Description:", Left = 10, Top = 60 };
            txtDescription = new TextBox { Left = 100, Top = 60, Width = 250, Height = 80, Multiline = true };
            this.Controls.Add(lblDescription);
            this.Controls.Add(txtDescription);

            var lblDueDate = new Label { Text = "Due Date:", Left = 10, Top = 160 };
            dtpDueDate = new DateTimePicker { Left = 100, Top = 160, Width = 250 };
            this.Controls.Add(lblDueDate);
            this.Controls.Add(dtpDueDate);

            var lblFile = new Label { Text = "File:", Left = 10, Top = 200 };
            txtFile = new TextBox { Left = 100, Top = 200, Width = 180 };
            var btnAttachFile = new Button { Text = "Browse", Left = 290, Top = 200 };
            btnAttachFile.Click += BtnAttachFile_Click;
            this.Controls.Add(lblFile);
            this.Controls.Add(txtFile);
            this.Controls.Add(btnAttachFile);

            var btnSave = new Button { Text = "Save", Left = 100, Top = 240 };
            btnSave.Click += BtnSave_Click;
            var btnCancel = new Button { Text = "Cancel", Left = 200, Top = 240 };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }

        private void BtnAttachFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFile.Text = openFileDialog.FileName;
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Task.Title = txtTitle.Text;
            Task.Description = txtDescription.Text;
            Task.DueDate = dtpDueDate.Value;
            Task.AttachedFile = txtFile.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
