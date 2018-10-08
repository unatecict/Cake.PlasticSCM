using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.PlasticSCM
{
    public class PlasticSCMTool<TSettings> : Tool<TSettings>
        where TSettings : PlasticSCMSettings
    {
        protected ICakeLog Log { get; }
        private readonly string _command;

        /// <inheritdoc />
        protected PlasticSCMTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools, ICakeLog log, string command) : base(fileSystem, environment, processRunner, tools)
        {
            Log = log;
            _command = command;
        }

        #region Overrides of Tool<TSettings>

        /// <inheritdoc />
        protected override string GetToolName()
        {
            return "PlasticSCM Client";
        }

        /// <inheritdoc />
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] {"cm", "cm.exe"};
        }

        #endregion

        protected ProcessArgumentBuilder CreateArgumentBuilder(PlasticSCMSettings settings)
        {
            var builder = new ProcessArgumentBuilder();
            builder.Append(_command);
            return builder;
        }

        protected void PrintToStdout(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                Log.Information(line);
            }
        }
    }
}