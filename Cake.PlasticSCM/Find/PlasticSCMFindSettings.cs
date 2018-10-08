using System.Collections.Generic;
using Cake.PlasticSCM.Common;

namespace Cake.PlasticSCM.Find
{
    public class PlasticSCMFindSettings : PlasticSCMSettings
    {
        public PlasticSCMObjectTypes ObjectType { get; set; } = PlasticSCMObjectTypes.Changeset;
        public string WhereClause { get; set; }
        public IList<string> RepositorySpecs { get; }  = new List<string>();
    }
}