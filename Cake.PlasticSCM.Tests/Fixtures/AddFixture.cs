using Cake.Core.Diagnostics;
using Cake.PlasticSCM.Add;

namespace Cake.PlasticSCM.Tests.Fixtures
{
    public class AddFixture : PlasticSCMFixtureWithData<PlasticSCMAddSettings, PlasticSCMAddResult>
    {

        public AddFixture(string resultFile)
        {   
            ProcessRunner.Process.SetStandardOutput(ReadResultFileAsList(resultFile));
        }

        #region Overrides of ToolFixture<PlasticSCMSwitchSettings,ToolFixtureResult>

        /// <inheritdoc />
        protected override void RunTool()
        {
            var tool = new PlasticSCMAddExecutor(FileSystem, Environment, ProcessRunner, Tools,  new NullLog());
            var result = tool.Add(Settings);
            Result.Data = result;
        }

        #endregion
    }   
}
