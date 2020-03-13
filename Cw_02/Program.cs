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
            HashSet<Student> listOfStudents = new HashSet<Student>();

            //Wczytywanie 

            var file = new FileInfo(path);
            using (var stream = new StreamReader(file.OpenRead()))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] studentData = line.Split(',');
                    if (studentData.Length == 9)
                    {
                        listOfStudents.Add(new Student(studentData[0], studentData[1], studentData[4], DateTime.Parse(studentData[5]), studentData[6], studentData[7], studentData[8]));
                        Studies studies = new Studies(studentData[2], studentData[3]);
                    }
                    else
                    {
                        //wpisywanie studenta do log.txt
                    }
                }
            }
            //stream.Dispose();

            //XML



            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                                       new XmlRootAttribute("uczelnia"));
            serializer.Serialize(writer, listOfStudents);
            serializer.Serialize(writer, listOfStudents);



        }
    }
}
