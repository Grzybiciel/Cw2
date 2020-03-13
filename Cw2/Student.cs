using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Cw2
{
    [XmlType("student")]
    public class Student
    {
        public Student(string[] singleLine)
        {
            this.FirstName = singleLine[0];
            this.LastName = singleLine[1];
            this.studies = new Studies
            {
                name = singleLine[2]
                ,
                mode = singleLine[3]
            };
            this.Index = "s" + singleLine[4];
            this.BirthDate = DateTime.Parse(singleLine[5]).ToShortDateString();
            this.Email = singleLine[6];
            this.MothersName = singleLine[7];
            this.FathersName = singleLine[8];
        }


        [XmlAttribute(attributeName: "indexnumber")]
        [JsonProperty("indexnumber")]
        public string Index { get; set; }

        [XmlElement("fname")]
        [JsonProperty("fname")]
        public string FirstName { get; set; }


        [XmlElement("lname")]
        [JsonProperty("lname")]
        public string LastName { get; set; }


        [XmlElement("birthdate")]
        [JsonProperty("birthdate")]
        public string BirthDate { get; set; }


        [XmlElement("email")]
        [JsonProperty("email")]
        public string Email { get; set; }


        [XmlElement("mothersName")]
        [JsonProperty("mothersName")]
        public string MothersName { get; set; }


        [XmlElement("fathersName")]
        [JsonProperty("fathersName")]
        public string FathersName { get; set; }


        [XmlElement("studies")]
        [JsonProperty("studies")]
        public Studies studies { get; set; }

    }
    public class Studies
    {
        [XmlElement("studiesName")]
        [JsonProperty("studiesName")]
        public string name { get; set; }


        [XmlElement("studiesMode")]
        [JsonProperty("studiesMode")]
        public string mode { get; set; }
    }
}
