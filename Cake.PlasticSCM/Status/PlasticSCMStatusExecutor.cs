using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.PlasticSCM.Runners;

namespace Cake.PlasticSCM.Status
{
    internal class PlasticSCMStatusExecutor : XmlResponseRunner<PlasticSCMStatusSettings> 
    {
        private static readonly IDictionary<PlasticSCMStatusFilters, string> FilterToArgumentMap =
            new Dictionary<PlasticSCMStatusFilters, string>()
            {
                {PlasticSCMStatusFilters.Added, "--added"},
                {PlasticSCMStatusFilters.CheckOut, "--checkout"},
                {PlasticSCMStatusFilters.Changed, "--changed"},
                {PlasticSCMStatusFilters.Copied, "--copied"},
                {PlasticSCMStatusFilters.Replaced, "--replaced"},
                {PlasticSCMStatusFilters.Deleted, "--deleted"},
                {PlasticSCMStatusFilters.LocalDeleted, "--localdeleted"},
                {PlasticSCMStatusFilters.Moved, "--moved"},
                {PlasticSCMStatusFilters.LocalMoved, "--localmoved"},
                {PlasticSCMStatusFilters.TextSameExtension, "--txtsameext"},
                {PlasticSCMStatusFilters.BinaryAnyExtension, "--binanyext"},
                {PlasticSCMStatusFilters.Private, "--private"},
                {PlasticSCMStatusFilters.Ignored, "--ignored"},
                {PlasticSCMStatusFilters.HiddenChanged, "--hiddenchanges"},
                {PlasticSCMStatusFilters.ControlledChanged, "--controlledchanged"},
                {PlasticSCMStatusFilters.All, "--all"}
            };

        /// <inheritdoc />
        public PlasticSCMStatusExecutor(IFileSystem fileSystem, ICakeEnvironment environment,
            IProcessRunner processRunner, IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log, "status")
        {
        }

        public PlasticSCMStatusResult GetStatus(PlasticSCMStatusSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            var arguments = GetArguments(settings);
            return Run(settings, arguments, PlasticSCMStatusParser.ParseXDocument);
        }

        private ProcessArgumentBuilder GetArguments(PlasticSCMStatusSettings settings)
        {
            var builder = GetArguments(settings, null);

            foreach (var filterType in Enum.GetValues(typeof(PlasticSCMStatusFilters)).Cast<Enum>()
                .Where(settings.Filters.HasFlag).Cast<PlasticSCMStatusFilters>())
            {
                builder.Append(FilterToArgumentMap[filterType]);
            }

            foreach (var changelist in settings.LimitToChangelists)
            {
                builder.Append("--changelist={0}", changelist);
            }

            if (settings.PercentOfSimilarity != null)
                builder.Append("{0}={1}", "--percentofsimilarity", settings.PercentOfSimilarity);

            if (settings.GetChangelists)
                builder.Append("--changelists");

            return builder;
        }
    }
}