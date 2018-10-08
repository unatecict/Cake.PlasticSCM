using System;
using System.Collections.Generic;

namespace Cake.PlasticSCM.Add
{
    internal class PlasticSCMAddParser
    {
        internal static string SEPARATOR_CHAR = "$$$";

        public static PlasticSCMAddResult Parse(IEnumerable<string> output)
        {
            PlasticSCMAddResult result = new PlasticSCMAddResult();
            string[] splitChars = new string[] { SEPARATOR_CHAR };

            foreach (string line in output)
            {
                string[] parts = line.Split(splitChars, 2, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 2)
                    continue;

                switch (parts[0].ToLower())
                {
                    case "ok":
                        result.Ok.Add(parts[1]);
                        break;
                    case "err":
                        result.Error.Add(parts[1]);
                        break;
                    default:
                        continue;
                }
            }

            return result;
        }
    }
}
