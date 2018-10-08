using System;
using System.Xml.Serialization;

namespace Cake.PlasticSCM.Find
{
    [XmlRoot("BRANCH")]
    public class PlasticSCMFindBranchResult
    {
        [XmlElement("ID")]
        public int Id { get; set; }

        [XmlElement("NAME")]
        public string Name { get; set; }

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

        [XmlElement("TYPE")]
        public string Type { get; set; }

        [XmlElement("CHANGESET")]
        public int Changeset { get; set; }

        [XmlElement("PARENT")]
        public string Parent { get; set; }
    }
}