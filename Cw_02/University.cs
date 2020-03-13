
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

[Serializable]
public class University
{
    [JsonPropertyName("createdAt")]
    [XmlAttribute("createdAt")]
    public string created { get; set; }


    [JsonPropertyName("author")]
    [XmlAttribute("author")]
    public string author { get; set; }


    [XmlArray("studenci")]
    [XmlArrayItem("student")]
    public HashSet<Student> students { get; } = new HashSet<Student>();

    [JsonPropertyName("activeStudies")]
    [XmlArray("activeStudies")]
    [XmlArrayItem("studies")]
    public List<ActiveStudies> activeStudies { get; set; } = new List<ActiveStudies>();


    private University()
    {

    }

    public University(DateTime created, string author)
    {
        this.created = created.ToString("dd.MM.yyyy");
        this.author = author;
    }

    public void addStudent(Student student)
    {
        students.Add(student);
    }
}
