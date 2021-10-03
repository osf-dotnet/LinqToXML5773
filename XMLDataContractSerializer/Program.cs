using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XMLDataContractSerializer
{

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [IgnoreDataMember]
        public int[,] UserMetrix { get; set; }

         [Obsolete("use UserMetrix (not  TempUserMetrix)", true)]      
        [DataMember()]
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
                            result += "," + (UserMetrix[i, j]);
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
                            UserMetrix[i, j] = int.Parse(values[index++]);
                }
            }
        }

        [IgnoreDataMember]
        public string Password { get; set; }
    }




    class Program
    {

        public static void SaveToXML_DataContractSerializer<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            DataContractSerializer dataContract = new DataContractSerializer(source.GetType());
            dataContract.WriteObject(file, source);
            file.Close();
        }

        public static T LoadFromXML_DataContractSerializer<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            DataContractSerializer dataContract = new DataContractSerializer(typeof(T));
            T result = (T)dataContract.ReadObject(file);
            file.Close();
            return result;
        }


        static void Main(string[] args)
        {
            User user = new User
            {
             //   TempUserMetrix = null,
                Id = 123,
                Name = "user 1",
                Password = "abc",
                UserMetrix = new int[2, 3]
                {
                    {10, 20, 30 },
                    {11, 22, 33 }
                }
            };

            SaveToXML_DataContractSerializer(user, "userXmlBy_DataContractSerializer.xml");
            User user2 = LoadFromXML_DataContractSerializer<User>("userXmlBy_DataContractSerializer.xml");
        }
    }
}
