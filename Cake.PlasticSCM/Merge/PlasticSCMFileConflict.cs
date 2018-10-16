namespace Cake.PlasticSCM.Merge
{
    public class PlasticSCMFileConflict    
    {
        public string Path { get; set; }
        public int BaseChangesetId { get; set; }
        public int SourceChangesetId { get; set; }
        public int DestinationChangesetId { get; set; }
        public int DestinationItemId { get; set; }

        public static PlasticSCMFileConflict FromStringValues(string path, string baseChangesetId, string sourceChangesetId,
            string destinationChangesetId, string destinationItemId)
        {
            PlasticSCMFileConflict result = new PlasticSCMFileConflict
            {
                Path = path,
                BaseChangesetId = int.Parse(baseChangesetId),
                SourceChangesetId = int.Parse(sourceChangesetId),
                DestinationChangesetId = int.Parse(destinationChangesetId),
                DestinationItemId = int.Parse(destinationItemId)
            };

            return result;
        }
    }
}
