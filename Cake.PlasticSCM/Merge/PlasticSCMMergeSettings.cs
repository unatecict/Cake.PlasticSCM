namespace Cake.PlasticSCM.Merge
{   
    public class PlasticSCMMergeSettings : PlasticSCMSettings
    {
        public string SourceObjectSpec { get; set; }
        public string Comment { get; set; } 
        public string DestinationObjectSpec { get; set; }   
        public bool TryMerge { get; set; }
        public bool CherryPick { get; set; }
        public bool Subtractive { get; set; }
        public bool Shelve { get; set; }
        public bool KeepSource { get; set; }    
        public bool KeepDestination { get; set; }
        public string IntervalChangesetSpec { get; set; }   
        public bool NoDestinationChanges { get; set; }
        public PlasticSCMMergeType? MergeType { get; set; }
        public PlasticSCMMergeComparisonMethod? ComparisonMethod { get; set; }
    }
}   
