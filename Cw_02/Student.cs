using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

[Serializable]
public class Student
{

    [JsonPropertyName("indexNumber")]
    [XmlAttribute("indexNumber")]
    public string index { get; set; }


    [JsonPropertyName("fname")]
    [XmlElement(ElementName = "fname")]
    public string firstName { get; set; }


    [JsonPropertyName("lname")]
    [XmlElement(ElementName = "lname")]
    public string name { get; set; }


    [JsonPropertyName("birthdate")]
    [XmlElement(ElementName = "birthdate")]
    public DateTime dateOfBirth { get; set; }


    [JsonPropertyName("email")]
    [XmlElement(ElementName = "email")]
    public string email { get; set; }


    [JsonPropertyName("mothersName")]
    [XmlElement(ElementName = "mothersName")]
    public string mothersFName { get; set; }


    [JsonPropertyName("fathersName")]
    [XmlElement(ElementName = "fathersName")]
    public string fathersFName { get; set; }


    [JsonPropertyName("studies")]
    [XmlElement(ElementName = "studies")]
    public Studies study { get; set; }


    private Student()
    {
    }
    public Student(string firstName, string name, string studiesName, string studiesMode, string index, DateTime dateOfBirth, string email, string mothersFName, string fathersFName)
    {
        this.firstName = firstName;
        this.name = name;
        study = new Studies(studiesName, studiesMode);
        this.index = index;
        this.dateOfBirth = dateOfBirth;
        this.email = email;
        this.mothersFName = mothersFName;
        this.fathersFName = fathersFName;

    }

    public override bool Equals(object obj)
    {
        Student other = obj as Student;
        if (other == null)
            return false;
        return firstName == other.firstName && name == other.name && index == other.index;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(firstName, name, index);
    }
}
