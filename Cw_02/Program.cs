using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

class Program
{
    private static TraceSource ts = new TraceSource("TraceTest");

    static void Main(string[] args)
    {
        var inPutPath = @"data.csv";
        var outPutPath = @"result.xml";
        var outPutFormat = "xml";

        if (args.Length > 0)
            inPutPath = args[0];
        if (args.Length > 1)
            outPutPath = args[1];
        if (args.Length > 2)
            outPutFormat = args[2];

        University university = new University(DateTime.Now, "Jan Kowalski");
        FileInfo file;
        try
        {
            file = new FileInfo(inPutPath);
        }
        catch (ArgumentException ex)
        {
            ts.TraceEvent(TraceEventType.Error, 1, "Invalid path - ArgumentException " + inPutPath);
            throw new ArgumentException($"Sciezka {inPutPath} jest nieprawidlowa");
        }
        FileStream reader;
        try
        {
            reader = file.OpenRead();
        }
        catch (FileNotFoundException ex)
        {
            ts.TraceEvent(TraceEventType.Error, 1, "Cannot open file - FileNotFoundException " + inPutPath);
            throw new FileNotFoundException($"Plik {inPutPath} nie istnieje ");
        }
        using (var stream = new StreamReader(reader))
        {
            string line = null;
            while ((line = stream.ReadLine()) != null)
            {
                Student parsed = parseStudent(line);

                if (parsed == null)
                {
                    ts.TraceEvent(TraceEventType.Error, 1, line);
                    continue;

                }
                else
                {
                    university.addStudent(parsed);

                }
            }
        }

        var counts = new Dictionary<string, int>();
        foreach (var student in university.students)
        {
            string study = student.study.name;
            if (counts.ContainsKey(study))
                counts[study] += 1;
            else
                counts[study] = 1;
        }

        foreach (var entry in counts)
        {
            university.activeStudies.Add(new ActiveStudies(entry.Value, entry.Key));
        }

        if (outPutFormat == "xml")
        {
            FileStream writer = new FileStream(outPutPath, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(University),
                                       new XmlRootAttribute("uczelnia"));
            serializer.Serialize(writer, university);
        }
        else if (outPutFormat == "json")
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            var jsonString = JsonSerializer.Serialize(university, options);
            File.WriteAllText(outPutPath, jsonString);
        }



        ts.Close();


    }

    public static Student parseStudent(string line)
    {
        string[] studentData = line.Split(',');
        Student s = null;
        if (studentData.Length == 9)
        {
            string firstName = studentData[0];
            if (string.IsNullOrWhiteSpace(firstName))
                return null;
            string name = studentData[1];
            if (string.IsNullOrWhiteSpace(name))
                return null;
            string studies = studentData[2];
            if (string.IsNullOrWhiteSpace(studies))
                return null;
            string mode = studentData[3];
            if (string.IsNullOrWhiteSpace(mode))
                return null;
            string index = studentData[4];
            if (string.IsNullOrWhiteSpace(index))
                return null;
            string strDateOfBirth = studentData[5];
            if (string.IsNullOrWhiteSpace(strDateOfBirth))
                return null;
            DateTime dateOfBirth;
            if (!DateTime.TryParse(strDateOfBirth, out dateOfBirth))
                return null;
            string email = studentData[6];
            if (string.IsNullOrWhiteSpace(email))
                return null;
            string mothersFName = studentData[7];
            if (string.IsNullOrWhiteSpace(mothersFName))
                return null;
            string fathersFName = studentData[8];
            if (string.IsNullOrWhiteSpace(fathersFName))
                return null;


            s = new Student(firstName, name, studies, mode, index,
                dateOfBirth, email, mothersFName, fathersFName);
        }

        return s;
    }
}

