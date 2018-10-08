using System.Collections.Generic;

namespace Cake.PlasticSCM.Add
{   
    public class PlasticSCMAddSettings : PlasticSCMSettings
    {   
        public bool Recursive { get; set; }
        public IList<string> Paths { get; }
        public bool IncludeParents { get; set; }
        public bool SkipContentCheck { get; set; }
        public bool CheckoutParent { get; set; }
        public string FileTypesFilePath { get; set; }   
        public bool IgnoreFailed { get; set; }

        /// <inheritdoc />
        public PlasticSCMAddSettings()
        {
            Paths = new List<string>();
        }
    }
}   
