using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.PlasticSCM.Runners;

namespace Cake.PlasticSCM.Merge
{
    internal class PlasticSCMMergeExecutor : MachineReadableRunner<PlasticSCMMergeSettings>
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
        public PlasticSCMMergeExecutor(IFileSystem fileSystem, ICakeEnvironment environment,
            IProcessRunner processRunner, IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools,
            "merge", log)
        {
        }

        public PlasticSCMMergeResult Merge(PlasticSCMMergeSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            var arguments = GetArguments(settings);
            return Run(settings, arguments, PlasticSCMMergeParser.Parse);
        }

        private ProcessArgumentBuilder GetArguments(PlasticSCMMergeSettings settings)
        {
            ProcessArgumentBuilder builder = GetArguments(settings, null);

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (string.IsNullOrWhiteSpace(settings.SourceObjectSpec))
                throw new ArgumentException(nameof(settings.SourceObjectSpec));

            builder.Append(settings.SourceObjectSpec);
            builder.Append("--nointeractiveresolution");

            if (!string.IsNullOrWhiteSpace(settings.DestinationObjectSpec))
                builder.Append("--to={0}", settings.DestinationObjectSpec);

            if (settings.Shelve)
                builder.Append("--shelve");

            if (settings.CherryPick)
                builder.Append("--cherrypicking");

            if (settings.Subtractive)
                builder.Append("--subtractive");

            if (!string.IsNullOrWhiteSpace(settings.IntervalChangesetSpec))
                builder.Append("--interval-origin={0}", settings.IntervalChangesetSpec);

            if (settings.KeepSource)
                builder.Append("--ks");

            if (settings.KeepDestination)
                builder.Append("--kd");

            if (settings.MergeType != null)
                builder.Append("--mergetype={0}", TypeToArgumentMap[settings.MergeType.Value]);

            if (settings.ComparisonMethod != null)
                builder.Append("--comparisonmethod={0}",
                    ComparisonMethodToArgumentMap[settings.ComparisonMethod.Value]);

            if (!settings.TryMerge)
                builder.Append("--merge");

            if (settings.NoDestinationChanges)
                builder.Append("--no-dst-changes");

            if (!string.IsNullOrWhiteSpace(settings.Comment))
                builder.Append("-c=\"{0}\"", settings.Comment);


            return builder;
        }
    }
}