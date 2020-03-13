using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

[Serializable]
public class ActiveStudies
{

    [JsonPropertyName("name")]
    [XmlAttribute("name")]
    public string name { get; set; }


    [JsonPropertyName("numberOfStudents")]
    [XmlAttribute("numberOfStudents")]
    public int numberOfStudents { get; set; }


    private ActiveStudies()
    {
    }

    public ActiveStudies(int howMany, string name)
    {
        this.numberOfStudents = howMany;
        this.name = name;
    }

}

