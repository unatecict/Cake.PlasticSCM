using Cake.Core.Diagnostics;
using Cake.PlasticSCM.Status;

namespace Cake.PlasticSCM.Tests.Fixtures
{
    public class StatusFixture : PlasticSCMFixtureWithData<PlasticSCMStatusSettings, PlasticSCMStatusResult>
    {

        /// <inheritdoc />
        public StatusFixture(string resultFile)
        {
            ProcessRunner.Process.SetStandardOutput(ReadResultFileAsList(resultFile));
        }

        #region Overrides of ToolFixture<PlasticSCMStatusSettings,ToolFixtureResult>



        /// <inheritdoc />
        protected override void RunTool()
        {
            var tool = new PlasticSCMStatusExecutor(FileSystem,Environment,ProcessRunner,Tools, new NullLog());
            var status = tool.GetStatus(Settings);
            Result.Data = status;
        }

        #endregion
    }
}
