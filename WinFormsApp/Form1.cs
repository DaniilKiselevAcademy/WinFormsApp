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
            // ������ ���� ������
            context.Database.EnsureCreated();
            // �������� ������� ���������
            context.Students.Load();
            // �������� ������� � ����������� �������� � ����
            dataGridView.DataSource = context.Students.Local.ToBindingList();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // ������ ����� ��� �������������� ������ ��������
            // �������� ��������, ��� ������ ���� � ����� ������, ������ ��� ���������, ������ ��������
            FormStudent form = new(new Student());
            // ��� ���������� ����
            DialogResult dialog = form.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                // ���� �� ����� �������� � �������� ��� � ���� ������
                context.Students.Add(form.student);
                context.SaveChanges();
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            // ���� ����������� �������� �� dataGridView
            Student? student = getSelectTable();
            // ���� ������ �� ��������, �� ���������� ������ ������
            if (student == null) return;
            // ������ ����� ���� � ��� ��� ����������� �������� ��� ��������������
            FormStudent form = new(student);
            // ��� ��������� ���������� ����
            DialogResult dialog = form.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                // �������� ��������
                context.Students.Update(form.student);
                context.SaveChanges();
                // �������� dataGridView, ��������� �� ��� �� ������, �� ���� �� ��� ������� ����������
                dataGridView.Refresh();
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            // ��� �� �� �����, ��� � � �������������� - ������� ����������� ��������
            Student? student = getSelectTable();
            if (student == null) return;

            // ������ ��������� ���������� ����, ��� ������ �� ������������ ������������� �� ��������
            DialogResult result = MessageBox.Show(
                $"������� {student}?",
                "��������",
                MessageBoxButtons.OKCancel
            );

            // ������ ��������, ���� ��
            if (result == DialogResult.OK)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }

        // ��������� ����� � ���������� ����������� ��������
        private Student? getSelectTable()
        {
            // ���� ��� ���������� �����, ��� �������� null
            if (dataGridView.SelectedRows.Count == 0) return null;
            // ������� �� ������ ���������� ������� ������, ������� ������� � ������ ��������
            Student student = (Student)dataGridView.SelectedRows[0].DataBoundItem;
            return student;
        }
    }
}
