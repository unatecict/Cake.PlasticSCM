using System;
using System.Collections.Generic;

namespace Cake.PlasticSCM.Checkin
{
    internal class PlasticSCMCheckinParser
    {
        public static PlasticSCMCheckinResult Parse(IEnumerable<string> output, string separator)
        {
            PlasticSCMCheckinResult result = new PlasticSCMCheckinResult();
            bool stopProcessing = false;

            string[] separatorArray = {separator};
            foreach (string line in output)
            {
                string[] parts = line.Split(separatorArray, StringSplitOptions.None);

                switch (parts[0])
                {
                    case "MERGE_NEEDED":
                        result.MergeNeeded = true;
                        break;
                    case "CHANGESET":
                        result.Commited = true;
                        break;
                }

                if (stopProcessing)
                    break;
            }

            return result;
        }
    }
}
