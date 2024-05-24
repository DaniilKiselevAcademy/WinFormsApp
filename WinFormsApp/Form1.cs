using Microsoft.EntityFrameworkCore;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        Context context = new Context();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            context.Database.EnsureCreated();
            context.Students.Load();
            dataGridView.DataSource = context.Students.Local.ToBindingList();
        }
    }
}
