using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.PlasticSCM.Runners
{
    internal abstract class StandardRunner<TSettings> : PlasticSCMTool<TSettings> where TSettings : PlasticSCMSettings
    {
        /// <inheritdoc />  
        protected StandardRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools, string command, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log, command)
        {
        }


        public new void Run(TSettings settings, ProcessArgumentBuilder arguments)   
        {
            ProcessSettings ps = new ProcessSettings { RedirectStandardOutput = true };
            if (Log.Verbosity != Verbosity.Diagnostic)
                Log.Debug(Verbosity.Verbose,"Calling plastic with parameters: {0}", arguments.RenderSafe());

            base.Run(settings,arguments,ps, process =>
            {
                if (settings.ForcePrintingToLog && Log.Verbosity != Verbosity.Diagnostic)
                    PrintToStdout(process.GetStandardOutput());
            });
        }

        protected ProcessArgumentBuilder GetArguments(TSettings settings, ProcessArgumentBuilder arguments = null)
        {
            return CreateArgumentBuilder(settings);
        }
    }
}