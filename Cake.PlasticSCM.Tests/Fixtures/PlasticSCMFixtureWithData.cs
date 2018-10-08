using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.PlasticSCM.Tests.Fixtures
{
    public abstract class
        PlasticSCMFixtureWithData<TSettings, TData> : PlasticSCMFixtureBase<TSettings, ToolFixtureResultWithData<TData>>
        where TSettings : ToolSettings, new()
    {

        protected ToolFixtureResultWithData<TData> Result { get; private set; }
        /// <inheritdoc />

        #region Overrides of ToolFixture<TSettings,ToolFixtureResult>

        /// <inheritdoc />
        protected override ToolFixtureResultWithData<TData> CreateResult(FilePath path, ProcessSettings process)
        {
            Result = new ToolFixtureResultWithData<TData>(path, process);
            return Result;
        }

        #endregion
    }
}