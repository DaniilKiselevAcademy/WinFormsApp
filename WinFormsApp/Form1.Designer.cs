namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView = new DataGridView();
            addBtn = new Button();
            editBtn = new Button();
            delBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(490, 426);
            dataGridView.TabIndex = 0;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(608, 33);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(96, 23);
            addBtn.TabIndex = 1;
            addBtn.Text = "Добавить";
            addBtn.UseVisualStyleBackColor = true;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(608, 85);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(96, 23);
            editBtn.TabIndex = 2;
            editBtn.Text = "Редактировать";
            editBtn.UseVisualStyleBackColor = true;
            // 
            // delBtn
            // 
            delBtn.Location = new Point(608, 139);
            delBtn.Name = "delBtn";
            delBtn.Size = new Size(96, 23);
            delBtn.TabIndex = 3;
            delBtn.Text = "Удалить";
            delBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(delBtn);
            Controls.Add(editBtn);
            Controls.Add(addBtn);
            Controls.Add(dataGridView);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private Button addBtn;
        private Button editBtn;
        private Button delBtn;
    }
}
