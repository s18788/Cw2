using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Cw_02
{
    class Program
    {
        static void Main(string[] args)
        {


            string path = @"C:\\College\\C#\\Cw2";
       

            //Wczytywanie 
            var file = new FileInfo(path);
            using (var stream = new StreamReader(file.OpenRead()))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] kolumny = line.Split(',');
                    Console.WriteLine(line);
                }
            }
            //stream.Dispose();

            //XML
            var list = new List<Student>();
            var st = new Student("Jan",
                "Kowalski",
                "kowalski@wp.pl");
            list.Add(st);

            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                                       new XmlRootAttribute("uczelnia"));
            serializer.Serialize(writer, list);
            serializer.Serialize(writer, list);



        }
    }
}
