using Cake.Core.Diagnostics;
using Cake.PlasticSCM.Switch;

namespace Cake.PlasticSCM.Tests.Fixtures
{
    public class SwitchFixture : PlasticSCMFixture<PlasticSCMSwitchSettings>
    {
        #region Overrides of ToolFixture<PlasticSCMSwitchSettings,ToolFixtureResult>

        /// <inheritdoc />
        protected override void RunTool()
        {
            var executor = new PlasticSCMSwitchExecutor(FileSystem,Environment,ProcessRunner,Tools, new NullLog());
            executor.Switch(Settings);
        }

        #endregion
    }
}
