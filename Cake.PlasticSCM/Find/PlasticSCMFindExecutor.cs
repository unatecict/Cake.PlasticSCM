using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.PlasticSCM.Common;
using Cake.PlasticSCM.Runners;

namespace Cake.PlasticSCM.Find
{
    internal class PlasticSCMFindExecutor : XmlResponseRunner<PlasticSCMFindSettings>
    {

        private static readonly IDictionary<PlasticSCMObjectTypes, string> ObjectTypeToArgumentMap =
            new Dictionary<PlasticSCMObjectTypes, string>()
            {
                {PlasticSCMObjectTypes.Attribute, "attribute"},
                {PlasticSCMObjectTypes.Merge, "merge"},
                {PlasticSCMObjectTypes.Branch, "branch"},
                {PlasticSCMObjectTypes.Changeset, "changeset"},
                {PlasticSCMObjectTypes.Review, "review"},
                {PlasticSCMObjectTypes.Label, "label"},
                {PlasticSCMObjectTypes.ReplicationLog, "replicationlog"},
                {PlasticSCMObjectTypes.Revision, "revision"}
            };

        /// <inheritdoc />
        public PlasticSCMFindExecutor(IFileSystem fileSystem, ICakeEnvironment environment,
            IProcessRunner processRunner, IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log, "find")
        {
        }

        public PlasticSCMFindResult Find(PlasticSCMFindSettings settings)
        {
            if (settings == null)   
                throw new ArgumentNullException(nameof(settings));

            if (settings.ObjectType == PlasticSCMObjectTypes.ReplicationLog)
                throw new NotSupportedException("ReplicationLog type not supported yet");

            var arguments = GetArguments(settings);
            return Run(settings, arguments, doc => PlasticSCMFindParser.ParseXDocument(doc, settings));
        }

        private ProcessArgumentBuilder GetArguments(PlasticSCMFindSettings settings)
        {
            var builder = GetArguments(settings, null);

            builder.Append(ObjectTypeToArgumentMap[settings.ObjectType]);

            if (!string.IsNullOrWhiteSpace(settings.WhereClause))
                builder.Append("where {0}", settings.WhereClause);

            if (settings.RepositorySpecs.Any())
            {
                string repos = string.Join(",", settings.RepositorySpecs);
                builder.Append("on repositories {0}", repos);
            }

            builder.Append("--dateformat=s");

            return builder;
        }
    }
}