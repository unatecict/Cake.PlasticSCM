using Cake.Core.Diagnostics;
using Cake.PlasticSCM.Checkin;

namespace Cake.PlasticSCM.Tests.Fixtures
{
    public class CheckinFixture : PlasticSCMFixtureWithData<PlasticSCMCheckinSettings, PlasticSCMCheckinResult>
    {

        public CheckinFixture(string resultFile)
        {   
            ProcessRunner.Process.SetStandardOutput(ReadResultFileAsList(resultFile));
        }

        #region Overrides of ToolFixture<PlasticSCMSwitchSettings,ToolFixtureResult>

        /// <inheritdoc />
        protected override void RunTool()
        {
            var tool = new PlasticSCMCheckinExecutor(FileSystem, Environment, ProcessRunner, Tools,  new NullLog());
            var result = tool.Checkin(Settings);
            Result.Data = result;
        }

        #endregion
    }   
}
