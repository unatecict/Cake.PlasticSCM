using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Cake.PlasticSCM.Status
{
    internal class PlasticSCMStatusParser
    {
        private static readonly IDictionary<string, PlasticSCMStatusChangeType> ChangeTypeMap =
            new Dictionary<string, PlasticSCMStatusChangeType>()
            {
                {"PR", PlasticSCMStatusChangeType.Private},
                {"AD", PlasticSCMStatusChangeType.Added},
                {"LD", PlasticSCMStatusChangeType.LocalDeleted},
                {"LM", PlasticSCMStatusChangeType.LocalMoved},
                {"CH", PlasticSCMStatusChangeType.Changed},
                {"CO", PlasticSCMStatusChangeType.CheckOut},
                {"IG", PlasticSCMStatusChangeType.Ignored},
                {"RP", PlasticSCMStatusChangeType.Replaced},
                {"CP", PlasticSCMStatusChangeType.Copied},
                {"MV", PlasticSCMStatusChangeType.Moved},
                {"DE", PlasticSCMStatusChangeType.Deleted},
            };

        internal static PlasticSCMStatusResult ParseXDocument(XDocument doc)
        {
            PlasticSCMStatusResult result = new PlasticSCMStatusResult();

            var statusNode = doc.XPathSelectElement("StatusOutput/WorkspaceStatus/Status");
            foreach (var element in statusNode.Elements())
            {
                if (element.Name == "RepSpec")
                {
                    result.RepositoryServerName = element.Element("Server").Value;
                    result.RepositoryName = element.Element("Name").Value;
                }
                else if (element.Name == "Changeset")
                {
                    result.Changeset = Convert.ToInt32(element.Value);
                }
            }

            var changesNodes = doc.XPathSelectElements("StatusOutput/Changes/Change");
            ParseChanges(changesNodes, result.Changes);

            var changeListNodes = doc.XPathSelectElements("StatusOutput/Changelists/Changelist");
            ParseChangeLists(changeListNodes, result.ChangeLists);

            return result;
        }

        private static void ParseChangeLists(IEnumerable<XElement> changeListNodes,
            IList<PlasticSCMStatusChangeList> resultChangeLists)
        {
            foreach (var node in changeListNodes)
            {
                PlasticSCMStatusChangeList changeList = new PlasticSCMStatusChangeList();
                
                foreach (var changeListNode in node.Elements())
                {
                    switch (changeListNode.Name.LocalName)
                    {
                        case "Name":
                            changeList.Name = changeListNode.Value;
                            break;
                        case "Description":
                            changeList.Description = changeListNode.Value;
                            break;
                        case "Changes":
                            ParseChanges(changeListNode.Elements("Change"), changeList.Changes);
                            break;
                    }
                }

                resultChangeLists.Add(changeList);
            }
        }

        private static void ParseChanges(IEnumerable<XElement> nodes, IList<PlasticSCMStatusChangeResult> list)
        {
            foreach (var changeNode in nodes)
            {
                PlasticSCMStatusChangeResult change = new PlasticSCMStatusChangeResult();
                foreach (var element in changeNode.Elements())
                {
                    switch (element.Name.LocalName)
                    {
                        case "Type":
                            change.Type = ChangeTypeMap[element.Value];
                            break;
                        case "Path":
                            change.Path = element.Value;
                            break;
                        case "OldPath":
                            change.OldPath = element.Value;
                            break;
                        case "SimilarityPerUnit":
                            change.SimilarityPerUnit = Convert.ToDouble(element.Value, CultureInfo.InvariantCulture);
                            break;
                        case "MergesInfo":
                            change.MergesInfo = element.Value;
                            break;
                    }
                }

                list.Add(change);
            }
        }
    }
}