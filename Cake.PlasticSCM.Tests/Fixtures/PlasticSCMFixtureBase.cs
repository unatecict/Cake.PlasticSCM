using System.Collections.Generic;
using System.IO;
using Cake.Core.Tooling;
using Cake.Testing.Fixtures;

namespace Cake.PlasticSCM.Tests.Fixtures
{
    public abstract class PlasticSCMFixtureBase<TSettings, TResult> : ToolFixture<TSettings, TResult>
        where TSettings : ToolSettings, new()
        where TResult : ToolFixtureResult
    {
        /// <inheritdoc />  
        protected PlasticSCMFixtureBase() : base("cm.exe")
        {
        }

        protected IList<string> ReadResultFileAsList(string filename)
        {
            using (var sr = new StreamReader(GetType().Assembly.GetManifestResourceStream($"Cake.PlasticSCM.Tests.ResultFiles.{filename}")))
            {
                List<string> result = new List<string>();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    result.Add(line);
                }

                return result;
            }
        }
    }
}