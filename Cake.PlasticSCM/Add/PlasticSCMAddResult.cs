using System.Collections.Generic;

namespace Cake.PlasticSCM.Add
{
    public class PlasticSCMAddResult
    {
        public IList<string> Ok { get; }
        public IList<string> Error { get;  }

        /// <inheritdoc />
        public PlasticSCMAddResult()
        {
            Ok = new List<string>();
            Error = new List<string>();
        }
    }
}
