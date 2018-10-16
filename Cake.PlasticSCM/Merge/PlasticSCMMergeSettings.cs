using EnsureThat;

namespace Cake.PlasticSCM.Merge
{
    public partial class PlasticSCMMergeSettings : PlasticSCMSettings
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
        public string Path { get; set; }
        public PlasticSCMMergeSession Session { get; set; }
        public bool ResolveConflict { get; set; }
        public int ConflictIndex { get; set; }
        public PlasticSCMMergeResolutionOptions ResolutionOptions { get; set; }
        public string ResolutionInfo { get; set; }

        public static PlasticSCMMergeSettings BasicDryRun(string sourceObjectSpec, string itemPath = null, PlasticSCMMergeSession session = null)
        {
            Ensure.String.IsNotNullOrWhiteSpace(sourceObjectSpec, nameof(sourceObjectSpec));

            PlasticSCMMergeSettings result = new PlasticSCMMergeSettings
            {
                TryMerge = true,
                SourceObjectSpec = sourceObjectSpec,
                Session = session,
                Path = itemPath
            };

            return result;
        }

        public static PlasticSCMMergeSettings BasicRun(string sourceObjectSpec, PlasticSCMMergeSession session = null)
        {
            Ensure.String.IsNotNullOrWhiteSpace(sourceObjectSpec, nameof(sourceObjectSpec));

            PlasticSCMMergeSettings result = new PlasticSCMMergeSettings
            {
                TryMerge = false,
                SourceObjectSpec = sourceObjectSpec,
                Session = session
            };

            return result;
        }
            
        public static PlasticSCMMergeSettings BasicDirectoryConflictResolution(string sourceObjectSpec, PlasticSCMMergeSession session, int conflictIndex, PlasticSCMMergeResolutionOptions resolution,
            string resolutionInfo = null)
        {
            Ensure.String.IsNotNullOrWhiteSpace(sourceObjectSpec, nameof(sourceObjectSpec));
            if (resolution == PlasticSCMMergeResolutionOptions.Rename)
                Ensure.String.IsNotNullOrWhiteSpace(resolutionInfo, nameof(resolutionInfo));

            Ensure.Any.IsNotNull(session, nameof(session));

            PlasticSCMMergeSettings result = new PlasticSCMMergeSettings
            {
                TryMerge = false,
                SourceObjectSpec = sourceObjectSpec,
                ResolveConflict = true,
                ResolutionOptions = resolution,
                ConflictIndex = conflictIndex,
                ResolutionInfo = resolutionInfo,
                Session =  session
            };

            return result;
        }
    }


}
