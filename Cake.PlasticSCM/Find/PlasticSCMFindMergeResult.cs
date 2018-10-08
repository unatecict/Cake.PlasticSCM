using System;
using System.Xml.Serialization;

namespace Cake.PlasticSCM.Find
{
    [XmlRoot("MERGE")]
    public class PlasticSCMFindMergeResult
    {
        [XmlElement("ID")]
        public int Id { get; set; }

        [XmlElement("NAME")]
        public string Name { get; set; }

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

        [XmlElement("SRCCHANGESET")]
        public int SrcChangeset { get; set; }

        [XmlElement("SRCBRANCH")]
        public string SrcBranch { get; set; }

        [XmlElement("DSTID")]
        public int DstId { get; set; }

        [XmlElement("DSTCOMMENT")]
        public string DstComment { get; set; }

        [XmlElement("DSTDATE")]
        public DateTime DstDate { get; set; }

        [XmlElement("DSTOWNER")]
        public string DstOwner { get; set; }

        [XmlElement("DSTCHANGESET")]
        public int DstChangeset { get; set; }

        [XmlElement("DSTBRANCH")]
        public string DstBranch { get; set; }

        [XmlElement("BASEID")]
        public int BaseId { get; set; }

        [XmlElement("BASECOMMENT")]
        public string BaseComment { get; set; }

        [XmlElement("BASEDATE")]
        public DateTime BaseDate { get; set; }

        [XmlElement("BASEOWNER")]
        public string BaseOwner { get; set; }

        [XmlElement("BASECHANGESET")]
        public int BaseChangeset { get; set; }

        [XmlElement("BASEBRANCH")]
        public string BaseBranch { get; set; }

        [XmlElement("SRC")]
        public string Src { get; set; }

        [XmlElement("DST")]
        public string Dst { get; set; }
    }
}