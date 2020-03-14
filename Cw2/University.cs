using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Cw2
{
    public class University
    {
        public University()
        {
        }

        [XmlAttribute("createdAt")]
        [JsonProperty("createdAt")]
        public string date { get; set; }

        [XmlAttribute("author")]
        [JsonProperty("author")]
        public string author { get; set; }

        [XmlArray("studenci")]
        [JsonProperty("studenci")]
        public List<Student> Students { get; set; }

        [XmlArray("activeStudies")]
        [JsonProperty("activeStudies")]
        public List<ActiveStudies> Studies { get; set; }





    }

}

