using Cake.Core.Diagnostics;
using Cake.PlasticSCM.Find;

namespace Cake.PlasticSCM.Tests.Fixtures
{
    public class FindFixture : PlasticSCMFixtureWithData<PlasticSCMFindSettings, PlasticSCMFindResult>
    {

        /// <inheritdoc />
        public FindFixture(string resultFile)
        {
            ProcessRunner.Process.SetStandardOutput(ReadResultFileAsList(resultFile));
        }

        #region Overrides of ToolFixture<PlasticSCMStatusSettings,ToolFixtureResult>



        /// <inheritdoc />
        protected override void RunTool()
        {
            var tool = new PlasticSCMFindExecutor(FileSystem,Environment,ProcessRunner,Tools, new NullLog());
            var status = tool.Find(Settings);
            Result.Data = status;
        }

        #endregion
    }
}
