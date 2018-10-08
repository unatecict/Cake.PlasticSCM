using System.Collections.Generic;

namespace Cake.PlasticSCM.Status
{
    public partial class PlasticSCMStatusResult
    {
        public int Changeset { get; set; }
        public string RepositoryName { get; set; }
        public string RepositoryServerName { get; set; }
        public IList<PlasticSCMStatusChangeResult> Changes { get; set; } = new List<PlasticSCMStatusChangeResult>();
        public IList<PlasticSCMStatusChangeList> ChangeLists { get; set; } = new List<PlasticSCMStatusChangeList>();
    }
}