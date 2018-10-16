using System;
using System.Collections.Generic;

namespace Cake.PlasticSCM.Merge
{
    internal class PlasticSCMMergeParser
    {
        public static PlasticSCMMergeResult Parse(IEnumerable<string> output, string separator)
        {
            PlasticSCMMergeResult result = new PlasticSCMMergeResult();

            string[] separatorArray = {separator};
            foreach (string line in output)
            {
          
                string[] parts = line.Split(separatorArray, StringSplitOptions.None);

                switch (parts[0])
                {
                    case "FILE_CONFLICT":
                        result.FileConflicts.Add(PlasticSCMFileConflict.FromStringValues(parts[1], parts[2], parts[3], parts[4], parts[5]));
                        result.HasConflicts = true;
                        break;
                    case "DIR_CONFLICT":
                        result.DirectoryConflicts.Add(PlasticSCMDirConflict.FromStringValues(parts[1], parts[2], parts[3], parts[4], parts[5],
                            parts[6], parts[7], parts[8], parts[9], parts[10], parts[11]));
                        result.HasConflicts = true;
                        break;
                }
            }

            return result;
        }
    }
}
