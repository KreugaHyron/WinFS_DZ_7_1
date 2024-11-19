namespace WinFS_DZ_7_1
{
    public partial class Form1 : Form
    {
        private List<Task> tasks;
        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
            InitializeTasks();
        }
        private void InitializeCustomComponents()
        {
            this.Text = "Task Manager";
            var dgvTasks = new DataGridView
            {
                Name = "dgvTasks",
                Dock = DockStyle.Top,
                Height = 250,
                AutoGenerateColumns = false
            };

            dgvTasks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Title", DataPropertyName = "Title" });
            dgvTasks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Due Date", DataPropertyName = "DueDate" });
            dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.Controls.Add(dgvTasks);
            var btnAdd = new Button { Text = "Add Task", Dock = DockStyle.Left };
            btnAdd.Click += BtnAdd_Click;

            var btnEdit = new Button { Text = "Edit Task", Dock = DockStyle.Left };
            btnEdit.Click += BtnEdit_Click;

            var btnDelete = new Button { Text = "Delete Task", Dock = DockStyle.Left };
            btnDelete.Click += BtnDelete_Click;

            var panelButtons = new Panel { Dock = DockStyle.Bottom, Height = 50 };
            panelButtons.Controls.AddRange(new Control[] { btnDelete, btnEdit, btnAdd });

            this.Controls.Add(panelButtons);
        }
        private void InitializeTasks()
        {
            tasks = new List<Task>
            {
                new Task { Title = "Buy groceries", Description = "Milk, bread, eggs", DueDate = DateTime.Now.AddDays(1), AttachedFile = "" },
                new Task { Title = "Complete report", Description = "Finish the annual report", DueDate = DateTime.Now.AddDays(2), AttachedFile = "" },
                new Task { Title = "Doctor appointment", Description = "Checkup at 3 PM", DueDate = DateTime.Now.AddDays(3), AttachedFile = "" }
            };

            UpdateTaskList();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            TaskForm taskForm = new TaskForm();
            if (taskForm.ShowDialog() == DialogResult.OK)
            {
                tasks.Add(taskForm.Task);
                UpdateTaskList();
            }
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (this.Controls["dgvTasks"] is DataGridView dgv && dgv.CurrentRow?.DataBoundItem is Task selectedTask)
            {
                TaskForm taskForm = new TaskForm(selectedTask);
                if (taskForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateTaskList();
                }
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.Controls["dgvTasks"] is DataGridView dgv && dgv.CurrentRow?.DataBoundItem is Task selectedTask)
            {
                tasks.Remove(selectedTask);
                UpdateTaskList();
            }
        }
        private void UpdateTaskList()
        {
            if (this.Controls["dgvTasks"] is DataGridView dgv)
            {
                dgv.DataSource = null;
                dgv.DataSource = tasks;
            }
        }
    }
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string AttachedFile { get; set; }
    }
}
