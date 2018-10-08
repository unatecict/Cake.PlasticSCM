using System;
using System.Collections.Generic;

namespace Cake.PlasticSCM.Merge
{
    internal class PlasticSCMMergeParser
    {
        public static PlasticSCMMergeResult Parse(IEnumerable<string> output, string separator)
        {
            PlasticSCMMergeResult result = new PlasticSCMMergeResult();
            bool stopProcessing = false;

            string[] separatorArray = {separator};
            foreach (string line in output)
            {
          
                string[] parts = line.Split(separatorArray, StringSplitOptions.None);

                switch (parts[0])
                {
                    case "FILE_CONFLICT":
                    case "DIR_CONFLICT":
                        result.HasConflicts = true;
                        stopProcessing = true;
                        break;
                }

                if (stopProcessing)
                    break;
            }

            return result;
        }
    }
}
