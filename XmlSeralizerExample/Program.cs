using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Runtime.Serialization;

namespace XmlSeralizerExample
{

    //public class User
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }

    //    [XmlIgnore]
    //    public string Password { get; set; }
    //}


    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [XmlIgnore]
        public int[,] UserMetrix { get; set; }

        //  [Obsolete("use UserMetrix (not  TempUserMetrix)", false)]
        //  [XmlElement]
        //  [XmlAttribute("value")]
        //public string TempUserMetrix
        //{
        //    get
        //    {
        //        if (UserMetrix == null)
        //            return null;

        //        string result = "";
        //        if (UserMetrix != null)
        //        {
        //            int sizeA = UserMetrix.GetLength(0);
        //            int sizeB = UserMetrix.GetLength(1);
        //            result += "" + sizeA + "," + sizeB;

        //            for (int i = 0; i < sizeA; i++)
        //                for (int j = 0; j < sizeB; j++)
        //                    result += "," + UserMetrix[i, j];
        //        }
        //        return result;
        //    }

        //    set
        //    {
        //        if (value != null && value.Length > 0)
        //        {
        //            string[] values = value.Split(',');
        //            int sizeA = int.Parse(values[0]);
        //            int sizeB = int.Parse(values[1]);

        //            UserMetrix = new int[sizeA, sizeB];

        //            int index = 2;

        //            for (int i = 0; i < sizeA; i++)
        //                for (int j = 0; j < sizeB; j++)
        //                    UserMetrix[i, j] = int.Parse(values[index++]);
        //        }
        //    }
        //}

        string ToXMLstring<T>(T toSerialize)
        {
            using (StringWriter textWriter = new StringWriter())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        T ToObject<T>(string toDeserialize)
        {
            using (StringReader textReader = new StringReader(toDeserialize))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }


        public string TempUserMetrix
        {
            get
            {
                if (UserMetrix == null)
                    return null;

                string result = "";
                if (UserMetrix != null)
                {
                    int sizeA = UserMetrix.GetLength(0);
                    int sizeB = UserMetrix.GetLength(1);
                    result += "" + sizeA + "," + sizeB;

                    for (int i = 0; i < sizeA; i++)
                        for (int j = 0; j < sizeB; j++)
                            result += "," + ToXMLstring(UserMetrix[i, j]);
                }
                return result;
            }

            set
            {
                if (value != null && value.Length > 0)
                {
                    string[] values = value.Split(',');
                    int sizeA = int.Parse(values[0]);
                    int sizeB = int.Parse(values[1]);

                    UserMetrix = new int[sizeA, sizeB];

                    int index = 2;

                    for (int i = 0; i < sizeA; i++)
                        for (int j = 0; j < sizeB; j++)
                            UserMetrix[i, j] = ToObject<int>(values[index++]);
                }
            }
        }




        [XmlIgnore]
        public string Password { get; set; }
    }


    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public enum Gender { male, female }

    public class Student
    {
        [XmlIgnore]
        public DateTime[,] Time { get; set; }


        //public string Temp
        // {
        //     get
        //     {
        //         if (Time == null)
        //             return null;




        //         string result = "";
        //         if (Time != null)
        //         {

        //             int sizeA = Time.GetLength(0);
        //             int sizeB = Time.GetLength(1);
        //             result += $"{sizeA},{sizeB}";

        //             for (int i = 0; i < sizeA; i++)
        //             {

        //                 for (int j = 0; j < sizeB; j++)
        //                 {
        //                     result += $",{Time[i, j]}";
        //                 }                       
        //             }
        //         }
        //         return result;


        //         //List<List<int>> result =  new List<List<int>>();
        //         //if (Time != null)
        //         //{
        //         //    result = new List<List<int>>();

        //         //    int sizeA = Time.GetLength(0);
        //         //    int sizeB = Time.GetLength(1);

        //         //    for (int i = 0; i < sizeA; i++)
        //         //    {
        //         //        List<int> list = new List<int>();
        //         //        for (int j = 0; j < sizeB; j++)
        //         //        {
        //         //            list.Add(Time[i, j]);
        //         //       }

        //         //        result.Add(list);
        //         //    }
        //         //}
        //         //return result;
        //     }

        //     set
        //     {
        //         if (value != null && value.Length > 0)
        //         {
        //             string[] values = value.Split(',');
        //             int sizeA = int.Parse(values[0]);
        //             int sizeB = int.Parse(values[1]);

        //             Time = new DateTime[sizeA, sizeB];

        //             int index = 2;

        //             for (int i = 0; i < sizeA; i++)
        //             {                       
        //                 for (int j = 0; j < sizeB; j++)
        //                 {
        //                     Time[i, j] = DateTime.Parse(values[index++]);
        //                 }
        //             }


        //         }

        //         //if (value != null && value.Count > 0)
        //         //{
        //         //    int sizeA = value.Count;
        //         //    int sizeB = value[0].Count;

        //         //    Time = new int[sizeA, sizeB];

        //         //    for (int i = 0; i < sizeA; i++)
        //         //    {
        //         //      
        //         //        for (int j = 0; j < sizeB; j++)
        //         //        {
        //         //            Time[i, j] = value[i][j];
        //         //        }
        //         //    }
        //         //}
        //     }
        // }


        public int Id { get; set; }
        public string PersonName { get; set; }
        public bool IsMarried { get; set; }
        public DateTime PersonDate { get; set; }
        public Gender StudentGender { get; set; }
        public List<Course> Courses { get; set; }

        public Student()
        {
            Courses = new List<Course>();
        }


    }


    class Program
    {
        private static List<Student> getList()
        {
            List<Student> studentList;
            List<Course> courseList;
            courseList = new List<Course>();
            string[] courseNameArray = new string[] { "c#", "java", "מבנה המחשב", "c++", "אינפי", "בדידה", "מבוא לתכנות" };
            for (int i = 0; i < courseNameArray.Length; i++)
                courseList.Add(new Course { Id = i, Name = courseNameArray[i] });

            string[] studentNameArray = new string[] { "אברהם", "יצחק", "יעקוב", "שרה", "רחל" };
            int id = -1;

            studentList = new List<Student>
            {
                new Student {Id = ++id ,
                    IsMarried = true ,
                    PersonDate = DateTime.Parse("7.12.1981"),
                    PersonName = studentNameArray[id],
                    StudentGender =  Gender.male,


                },
                new Student {Id = ++id ,
                    IsMarried = false ,
                    PersonDate = DateTime.Parse("31.12.1985"),
                    PersonName = studentNameArray[id],
                    StudentGender = Gender.male ,
                    //Time = new DateTime[2,3]
                    //{
                    //    {DateTime.Now,DateTime.Now.AddDays(1) ,DateTime.Now.AddDays(2)},
                    //   {DateTime.Now.AddHours(5),DateTime.Now.AddYears(1) ,DateTime.Now.AddMonths(2)},

                   //},
                
                  Courses = new List<Course>{courseList[3],courseList[2],courseList[1]}
                },
                new Student {Id = ++id ,
                    IsMarried = true ,
                    PersonDate = DateTime.Parse("13.12.1971"),
                    PersonName = studentNameArray[id],
                    StudentGender = Gender.male,

                  Courses = new List<Course>{courseList[6],courseList[2],courseList[4]}
                },
                new Student {Id = ++id ,
                    IsMarried = false ,
                    PersonDate = DateTime.Parse("13.12.1985"),
                    PersonName = studentNameArray[id],
                    StudentGender = Gender.female ,
                  Courses = new List<Course>{courseList[1],courseList[2],courseList[5]},

                },
                new Student {Id = ++id ,
                    IsMarried = true ,
                    PersonDate = DateTime.Parse("13.12.1985"),
                    PersonName = studentNameArray[id],
                    StudentGender = Gender.female
                    ,
                  Courses = new List<Course>{courseList[3],courseList[3],courseList[5]},

                },
            };

            return studentList;
        }

        //public static void SaveListToXML(List<Student> list, string path)
        //{
        //    FileStream file = new FileStream(path, FileMode.Create);
        //    XmlSerializer xmlSerializer = new XmlSerializer(list.GetType());
        //    xmlSerializer.Serialize(file, list);
        //    file.Close();
        //}

        //public static List<Student> LoadListFromXML(string path)
        //{
        //    FileStream file = new FileStream(path, FileMode.Open);
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));       
        //    List<Student>  list = (List<Student>)xmlSerializer.Deserialize(file);
        //    file.Close();
        //    return list;
        //}

        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source);
            file.Close();
        }

        public static T LoadFromXML<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T result = (T)xmlSerializer.Deserialize(file);
            file.Close();
            return result;
        }








        static void Main(string[] args)
        {

            User user = new User
            {
                Id = 123,
                Name = "user 1",
                Password = "abc",
                UserMetrix = new int[2, 3]
                {
                    {10, 20, 30 },
                    {11, 22, 33 }
                }
            };

            SaveToXML(user, "userXmlBySerilalizer.xml");
            User user2 = LoadFromXML<User>("userXmlBySerilalizer.xml");

            List<Student> list = getList();

            string path = "xmlBySerilalizer.xml";

            SaveToXML(list, path);

            List<Student> list2 = LoadFromXML<List<Student>>(path);

            //Student s = new Student { Id = 43, PersonName = "ddjjd" };
            //XmlSerializer x = new XmlSerializer(s.GetType());
            //FileStream fs = new FileStream("11"+path, FileMode.Create);
            //x.Serialize(fs, s);

            Console.ReadLine();
        }
    }
}
