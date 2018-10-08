using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.PlasticSCM.Merge;
using Cake.PlasticSCM.Runners;

namespace Cake.PlasticSCM.Checkin
{
    internal class PlasticSCMCheckinExecutor : MachineReadableRunner<PlasticSCMCheckinSettings>
    {
        private static readonly IDictionary<PlasticSCMMergeType, string> TypeToArgumentMap =
            new Dictionary<PlasticSCMMergeType, string>()
            {
                {PlasticSCMMergeType.OnlyDst, "onlydst"},
                {PlasticSCMMergeType.OnlyOne, "onlyone"},
                {PlasticSCMMergeType.OnlySrc, "onlysrc"},
                {PlasticSCMMergeType.Try, "try"}
            };

        private static readonly IDictionary<PlasticSCMMergeComparisonMethod, string> ComparisonMethodToArgumentMap =
            new Dictionary<PlasticSCMMergeComparisonMethod, string>()
            {
                {PlasticSCMMergeComparisonMethod.IgnoreEol, "IgnoreEol"},
                {PlasticSCMMergeComparisonMethod.IgnoreEolWhitespaces, "IgnoreEolWhitespaces"},
                {PlasticSCMMergeComparisonMethod.IgnoreWhitespaces, "IgnoreWhitespaces"},
                {PlasticSCMMergeComparisonMethod.NotIgnore, "NotIgnore"},
            };

        /// <inheritdoc />
        public PlasticSCMCheckinExecutor(IFileSystem fileSystem, ICakeEnvironment environment,
            IProcessRunner processRunner, IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools,
            "ci", log)
        {
        }

        public PlasticSCMCheckinResult Checkin(PlasticSCMCheckinSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            var arguments = GetArguments(settings);
            return Run(settings, arguments, PlasticSCMCheckinParser.Parse);
        }

        private ProcessArgumentBuilder GetArguments(PlasticSCMCheckinSettings settings)
        {
            ProcessArgumentBuilder builder = GetArguments(settings, null);

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            foreach (var path in settings.Paths)
            {
                builder.Append(path);
            }

            if (settings.All)
                builder.Append("--all");

            if (settings.Dependencies)
                builder.Append("--dependencies");

            if (settings.Symlink)
                builder.Append("--symlink");

            if (settings.NoCheck)
                builder.Append("--nchk");

            if (!string.IsNullOrWhiteSpace(settings.Comment))
                builder.Append("-c=\"{0}\"", settings.Comment);

            return builder;
        }
    }
}