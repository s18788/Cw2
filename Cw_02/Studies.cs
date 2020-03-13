using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

[Serializable]
public class Studies
{
    [JsonPropertyName("name")]
    [XmlElement(ElementName = "name")] 
    public string name { get; set; }

    [JsonPropertyName("mode")]
    [XmlElement(ElementName = "mode")]
    public string mode { get; set; }

    private Studies()
    {
    }

    public Studies(string name, string mode)
    {
        this.name = name;
        this.mode = mode;

    }
}
