using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.PlasticSCM.Runners
{
    internal abstract class FormattableRunner<TSettings> : PlasticSCMTool<TSettings> where TSettings : PlasticSCMSettings
    {
        protected IDictionary<string, string> FormatStrings { get; }

        /// <inheritdoc />  
        protected FormattableRunner(IFileSystem fileSystem, ICakeEnvironment environment,IProcessRunner processRunner, IToolLocator tools, string command, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log, command)
        {
            FormatStrings = new Dictionary<string, string>();
        }

        protected T Run<T>(TSettings settings, ProcessArgumentBuilder builder, Func<IEnumerable<string>,  T> processor)
        {
            T result = default(T);
            ProcessSettings ps = new ProcessSettings {RedirectStandardOutput = true }; 

            if (Log.Verbosity != Verbosity.Diagnostic)
                Log.Debug(Verbosity.Verbose,"Calling plastic with parameters: {0}", builder.RenderSafe());


            Run(settings, builder, ps, process =>
            {
                var stdout = process.GetStandardOutput().ToList();

                if (settings.ForcePrintingToLog && Log.Verbosity != Verbosity.Diagnostic)
                    PrintToStdout(stdout);

                result = ProcessResponse(process, stdout, processor);
            });
            return result;
        }

        private T ProcessResponse<T>(IProcess process, List<string> stdout,Func<IEnumerable<string>, T> processor)  
        {   
            process.WaitForExit();
            return processor(stdout);
        }

        protected ProcessArgumentBuilder GetArguments(TSettings settings, ProcessArgumentBuilder arguments = null)
        {
            var builder = CreateArgumentBuilder(settings);

            arguments?.CopyTo(builder);

            foreach (var formatString in FormatStrings)
            {
                builder.Append("--{0}=\"{1}\"", formatString.Key, formatString.Value);
            }

            return builder;
        }
    }
}