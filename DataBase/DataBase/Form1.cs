using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace DataBase
{
    public partial class Form1 : Form
    {
        private string universityName;
        private string facultyName;
        private string groupName;
        private string wayUniver;

        private List<University> listU = new List<University>();
        private List<Faculty> listF = new List<Faculty>();
        private List<Group> listG = new List<Group>();
        private List<Student> listS = new List<Student>();

        public Form1()
        {
            InitializeComponent();
        }

        public void Clear(DataGridView dgv)
        {
            dgv.Rows.Clear();
        }
        
        public List<string> GetList(string way)
        {
            List<string> list = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(way);
            foreach (var item in dir.GetDirectories())
            {
                list.Add(item.ToString());
            }
            return list;
        }

        public void Empty()
        {
            MessageBox.Show("No data");
        }

        private void addU_Click(object sender, EventArgs e)
        {
            addUPanel.Visible = true;
        }

        private void addF_Click(object sender, EventArgs e)
        {
            addFPanel.Visible = true;
        }

        private void addG_Click(object sender, EventArgs e)
        {
            addGPanel.Visible = true;
        }

        private void addS_Click(object sender, EventArgs e)
        {
            addSPanel.Visible = true;
        }

        private void addUButton_Click(object sender, EventArgs e)
        {
            int count = addUTable.Rows.Count;
            for (int i = 0; i < count - 1; i++)
            {
                listU.Add(new University(addUTable[0, i].Value.ToString(), addUTable[1, i].Value.ToString()));
            }
            Clear(addUTable);
            universities.DataSource = null;
            universities.DataSource = listU;
            addUPanel.Visible = false;
        }

        private void addFButton_Click(object sender, EventArgs e)
        {
            int count = addFTable.Rows.Count;
            for (int i = 0; i < count - 1; i++)
            {
                listF.Add(new Faculty(addFTable[0, i].Value.ToString(), addFTable[1, i].Value.ToString()));
            }
            Clear(addFTable);
            faculties.DataSource = null;
            faculties.DataSource = listF;
            addFPanel.Visible = false;
        }

        private void addGButton_Click(object sender, EventArgs e)
        {
            int count = addGTable.Rows.Count;
            for (int i = 0; i < count - 1; i++)
            {
                listG.Add(new Group(addGTable[0, i].Value.ToString(), addGTable[1, i].Value.ToString(), addGTable[2,i].Value.ToString()));
            }
            Clear(addGTable);
            groups.DataSource = null;
            groups.DataSource = listG;
            addGPanel.Visible = false;
        }

        private void addSButton_Click(object sender, EventArgs e)
        {
            int count = addSTable.Rows.Count;
            for (int i = 0; i < count - 1; i++)
            {
                listS.Add(new Student(addSTable[0, i].Value.ToString(), addSTable[1, i].Value.ToString(), addSTable[2, i].Value.ToString(), addSTable[3, i].Value.ToString(), addSTable[4, i].Value.ToString()));
            }
            Clear(addSTable);
            students.DataSource = null;
            students.DataSource = listS;
            addSPanel.Visible = false;
        }

        private void deleteU_Click(object sender, EventArgs e)
        {
            int index = universities.SelectedCells[0].RowIndex;
            listU.RemoveAt(index);

            universities.DataSource = null;
            universities.DataSource = listU;
        }
        
        private void deleteF_Click(object sender, EventArgs e)
        {
            int index = faculties.SelectedCells[0].RowIndex;
            listF.RemoveAt(index);

            faculties.DataSource = null;
            faculties.DataSource = listF;
        }

        private void deleteG_Click(object sender, EventArgs e)
        {
            int index = groups.SelectedCells[0].RowIndex;
            listG.RemoveAt(index);

            groups.DataSource = null;
            groups.DataSource = listG;
        }

        private void deleteS_Click(object sender, EventArgs e)
        {
            int index = students.SelectedCells[0].RowIndex;
            listS.RemoveAt(index);

            students.DataSource = null;
            students.DataSource = listS;
        }

        public void SaveFile(string name, string way, XmlDocument xmlDoc)
        {
            Directory.CreateDirectory(way + @"\" + name);
            xmlDoc.Save(way + @"\" + name + @"\" + name + ".xml");
        }

        private void saveU_Click(object sender, EventArgs e)
        {
            wayUniver = WayToUniversity();
            wayUniver += @"\Universities";
            int count = listU.Count;
            for (int i = 0; i < count; i++)
            {
                string name = listU[i].Name;
                XmlDocument xmlDoc = WorkWithXML.SetUniversity(listU[i]);
                SaveFile(name, wayUniver, xmlDoc);
            }
        }

        private void saveF_Click(object sender, EventArgs e)
        {
            int count = listF.Count;
            string way = WayToFaculty();
            for (int i = 0; i < count; i++)
            {
                string name = listF[i].Name;

                XmlDocument xmlDoc = WorkWithXML.SetFaculty(listF[i]);
                SaveFile(name, wayUniver, xmlDoc);
            }
        }

        private void saveG_Click(object sender, EventArgs e)
        {
            int count = listG.Count;
            string way = WayToGroup();
            for (int i = 0; i < count; i++)
            {
                string name = listG[i].Name;

                XmlDocument xmlDoc = WorkWithXML.SetGroup(listG[i]);
                SaveFile(name, wayUniver, xmlDoc);
            }
        }

        private void saveS_Click(object sender, EventArgs e)
        {
            string way = WayToStudents();
            string name = "students";

            XmlDocument xmlDoc = WorkWithXML.SetStudents(listS);

            SaveFile(name, wayUniver, xmlDoc);
        }

        private void openU_Click(object sender, EventArgs e)
        {
            wayUniver = WayToUniversity();
            universities.DataSource = null;
            faculties.DataSource = null;
            groups.DataSource = null;
            students.DataSource = null;
            listU = new List<University>();
            List<string> univer = GetList(wayUniver);
            if (univer.Count == 0)
            {
                Empty();
            }
            else
            {
                int count = univer.Count;
                for (int i = 0; i < count; i++)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(wayUniver + @"\" + univer[i] + @"\" + univer[i] + ".xml");

                    foreach (XmlNode node in doc.DocumentElement)
                    {
                        University unvr = WorkWithXML.GetUniversity(node);
                        listU.Add(unvr);
                    }
                }
                universities.DataSource = listU;
            }
        }

        private void openF_Click(object sender, EventArgs e)
        {
            faculties.DataSource = null;
            groups.DataSource = null;
            students.DataSource = null;
            listF = new List<Faculty>();
            string way = WayToFaculty();
            if (way != null)
            {
                List<string> facult = GetList(way);
                if (facult.Count == 0)
                {
                    Empty();
                }
                else
                {
                    int count = facult.Count;
                    for (int i = 0; i < count; i++)
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(way + @"\" + facult[i] + @"\" + facult[i] + ".xml");

                        foreach (XmlNode node in doc.DocumentElement)
                        {
                            Faculty fclt = WorkWithXML.GetFaculty(node);
                            listF.Add(fclt);
                        }
                    }
                    faculties.DataSource = listF;
                }
            }
        }

        private void openG_Click(object sender, EventArgs e)
        {
            groups.DataSource = null;
            students.DataSource = null;
            listG = new List<Group>();
            string way = WayToGroup();
            if (way != null)
            {
                List<string> group = GetList(way);
                if (group.Count == 0)
                {
                    Empty();
                }
                else
                {
                    int count = group.Count;
                    for (int i = 0; i < count; i++)
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(way + @"\" + group[i] + @"\" + group[i] + ".xml");

                        foreach (XmlNode node in doc.DocumentElement)
                        {
                            Group grup = WorkWithXML.GetGroup(node);
                            listG.Add(grup);
                        }
                    }
                    groups.DataSource = listG;
                }
            }
        }

        private void openS_Click(object sender, EventArgs e)
        {
            students.DataSource = null;
            listS = new List<Student>();
            string way = WayToStudents();
            if (way != null)
            {
                List<string> stud = GetList(way);
                if (stud.Count == 0)
                {
                    Empty();
                }
                else
                {
                    int count = stud.Count;
                    for (int i = 0; i < count; i++)
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(way + @"\" + stud[i] + @"\" + stud[i] + ".xml");

                        foreach (XmlNode node in doc.DocumentElement)
                        {
                            Student student = WorkWithXML.GetStudent(node);
                            listS.Add(student);
                        }
                    }
                    students.DataSource = listS;
                }
            }
        }

        public string WayToUniversity()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            return folderBrowserDialog.SelectedPath;
        }

        public string WayToFaculty()
        {
            if (universities.SelectedCells[0].Value != null)
            {
                if (universities.SelectedCells[0].ColumnIndex == 0)
                {
                    universityName = universities.SelectedCells[0].Value.ToString();
                    return wayUniver + @"\" + universityName;
                }
                else
                {
                    MessageBox.Show("Select university name!");
                    return null;
                }
            }
            else
            {
                ChooseThePath();
                return null;
            }
        }

        public string WayToGroup()
        {
            if (faculties.SelectedCells[0].Value != null && WayToFaculty() != null)
            {
                if (faculties.SelectedCells[0].ColumnIndex == 0)
                {
                    facultyName = faculties.SelectedCells[0].Value.ToString();
                    return WayToFaculty() + @"\" + facultyName;
                }
                else
                {
                    MessageBox.Show("Select faculty name!");
                    return null;
                }
            }
            else
            {
                ChooseThePath();
                return null;
            }
        }

        public string WayToStudents()
        {
            if (groups.SelectedCells[0].Value != null && WayToGroup() != null)
            {
                if (groups.SelectedCells[0].ColumnIndex == 0)
                {
                    groupName = groups.SelectedCells[0].Value.ToString();
                    return WayToGroup() + @"\" + groupName;
                }
                else
                {
                    MessageBox.Show("Select group name!");
                    return null;
                }
            }
            else
            {
                ChooseThePath();
                return null;
            }
        }

        public void ChooseThePath()
        {
            MessageBox.Show("Choose the path");
        }
    }
}
