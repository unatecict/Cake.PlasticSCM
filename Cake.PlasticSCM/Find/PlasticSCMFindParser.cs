using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace Cake.PlasticSCM.Find
{
    internal class PlasticSCMFindParser
    {   
        internal static PlasticSCMFindResult ParseXDocument(XDocument doc, PlasticSCMFindSettings settings)    
        {
            PlasticSCMFindResult result = new PlasticSCMFindResult();

            switch (settings.ObjectType)
            {
                case Common.PlasticSCMObjectTypes.Branch:
                    ParseBranches(doc, result);
                    break;
                case Common.PlasticSCMObjectTypes.Changeset:
                    ParseChangesets(doc, result);
                    break;
                case Common.PlasticSCMObjectTypes.Label:
                    ParseLabels(doc, result);
                    break;
                case Common.PlasticSCMObjectTypes.Attribute:
                    ParseAttributes(doc, result);
                    break;
                case Common.PlasticSCMObjectTypes.Revision:
                    ParseRevisions(doc, result);
                    break;
                case Common.PlasticSCMObjectTypes.Merge:
                    ParseMerges(doc, result);
                    break;
                case Common.PlasticSCMObjectTypes.Review:
                    ParseReviews(doc, result);
                    break;
            }

            return result;
        }

        private static void ParseChangesets(XDocument doc, PlasticSCMFindResult result)
        {
            var changesetNodes = doc.XPathSelectElements("PLASTICQUERY/CHANGESET");
            DeserializeItems(result.Changesets, changesetNodes);
        }

        private static void ParseBranches(XDocument doc, PlasticSCMFindResult result)
        {
            var branchNodes = doc.XPathSelectElements("PLASTICQUERY/BRANCH");
            DeserializeItems(result.Branches, branchNodes);
        }

        private static void ParseLabels(XDocument doc, PlasticSCMFindResult result)
        {
            var labelNodes = doc.XPathSelectElements("PLASTICQUERY/MARKER");
            DeserializeItems(result.Labels, labelNodes);
        }

        private static void ParseRevisions(XDocument doc, PlasticSCMFindResult result)  
        {
            var revisionNodes = doc.XPathSelectElements("PLASTICQUERY/REVISION");
            DeserializeItems(result.Revisions, revisionNodes);  
        }

        private static void ParseMerges(XDocument doc, PlasticSCMFindResult result)
        {
            var mergeNodes = doc.XPathSelectElements("PLASTICQUERY/MERGE");
            DeserializeItems(result.Merges, mergeNodes);
        }

        private static void ParseAttributes(XDocument doc, PlasticSCMFindResult result)
        {
            var attributeNodes = doc.XPathSelectElements("PLASTICQUERY/ATTRIBUTE");
            DeserializeItems(result.Attributes, attributeNodes);
        }
            
        private static void ParseReviews(XDocument doc, PlasticSCMFindResult result)
        {
            var reviewNodes = doc.XPathSelectElements("PLASTICQUERY/REVIEW");
            DeserializeItems(result.Reviews, reviewNodes);
        }

        private static void DeserializeItems<T>(IList<T> list, IEnumerable<XElement> changesetNodes)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            foreach (var element in changesetNodes)
            {
                using (var rd = element.CreateReader())
                {
                    list.Add((T) ser.Deserialize(rd));
                }
            }
        }
    }
}