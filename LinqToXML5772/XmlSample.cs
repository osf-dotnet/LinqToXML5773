using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace LinqToXML5772
{
    class XmlSample
    {
        XElement studentRoot;
        string studentPath = @"StudentXml.xml";

        public XmlSample()
        {
            if (!File.Exists(studentPath))
                CreateFiles();
            else
                LoadData();
        }

        private void CreateFiles()
        {
            studentRoot = new XElement("students");
            studentRoot.Save(studentPath);
        }

        private void LoadData()
        {
            try
            {
                studentRoot = XElement.Load(studentPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }

        public void SaveStudentList(List<Student> studentList)
        {
            studentRoot = new XElement("students");

            foreach (Student item in studentList)
            {
                //XElement id = new XElement("id", item.Id);
                //XElement firstName = new XElement("firstName", item.FirstName);
                //XElement lastName = new XElement("lastName", item.LastName);

                //XElement name = new XElement("name", firstName, lastName);
                //XElement student = new XElement("student", id, name);

                //studentRoot.Add(student);

                AddStudent(item);
            }

            studentRoot.Save(studentPath);
        }
        public void SaveStudentListLinq(List<Student> studentList)
        {
            var v = from p in studentList
                    select new XElement("student",
                        new XElement("id", p.Id),
                       new XElement("name",
                            new XElement("firstName", p.FirstName),
                            new XElement("lastName", p.LastName)
                            )
                        );

            studentRoot = new XElement("students", v);


            studentRoot.Save(studentPath);
        }

        public List<Student> GetStudentList()
        {
            LoadData();
            List<Student> students;
            try
            {
                students = (from stu in studentRoot.Elements()
                            select new Student()
                            {
                                Id = int.Parse(stu.Element("id").Value),
                                FirstName = stu.Element("name").Element("firstName").Value,
                                LastName = stu.Element("name").Element("lastName").Value
                            }).ToList();
            }
            catch
            {
                students = null;
            }
            return students;
        }

        public Student GetStudent(int id)
        {
            LoadData();
            Student student;
            try
            {
                student = (from stu in studentRoot.Elements()
                           where int.Parse(stu.Element("id").Value) == id
                           select new Student()
                           {
                               Id = int.Parse(stu.Element("id").Value),
                               FirstName = stu.Element("name").Element("firstName").Value,
                               LastName = stu.Element("name").Element("lastName").Value
                           }).FirstOrDefault();
            }
            catch
            {
                student = null;
            }
            return student;
        }

        public string GetStudentName(int id)
        {
            LoadData();
            string studentName;
            try
            {
                studentName = (from stu in studentRoot.Elements()
                               where int.Parse(stu.Element("id").Value) == id
                               select stu.Element("name").Element("firstName").Value
                               + " " +
                                   stu.Element("name").Element("lastName").Value
                                    ).FirstOrDefault();
            }
            catch
            {
                studentName = null;
            }
            return studentName;
        }

        public void AddStudent(Student student)
        {
            XElement id = new XElement("id", student.Id);
            XElement firstName = new XElement("firstName", student.FirstName);
            XElement lastName = new XElement("lastName", student.LastName);
            XElement name = new XElement("name", firstName, lastName);

            studentRoot.Add(new XElement("student", id, name));
            studentRoot.Save(studentPath);
        }

        public bool RemoveStudent(int id)
        {
            XElement studentElement;
            try
            {
                studentElement = (from stu in studentRoot.Elements()
                                  where int.Parse(stu.Element("id").Value) == id
                                  select stu).FirstOrDefault();
                studentElement.Remove();
                studentRoot.Save(studentPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateStudent(Student student)
        {
            XElement studentElement = (from stu in studentRoot.Elements()
                                       where int.Parse(stu.Element("id").Value) == student.Id
                                       select stu).FirstOrDefault();

            studentElement.Element("name").Element("firstName").Value = student.FirstName;
            studentElement.Element("name").Element("lastName").Value = student.LastName;

            studentRoot.Save(studentPath);
        }
    }
}
