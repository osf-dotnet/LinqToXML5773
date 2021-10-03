using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToXML5772
{
    class Program
    {
static void Main(string[] args)
{
    XmlSample xml = new XmlSample();

    for (int i = 0; i < 10; i++)
    {
        Student s = new Student
        { Id = i, FirstName = "first" + i, LastName = "last" + i };

        

        xml.AddStudent(s);
    }
    xml.RemoveStudent(5);
    xml.UpdateStudent(new Student { Id = 2, FirstName = "oshri", LastName = "cohen" });
    List<Student> list = xml.GetStudentList();

   

    foreach (var item in list)
    {
        Console.WriteLine("id:{0,-5} name:{1} {2}", item.Id, item.FirstName, item.LastName);
    }

    

}


    }
}
