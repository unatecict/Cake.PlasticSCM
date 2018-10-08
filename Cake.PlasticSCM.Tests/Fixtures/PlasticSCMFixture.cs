using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing.Fixtures;

namespace Cake.PlasticSCM.Tests.Fixtures
{
    public abstract class PlasticSCMFixture<TSettings> : PlasticSCMFixtureBase<TSettings, ToolFixtureResult> where TSettings : ToolSettings, new()
    {
        #region Overrides of ToolFixture<TSettings,ToolFixtureResult>

        /// <inheritdoc />
        protected override ToolFixtureResult CreateResult(FilePath path, ProcessSettings process)
        {
            return new ToolFixtureResult(path, process);
        }
        #endregion
    }
}
