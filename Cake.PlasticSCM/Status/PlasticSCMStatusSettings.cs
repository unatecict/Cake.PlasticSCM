using System.Collections.Generic;

namespace Cake.PlasticSCM.Status
{
    public class PlasticSCMStatusSettings : PlasticSCMSettings
    {
        public PlasticSCMStatusFilters Filters { get; set; } = PlasticSCMStatusFilters.All;

        public int? PercentOfSimilarity { get; set; }
        public bool GetChangelists { get; set; }
        public IList<string> LimitToChangelists { get; private set; } = new List<string>();

        public static readonly PlasticSCMStatusSettings Instance = new PlasticSCMStatusSettings();
        
    }
}
