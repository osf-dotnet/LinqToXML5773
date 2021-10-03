using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            //XElement x1 = new XElement("name","oshri");
            //XElement x2 = new XElement("ID", 123);
            //XElement x3 = new XElement("student", x1, x2);
            
         XElement  x3 = XElement.Load("tempTAL.xml");

         IEnumerable<XElement> list = x3.Elements();

         foreach (var item in list)
         {
             string name = item.Element("name").Value;
             XElement x = new XElement("mail", name+"@jct.ac.il");
             item.AddFirst(x);
             Console.WriteLine(item);
             Console.WriteLine();
         }

           // <name/>  
        
        }
    }
}
