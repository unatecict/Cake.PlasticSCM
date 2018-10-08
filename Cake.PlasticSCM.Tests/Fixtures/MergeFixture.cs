using Cake.Core.Diagnostics;
using Cake.PlasticSCM.Merge;

namespace Cake.PlasticSCM.Tests.Fixtures
{
    public class MergeFixture : PlasticSCMFixtureWithData<PlasticSCMMergeSettings, PlasticSCMMergeResult>
    {

        public MergeFixture(string resultFile)
        {   
            ProcessRunner.Process.SetStandardOutput(ReadResultFileAsList(resultFile));
        }

        #region Overrides of ToolFixture<PlasticSCMSwitchSettings,ToolFixtureResult>

        /// <inheritdoc />
        protected override void RunTool()
        {
            var tool = new PlasticSCMMergeExecutor(FileSystem, Environment, ProcessRunner, Tools, new NullLog());
            var result = tool.Merge(Settings);
            Result.Data = result;
        }

        #endregion
    }
}
