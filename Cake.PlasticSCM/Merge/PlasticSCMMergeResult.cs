using System.Collections.Generic;
using Cake.PlasticSCM.Common;

namespace Cake.PlasticSCM.Merge
{
    public class PlasticSCMMergeResult
    {
        public bool HasConflicts { get; set; }

        public IList<PlasticSCMDirConflict> DirectoryConflicts { get;  }
        public IList<PlasticSCMFileConflict> FileConflicts { get;  }

        /// <inheritdoc />  
        public PlasticSCMMergeResult()
        {
            DirectoryConflicts = new List<PlasticSCMDirConflict>();
            FileConflicts = new List<PlasticSCMFileConflict>();
        }
    }
}
