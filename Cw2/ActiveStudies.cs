using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Management.Automation;
using System.Text;
using System.Xml.Serialization;

namespace Cw2
{
    public class ActiveStudies
    {
        [XmlAttribute("name")]
        [JsonProperty("name")]
        public string name { get; set; }

        [XmlAttribute("numberOfStudents")]
        [JsonProperty("numberOfStudents")]
        public string numberOfStudents { get; set; }
    }
}
   
