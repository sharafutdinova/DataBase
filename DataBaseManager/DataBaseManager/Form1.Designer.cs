namespace DataBaseManager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.Label();
            this.createDataBase = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.addTable = new System.Windows.Forms.Button();
            this.deleteTable = new System.Windows.Forms.Button();
            this.deleteColumn = new System.Windows.Forms.Button();
            this.addColumn = new System.Windows.Forms.Button();
            this.saveAllChanges = new System.Windows.Forms.Button();
            this.deleteRow = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.DBName = new System.Windows.Forms.TextBox();
            this.openButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.selectBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fromBox = new System.Windows.Forms.TextBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(181, 358);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(30, 13);
            this.title.TabIndex = 37;
            this.title.Text = "Title:";
            // 
            // createDataBase
            // 
            this.createDataBase.Location = new System.Drawing.Point(609, 9);
            this.createDataBase.Name = "createDataBase";
            this.createDataBase.Size = new System.Drawing.Size(123, 23);
            this.createDataBase.TabIndex = 36;
            this.createDataBase.Text = "Create DataBase";
            this.createDataBase.UseVisualStyleBackColor = true;
            this.createDataBase.Click += new System.EventHandler(this.createDataBase_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(217, 355);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(195, 20);
            this.textBox2.TabIndex = 35;
            // 
            // addTable
            // 
            this.addTable.Location = new System.Drawing.Point(321, 389);
            this.addTable.Name = "addTable";
            this.addTable.Size = new System.Drawing.Size(142, 23);
            this.addTable.TabIndex = 34;
            this.addTable.Text = "Add Table";
            this.addTable.UseVisualStyleBackColor = true;
            this.addTable.Click += new System.EventHandler(this.addTable_Click);
            // 
            // deleteTable
            // 
            this.deleteTable.Location = new System.Drawing.Point(321, 431);
            this.deleteTable.Name = "deleteTable";
            this.deleteTable.Size = new System.Drawing.Size(142, 23);
            this.deleteTable.TabIndex = 33;
            this.deleteTable.Text = "Delete Table";
            this.deleteTable.UseVisualStyleBackColor = true;
            this.deleteTable.Click += new System.EventHandler(this.deleteTable_Click);
            // 
            // deleteColumn
            // 
            this.deleteColumn.Location = new System.Drawing.Point(157, 431);
            this.deleteColumn.Name = "deleteColumn";
            this.deleteColumn.Size = new System.Drawing.Size(142, 23);
            this.deleteColumn.TabIndex = 32;
            this.deleteColumn.Text = "Delete Column";
            this.deleteColumn.UseVisualStyleBackColor = true;
            this.deleteColumn.Click += new System.EventHandler(this.deleteColumn_Click);
            // 
            // addColumn
            // 
            this.addColumn.Location = new System.Drawing.Point(157, 389);
            this.addColumn.Name = "addColumn";
            this.addColumn.Size = new System.Drawing.Size(142, 23);
            this.addColumn.TabIndex = 31;
            this.addColumn.Text = "Add Column";
            this.addColumn.UseVisualStyleBackColor = true;
            this.addColumn.Click += new System.EventHandler(this.addColumn_Click);
            // 
            // saveAllChanges
            // 
            this.saveAllChanges.Location = new System.Drawing.Point(511, 460);
            this.saveAllChanges.Name = "saveAllChanges";
            this.saveAllChanges.Size = new System.Drawing.Size(142, 23);
            this.saveAllChanges.TabIndex = 30;
            this.saveAllChanges.Text = "Save all changes";
            this.saveAllChanges.UseVisualStyleBackColor = true;
            this.saveAllChanges.Click += new System.EventHandler(this.saveAllChanges_Click);
            // 
            // deleteRow
            // 
            this.deleteRow.Location = new System.Drawing.Point(18, 389);
            this.deleteRow.Name = "deleteRow";
            this.deleteRow.Size = new System.Drawing.Size(108, 23);
            this.deleteRow.TabIndex = 29;
            this.deleteRow.Text = "Delete Row";
            this.deleteRow.UseVisualStyleBackColor = true;
            this.deleteRow.Click += new System.EventHandler(this.deleteRow_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(18, 53);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(713, 290);
            this.tabControl1.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Data base name:";
            // 
            // DBName
            // 
            this.DBName.Location = new System.Drawing.Point(109, 9);
            this.DBName.Name = "DBName";
            this.DBName.Size = new System.Drawing.Size(354, 20);
            this.DBName.TabIndex = 26;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(479, 9);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(123, 23);
            this.openButton.TabIndex = 25;
            this.openButton.Text = "Open DataBase";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(508, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "SELECT";
            // 
            // selectBox
            // 
            this.selectBox.Location = new System.Drawing.Point(560, 386);
            this.selectBox.Name = "selectBox";
            this.selectBox.Size = new System.Drawing.Size(137, 20);
            this.selectBox.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(518, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "FROM";
            // 
            // fromBox
            // 
            this.fromBox.Location = new System.Drawing.Point(560, 355);
            this.fromBox.Name = "fromBox";
            this.fromBox.Size = new System.Drawing.Size(137, 20);
            this.fromBox.TabIndex = 46;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(560, 421);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(137, 23);
            this.selectButton.TabIndex = 47;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 493);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.fromBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.title);
            this.Controls.Add(this.createDataBase);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.addTable);
            this.Controls.Add(this.deleteTable);
            this.Controls.Add(this.deleteColumn);
            this.Controls.Add(this.addColumn);
            this.Controls.Add(this.saveAllChanges);
            this.Controls.Add(this.deleteRow);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DBName);
            this.Controls.Add(this.openButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button createDataBase;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button addTable;
        private System.Windows.Forms.Button deleteTable;
        private System.Windows.Forms.Button deleteColumn;
        private System.Windows.Forms.Button addColumn;
        private System.Windows.Forms.Button saveAllChanges;
        private System.Windows.Forms.Button deleteRow;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DBName;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox selectBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fromBox;
        private System.Windows.Forms.Button selectButton;
    }
}

