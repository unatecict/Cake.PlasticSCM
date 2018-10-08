using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.PlasticSCM.Runners
{
    internal abstract class XmlResponseRunner<TSettings> : PlasticSCMTool<TSettings> where TSettings : PlasticSCMSettings
    {
        /// <inheritdoc />
        protected XmlResponseRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools, ICakeLog log, string command) : base(fileSystem, environment, processRunner, tools, log,  command)
        {
        }

        protected T Run<T>(TSettings settings, ProcessArgumentBuilder builder, Func<XDocument,T> deserializer)
        {
            T result = default(T);
            ProcessSettings ps = new ProcessSettings {RedirectStandardOutput = true, };

            if (Log.Verbosity != Verbosity.Diagnostic)
                Log.Debug(Verbosity.Verbose,"Calling plastic with parameters: {0}", builder.RenderSafe());
            Run(settings, builder, ps, (process) =>
            {
                var stdout = process.GetStandardOutput().ToList();

                if (settings.ForcePrintingToLog && Log.Verbosity != Verbosity.Diagnostic)
                    PrintToStdout(stdout);
                result = DeserializeXmlResponse(process,stdout, deserializer);
            });

            return result;
        }

        private T DeserializeXmlResponse<T>(IProcess process, IEnumerable<string> stdout,
            Func<XDocument, T> deserializer)
        {
            process.WaitForExit();

            XDocument doc = XDocument.Parse(string.Join("\r\n", stdout));
            return deserializer(doc);
        }

        protected ProcessArgumentBuilder GetArguments(TSettings settings, ProcessArgumentBuilder arguments =  null)
        {
            var builder = CreateArgumentBuilder(settings);

            arguments?.CopyTo(builder);
            builder.Append("--xml");

            return builder;
        }
    }
}