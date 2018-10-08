using System;
using System.Xml.Serialization;

namespace Cake.PlasticSCM.Find
{
    [XmlRoot("ATTRIBUTE")]
    public class PlasticSCMFindAttributeResult
    {
        [XmlElement("ID")]
        public int Id { get; set; }

        [XmlElement("COMMENT")]
        public string Comment { get; set; }

        [XmlElement("DATE")]
        public DateTime Date { get; set; }

        [XmlElement("OWNER")]
        public string Owner { get; set; }

        [XmlElement("TYPE")]
        public string Type { get; set; }

        [XmlElement("SRCID")]
        public int SrcId { get; set; }

        [XmlElement("SRCCOMMENT")]
        public string SrcComment { get; set; }

        [XmlElement("SRCDATE")]
        public DateTime SrcDate { get; set; }

        [XmlElement("SRCOWNER")]
        public string SrcOwner { get; set; }

        [XmlElement("SRCREPID")]
        public int SrcRepId { get; set; }

        [XmlElement("SRCREPNAME")]
        public string SrcRepName { get; set; }

        [XmlElement("SRCREPSERVER")]
        public string SrcRepServer { get; set; }

        [XmlElement("NAME")]
        public string Name { get; set; }

        [XmlElement("VALUE")]
        public string Value { get; set; }
    }
}