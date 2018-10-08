using System;
using System.Xml.Serialization;
    
namespace Cake.PlasticSCM.Find
{
    [XmlRoot("CHANGESET")]
    public class PlasticSCMFindChangesetResult
    {
        [XmlElement("ID")]
        public int Id { get; set; }

        [XmlElement("CHANGESETID")]
        public int ChangesetId { get; set; }

        [XmlElement("COMMENT")]
        public string Comment { get; set; }

        [XmlElement("DATE")]
        public DateTime Date { get; set; }

        [XmlElement("OWNER")]
        public string Owner { get; set; }

        [XmlElement("REPOSITORY")]
        public string Repository { get; set; }

        [XmlElement("REPNAME")]
        public string Repname { get; set; }

        [XmlElement("REPSERVER")]
        public string Repserver { get; set; }

        [XmlElement("BRANCH")]
        public string Branch { get; set; }

        [XmlElement("PARENT")]
        public string Parent { get; set; }

        [XmlElement("GUID")]
        public string Guid { get; set; }
    }
}
