using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DataBaseManager
{
    public partial class Form1 : Form
    {
        FolderBrowserDialog folderBrowserDialog = null;
        DialogResult dialogResult;
        TextReader reader;
        TabPage tabPage;
        DataGridView dgv;
        List<DataGridView> tables;

        public Form1()
        {
            InitializeComponent();
            tables = new List<DataGridView>();
        }

        // выбор баззы данных
        public void SelectTheDatabase()
        {
            this.folderBrowserDialog = new FolderBrowserDialog();
            this.dialogResult = this.folderBrowserDialog.ShowDialog();
            this.DBName.Text = this.folderBrowserDialog.SelectedPath;
        }

        //создание пустой базы данных
        private void createDataBase_Click(object sender, EventArgs e)
        {
            SelectTheDatabase();
            MessageBox.Show("Created");
        }

        // считывание таблиц
        public void ReadTables()
        {
            if ((reader = new StreamReader(this.folderBrowserDialog.SelectedPath + @"\main.txt")) != null)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    dgv = new DataGridView();
                    dgv.Name = line;
                    tables.Add(dgv);
                    line = reader.ReadLine();
                }
                reader.Close();
            }
        }

        public void AddColumns(DataGridView table)
        {
            if ((reader = new StreamReader(this.folderBrowserDialog.SelectedPath + @"\" + table.Name + @"\main.txt")) != null  )
            { 
                string column = reader.ReadLine();
                while (column != null)
                {
                    table.Columns.Add(column, column);
                    column = reader.ReadLine();
                }
                reader.Close();
            }
        }

        public void AddData(DataGridView table)
        {
            this.reader = new StreamReader(this.folderBrowserDialog.SelectedPath + @"\" + table.Name + @"\data.txt");
            string data = reader.ReadLine();
            while (data != null)
            {
                table.Rows.Add(data.Split(' '));
                data = reader.ReadLine();
            }
            reader.Close();
        }

        // считывание схем таблиц
        public void ReadTablesSchema()
        {
            foreach (DataGridView table in tables)
            {
                AddColumns(table);

                AddData(table);
            }
        }

        public DataGridView CreateDataGridView()
        {
            dgv = new DataGridView();
            //dgv.Width = 2500;
            //dgv.Height = 600;
            return dgv;
        }

        public void DisplayData()
        {
            foreach (DataGridView table in tables)
            {
                tabPage = new TabPage(table.Name);
                tabControl1.TabPages.Add(tabPage);

                tabPage.Controls.Add(table);
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            tables = new List<DataGridView>();

            tabControl1.TabPages.Clear();

            SelectTheDatabase();

            ReadTables();

            ReadTablesSchema();

            DisplayData();
        }

        //поиск активной вкладки
        public int CurrentTabPageIndex()
        {
            tabPage = tabControl1.SelectedTab;
            bool find = false;
            int i = 0;
            while (!find && i < tabControl1.TabCount)
            {
                if (tabControl1.TabPages[i] == tabPage)
                {
                    find = true;
                }
                else
                {
                    i++;
                }
            }
            return i;
        }

        private void deleteRow_Click(object sender, EventArgs e)
        {
            int i = CurrentTabPageIndex();
            int j = tables[i].SelectedCells[0].RowIndex;
            tables[i].Rows.RemoveAt(j);
        }

        private void deleteColumn_Click(object sender, EventArgs e)
        {
            int i = CurrentTabPageIndex();
            int j = tables[i].SelectedCells[0].ColumnIndex;
            tables[i].Columns.RemoveAt(j);
        }

        private void deleteTable_Click(object sender, EventArgs e)
        {
            int i = CurrentTabPageIndex();
            tabControl1.TabPages.RemoveAt(i);
            tables.RemoveAt(i);
        }

        private void addColumn_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                int i = CurrentTabPageIndex();
                tables[i].Columns.Add(textBox2.Text, textBox2.Text);
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Enter the name!");
            }
        }

        private void addTable_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                tabPage = new TabPage(textBox2.Text);
                tabControl1.TabPages.Add(tabPage);
                dgv = CreateDataGridView();
                dgv.Name = textBox2.Text;
                tabPage.Controls.Add(dgv);
                tables.Add(dgv);
                textBox2.Clear();
                tabControl1.SelectedIndex = tables.Count - 1; //сделать таб активным
            }
            else
            {
                MessageBox.Show("Enter the name!");
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            StreamWriter sw;
            StreamWriter tableMain;
            StreamWriter swMain = new StreamWriter(folderBrowserDialog.SelectedPath + @"\main.txt");
            int index = CurrentTabPageIndex();
            
            for (int i = 0; i < tables.Count; i++)
            {                
                swMain.WriteLine(tables[i].Name);
            }
            swMain.Close();
            {
                Directory.CreateDirectory(this.folderBrowserDialog.SelectedPath + @"\" + tables[index].Name);

                sw = new StreamWriter(this.folderBrowserDialog.SelectedPath + @"\" + tables[index].Name + @"\data.txt");
                tableMain = new StreamWriter(this.folderBrowserDialog.SelectedPath + @"\" + tables[index].Name + @"\main.txt");

                int countCol = tables[index].Columns.Count;
                int countR = tables[index].Rows.Count;

                for (int k = 0; k < countCol; k++)
                {
                    tableMain.WriteLine(tables[index].Columns[k].Name);
                }
                tableMain.Close();

                for (int k = 0; k < countR - 1; k++)
                {
                    string line = "";
                    for (int j = 0; j < countCol - 1; j++)
                    {
                        line += tables[index].Rows[k].Cells[j].Value.ToString() + " ";

                    }
                    line += tables[index].Rows[k].Cells[countCol - 1].Value.ToString();
                    sw.WriteLine(line);
                }
                sw.Close();
            }
            swMain.Close();
            MessageBox.Show("Saved!");
        }
    }
}


