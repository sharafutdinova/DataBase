using System.Xml;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DataBase
{
    class WorkWithXML
    {
        public static XmlDocument CreateXML()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(xmlDecl);
            return xmlDoc;
        }

        public static Student GetStudent(XmlNode node)
        {
            string name = node.Attributes[0].Value;
            string surname = node["surname"].InnerText;
            string birthday = node["birthday"].InnerText;
            string email = node["email"].InnerText;
            string phone = node["phone"].InnerText;
            return new Student(name, surname, birthday, email, phone);
        }

        public static XmlDocument SetStudents(List<Student> listS)
        {
            int count = listS.Count;
            XmlDocument xmlDoc = CreateXML();

            XmlElement studentsElement = xmlDoc.CreateElement("students");
            for (int i = 0; i < count; i++)
            {
                XmlElement nameElement = xmlDoc.CreateElement("student");
                nameElement.SetAttribute("name", listS[i].Name);

                XmlElement surnameElement = xmlDoc.CreateElement("surname");
                surnameElement.InnerText = listS[i].Surame;
                nameElement.AppendChild(surnameElement);

                XmlElement birthdayElement = xmlDoc.CreateElement("birthday");
                birthdayElement.InnerText = listS[i].Birthday; ;
                nameElement.AppendChild(birthdayElement);

                XmlElement emailElement = xmlDoc.CreateElement("email");
                emailElement.InnerText = listS[i].Email;
                nameElement.AppendChild(emailElement);

                XmlElement phoneElement = xmlDoc.CreateElement("phone");
                phoneElement.InnerText = listS[i].Phone;
                nameElement.AppendChild(phoneElement);

                studentsElement.AppendChild(nameElement);
            }
            xmlDoc.AppendChild(studentsElement);
            return xmlDoc;
        }

        public static Group GetGroup(XmlNode node)
        {
            string name = node.Attributes[0].Value;
            string year = node["year"].InnerText;
            string steward = node["steward"].InnerText;
            return new Group(name, year, steward);
        }

        public static XmlDocument SetGroup(Group group)
        {
            XmlDocument xmlDoc = CreateXML();

            XmlElement groupElement = xmlDoc.CreateElement("Group");

            XmlElement nameElement = xmlDoc.CreateElement("stud");
            nameElement.SetAttribute("name", group.Name);

            XmlElement yearElement = xmlDoc.CreateElement("year");
            yearElement.InnerText = group.Year; ;
            nameElement.AppendChild(yearElement);

            XmlElement stewardElement = xmlDoc.CreateElement("steward");
            stewardElement.InnerText = group.Steward;
            nameElement.AppendChild(stewardElement);

            groupElement.AppendChild(nameElement);

            xmlDoc.AppendChild(groupElement);
            return xmlDoc;
        }

        public static Faculty GetFaculty(XmlNode node)
        {
            string name = node.Attributes[0].Value;
            string head = node["head"].InnerText;
            return new Faculty(name, head);
        }

        public static XmlDocument SetFaculty(Faculty faculty)
        {
            XmlDocument xmlDoc = CreateXML();

            XmlElement facultyElement = xmlDoc.CreateElement("Faculty");

            XmlElement nameElement = xmlDoc.CreateElement("faculty");
            nameElement.SetAttribute("name", faculty.Name);

            XmlElement headElement = xmlDoc.CreateElement("head");
            headElement.InnerText = faculty.Head;
            nameElement.AppendChild(headElement);

            facultyElement.AppendChild(nameElement);

            xmlDoc.AppendChild(facultyElement);
            return xmlDoc;
        }

        public static University GetUniversity(XmlNode node)
        {
            string name = node.Attributes[0].Value;
            string city = node["city"].InnerText;
            return new University(name, city);
        }

        public static XmlDocument SetUniversity(University university)
        {
            XmlDocument xmlDoc = CreateXML();

            XmlElement universityElement = xmlDoc.CreateElement("University");

            XmlElement nameElement = xmlDoc.CreateElement("university");
            nameElement.SetAttribute("name", university.Name);

            XmlElement cityElement = xmlDoc.CreateElement("city");
            cityElement.InnerText = university.City;

            nameElement.AppendChild(cityElement);

            universityElement.AppendChild(nameElement);

            xmlDoc.AppendChild(universityElement);

            return xmlDoc;
        }
    }
}

