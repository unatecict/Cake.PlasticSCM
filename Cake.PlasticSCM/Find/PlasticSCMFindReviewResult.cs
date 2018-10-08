using System;
using System.Xml.Serialization;

namespace Cake.PlasticSCM.Find
{
    [XmlRoot("REVIEW")]
    public class PlasticSCMFindReviewResult
    {
        [XmlElement("ID")]
        public int Id { get; set; }

        [XmlElement("OWNER")]
        public string Owner { get; set; }

        [XmlElement("DATE")]
        public DateTime Date { get; set; }

        [XmlElement("TITLE")]
        public string Title { get; set; }

        [XmlElement("STATUS")]
        public string Status { get; set; }

        [XmlElement("ASSIGNEE")]
        public string Assignee { get; set; }

        [XmlElement("TARGETTYPE")]
        public string TargetType { get; set; }

        [XmlElement("TARGET")]
        public int Target { get; set; }
    }
}