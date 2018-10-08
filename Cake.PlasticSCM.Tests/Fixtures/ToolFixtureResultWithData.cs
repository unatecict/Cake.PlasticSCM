using Cake.Core.IO;
using Cake.Testing.Fixtures;

namespace Cake.PlasticSCM.Tests.Fixtures
{
    public class ToolFixtureResultWithData<TData> : ToolFixtureResult
    {
        public TData Data { get; set; }

        /// <inheritdoc />
        public ToolFixtureResultWithData(FilePath path, ProcessSettings process) : base(path, process)
        {
        }
    }
}
