using System;

namespace DataBase
{
    public class Student
    {
        private string _name;
        private string _phone;
        private string _surname;
        private string _email;
        private string _birthday;

        public Student(string name, string surname, string birthday, string email, string phone)
        {
            _surname = surname;
            _email = email;
            _birthday = birthday;
            _phone = phone;
            _name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Surame
        {
            get
            {
                return _surname;
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
        }

        public string Birthday
        {
            get
            {
                return _birthday;
            }
        }

    }

    public class Group
    {
        private string _name;
        private string _year;
        private string _steward;

        public Group(string name, string year)
        {
            _name = name;
            _year = year;
        }

        public Group(string name, string steward, string year)
        {
            _name = name;
            _steward = steward;
            _year = year;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Year
        {
            get
            {
                return _year;
            }
        }

        public string Steward
        {
            get
            {
                return _steward;
            }
        }
    }

    public class Faculty
    {
        private string _name;
        private string _head;

        public Faculty(string name, string head)
        {
            _name = name;
            _head = head;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Head
        {
            get
            {
                return _head;
            }
        }
    }

    public class University
    {
        private string _name;
        private string _city;

        public University(string name, string city)
        {
            _name = name;
            _city = city;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string City
        {
            get
            {
                return _city;
            }
        }
    }
}

