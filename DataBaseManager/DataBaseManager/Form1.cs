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
        DataSet dataBase;
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
            dataBase = new DataSet();
            SelectTheDatabase();
            MessageBox.Show("Created");
        }

        // считывание таблиц
        public void ReadTables()
        {
            this.reader = new StreamReader(this.folderBrowserDialog.SelectedPath + @"\main.txt");

            string line = reader.ReadLine();
            while (line != null)
            {
                this.dataBase.Tables.Add(line);
                line = reader.ReadLine();
            }
            reader.Close();
        }

        public void AddColumns(DataTable table)
        {
            this.reader = new StreamReader(this.folderBrowserDialog.SelectedPath + @"\" + table.TableName + @"\main.txt");
            string column = reader.ReadLine();
            while (column != null)
            {
                table.Columns.Add(column);
                column = reader.ReadLine();
            }
            reader.Close();
        }

        public void AddData(DataTable table)
        {
            this.reader = new StreamReader(this.folderBrowserDialog.SelectedPath + @"\" + table.TableName + @"\data.txt");
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
            foreach (DataTable table in this.dataBase.Tables)
            {
                AddColumns(table);

                AddData(table);
            }
        }

        public DataGridView CreateDataGridView()
        {
            dgv = new DataGridView();
            dgv.Width = 700;
            dgv.Height = 300;
            return dgv;
        }

        public void DisplayData()
        {
            foreach (DataTable table in this.dataBase.Tables)
            {
                tabPage = new TabPage(table.TableName);
                tabControl1.TabPages.Add(tabPage);
                dgv = CreateDataGridView();
                dgv.DataSource = table;

                tabPage.Controls.Add(dgv);
                tables.Add(dgv);
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            this.dataBase = new DataSet();

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
            dataBase.Tables[i].Rows.RemoveAt(j);
        }

        private void deleteColumn_Click(object sender, EventArgs e)
        {
            int i = CurrentTabPageIndex();
            int j = tables[i].SelectedCells[0].ColumnIndex;
            dataBase.Tables[i].Columns.RemoveAt(j);
        }

        private void deleteTable_Click(object sender, EventArgs e)
        {
            int i = CurrentTabPageIndex();
            dataBase.Tables.RemoveAt(i);
            tabControl1.TabPages.RemoveAt(i);
            tables.RemoveAt(i);
        }

        private void addColumn_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                int i = CurrentTabPageIndex();
                dataBase.Tables[i].Columns.Add(textBox2.Text);
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
                dataBase.Tables.Add(textBox2.Text);
                tabPage = new TabPage(textBox2.Text);
                tabControl1.TabPages.Add(tabPage);
                dgv = CreateDataGridView();
                dgv.DataSource = dataBase.Tables[dataBase.Tables.Count - 1];
                tabPage.Controls.Add(dgv);
                tables.Add(dgv);
                textBox2.Clear();
                tabControl1.SelectedIndex = dataBase.Tables.Count - 1; //сделать таб активным
            }
            else
            {
                MessageBox.Show("Enter the name!");
            }
        }

        private void saveAllChanges_Click(object sender, EventArgs e)
        {
            StreamWriter sw;
            StreamWriter tableMain;
            StreamWriter swMain = new StreamWriter(folderBrowserDialog.SelectedPath + @"\main.txt");

            foreach (DataTable table in dataBase.Tables)
            {
                swMain.WriteLine(table.TableName);
                Directory.CreateDirectory(this.folderBrowserDialog.SelectedPath + @"\" + table.TableName);

                sw = new StreamWriter(this.folderBrowserDialog.SelectedPath + @"\" + table.TableName + @"\data.txt");
                tableMain = new StreamWriter(this.folderBrowserDialog.SelectedPath + @"\" + table.TableName + @"\main.txt");

                int countCol = table.Columns.Count;
                int countR = table.Rows.Count;

                for (int i = 0; i < countCol; i++)
                {
                    tableMain.WriteLine(table.Columns[i].ColumnName);
                }
                tableMain.Close();

                for (int i = 0; i < countR; i++)
                {
                    string line = "";
                    for (int j = 0; j < countCol - 1; j++)
                    {
                        line += table.Rows[i][j].ToString() + " ";
                    }
                    line += table.Rows[i][countCol - 1].ToString();
                    sw.WriteLine(line);
                }
                sw.Close();
            }
            swMain.Close();
            MessageBox.Show("Saved!");
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            int ind = CurrentTabPageIndex();
            dataBase.Tables.Add("From" + dataBase.Tables[ind].TableName + "Select" + fromBox.Text);
            tabPage = new TabPage("From" + dataBase.Tables[ind].TableName + "Select" + fromBox.Text);
            tabControl1.TabPages.Add(tabPage);
            dgv = CreateDataGridView();
            dgv.DataSource = dataBase.Tables[dataBase.Tables.Count - 1];
            tabPage.Controls.Add(dgv);
            tables.Add(dgv);
            tabControl1.SelectedIndex = dataBase.Tables.Count - 1;
            int indNewTable = dataBase.Tables.Count - 1;
            foreach (DataColumn column in dataBase.Tables[ind].Columns)
            {
                dataBase.Tables[indNewTable].Columns.Add(column.ColumnName);                
            }
            
            foreach (DataRow row in dataBase.Tables[ind].Select(fromBox.Text + " " + selectBox.Text))
            {
                dataBase.Tables[indNewTable].Rows.Add(row.ItemArray);
            }
            fromBox.Clear();
            selectBox.Clear();
        }        
    }
}


