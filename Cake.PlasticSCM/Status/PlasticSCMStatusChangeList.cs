using System.Collections.Generic;

namespace Cake.PlasticSCM.Status
{
    public class PlasticSCMStatusChangeList
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<PlasticSCMStatusChangeResult> Changes { get; set; } = new List<PlasticSCMStatusChangeResult>();
    }
}
