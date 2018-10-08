using System.Collections.Generic;

namespace Cake.PlasticSCM.Find
{
    public class PlasticSCMFindResult
    {   
        public IList<PlasticSCMFindChangesetResult> Changesets { get; } = new List<PlasticSCMFindChangesetResult>();
        public IList<PlasticSCMFindBranchResult> Branches { get; } = new List<PlasticSCMFindBranchResult>();    
        public IList<PlasticSCMFindLabelResult> Labels { get; } = new List<PlasticSCMFindLabelResult>();
        public IList<PlasticSCMFindRevisionResult> Revisions { get; } = new List<PlasticSCMFindRevisionResult>();
        public IList<PlasticSCMFindAttributeResult> Attributes { get; } = new List<PlasticSCMFindAttributeResult>();
        public IList<PlasticSCMFindMergeResult> Merges { get; } = new List<PlasticSCMFindMergeResult>();
        public IList<PlasticSCMFindReviewResult> Reviews { get; } = new List<PlasticSCMFindReviewResult>();
    }
}
