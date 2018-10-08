using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.PlasticSCM.Runners;

namespace Cake.PlasticSCM.Switch
{
    internal class PlasticSCMSwitchExecutor : StandardRunner<PlasticSCMSwitchSettings>
    {
        /// <inheritdoc />
        public PlasticSCMSwitchExecutor(IFileSystem fileSystem, ICakeEnvironment environment,
            IProcessRunner processRunner, IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools,
            "switch", log)
        {
        }

        public void Switch(PlasticSCMSwitchSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (settings.ObjectSpec == null)
                throw new ArgumentNullException(nameof(settings.ObjectSpec));

            var arguments = GetArguments(settings);
            Run(settings, arguments);
        }

        private ProcessArgumentBuilder GetArguments(PlasticSCMSwitchSettings settings)
        {
            ProcessArgumentBuilder builder = GetArguments(settings, null);

            builder.Append(settings.ObjectSpec);

            return builder;
        }
    }
}