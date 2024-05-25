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
            // Создаю базу данных
            context.Database.EnsureCreated();
            // Загружаю таблицу студентов
            context.Students.Load();
            // Связываю таблицу с графической таблицей в окне
            dataGridView.DataSource = context.Students.Local.ToBindingList();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // Создаю форму для редактирования нового студента
            // Обратите внимание, что новому окну я выдаю пустой, только что созданный, объект студента
            FormStudent form = new(new Student());
            // Жду результата окна
            DialogResult dialog = form.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                // Беру из формы студента и добавляю его в базу данных
                context.Students.Add(form.student);
                context.SaveChanges();
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            // Беру выделенного студента из dataGridView
            Student? student = getSelectTable();
            // Если ничего не выделено, то заканчиваю работу метода
            if (student == null) return;
            // Создаю новое окно и даю ему выделенного студента для редактирования
            FormStudent form = new(student);
            // Жду результат выполнения окна
            DialogResult dialog = form.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                // Обновляю студента
                context.Students.Update(form.student);
                context.SaveChanges();
                // Обновляю dataGridView, поскольку он сам не поймет, то одна из его строчек изменилась
                dataGridView.Refresh();
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            // Все то же самое, что и в редактировании - получаю выделенного студента
            Student? student = getSelectTable();
            if (student == null) return;

            // Создаю небольшое диалоговое окно, где требую от пользователя подтверждение на удаление
            DialogResult result = MessageBox.Show(
                $"Удалить {student}?",
                "Удаление",
                MessageBoxButtons.OKCancel
            );

            // Удаляю студента, если ОК
            if (result == DialogResult.OK)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }

        // Небольшой метод с получением выделенного студента
        private Student? getSelectTable()
        {
            // Если нет выделенных строк, что возращаю null
            if (dataGridView.SelectedRows.Count == 0) return null;
            // Получаю из первой выделенной строчки объект, который привожу к классу студента
            Student student = (Student)dataGridView.SelectedRows[0].DataBoundItem;
            return student;
        }
    }
}
