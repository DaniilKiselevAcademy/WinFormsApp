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
        // Поле для студента, данные которого изменяются
        public Student student;

        public FormStudent(Student student)
        {
            InitializeComponent();
            this.student = student;
            // Записываю студента в контекст окна
            // Это означает, что все дочерние элементы окна будут знать о студенте и смогут им пользоваться
            DataContext = student;

            // Выполняю привязку полей студента к соотвествующим текстовым полям на окне
            nameBox.DataBindings.Add(new Binding("Text", student, "Name"));
            ageBox.DataBindings.Add(new Binding("Text", student, "Age"));
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            // Завершаю работу диалогового окна константой ОК
            // Это строчка сама закроет окно
            DialogResult = DialogResult.OK;
        }
    }
}
