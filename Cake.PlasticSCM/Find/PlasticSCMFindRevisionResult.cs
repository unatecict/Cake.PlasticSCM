using System;
using System.Xml.Serialization;

namespace Cake.PlasticSCM.Find
{
    [XmlRoot("REVISION")]
    public class PlasticSCMFindRevisionResult
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

        [XmlElement("SIZE")]
        public int Size { get; set; }

        [XmlElement("CHANGESET")]
        public int Changeset { get; set; }

        [XmlElement("PARENT")]
        public int Parent { get; set; }

        [XmlElement("ITEM")]
        public string Item { get; set; }

        [XmlElement("ITEMID")]
        public int ItemId { get; set; }

        [XmlElement("BRANCH")]
        public string Branch { get; set; }

        [XmlElement("PATH")]
        public string Path { get; set; }

        [XmlElement("REPOSITORY")]
        public string Repository { get; set; }

        [XmlElement("REPNAME")]
        public string Repname { get; set; }

        [XmlElement("REPSERVER")]
        public string Repserver { get; set; }

        [XmlElement("HASH")]
        public string Hash { get; set; }
    }
}