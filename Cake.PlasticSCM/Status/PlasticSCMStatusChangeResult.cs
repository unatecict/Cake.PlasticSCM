namespace Cake.PlasticSCM.Status
{
    public class PlasticSCMStatusChangeResult
    {

        public string Path { get; set; }
        public string OldPath { get; set; }
        public PlasticSCMStatusChangeType Type { get; set; }
        public double SimilarityPerUnit { get; set; }
        public string MergesInfo { get; set; }
    }
}