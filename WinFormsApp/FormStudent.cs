using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class FormStudent : Form
    {
        public Student student;

        public FormStudent(Student student)
        {
            InitializeComponent();
            this.student = student;
            DataContext = student;

            nameBox.DataBindings.Add(new Binding("Text", student, "Name"));
            ageBox.DataBindings.Add(new Binding("Text", student, "Age"));
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
