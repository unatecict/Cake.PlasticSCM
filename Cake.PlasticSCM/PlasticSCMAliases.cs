using System.Runtime.CompilerServices;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.PlasticSCM.Add;
using Cake.PlasticSCM.Checkin;
using Cake.PlasticSCM.Find;
using Cake.PlasticSCM.Merge;
using Cake.PlasticSCM.Status;
using Cake.PlasticSCM.Switch;

[assembly:InternalsVisibleTo("Cake.PlasticSCM.Tests")]

namespace Cake.PlasticSCM
{
    [CakeAliasCategory("PlasticSCM")]
    [CakeNamespaceImport("Cake.PlasticSCM.Common")]
    public static class PlasticSCMAliases
    {
        [CakeMethodAlias]
        [CakeAliasCategory("Status")]
        [CakeNamespaceImport("Cake.PlasticSCM.Status")]
        public static PlasticSCMStatusResult PlasticSCMStatus(this ICakeContext ctx, PlasticSCMStatusSettings settings = null)
        {
            if (settings == null)
                settings = PlasticSCMStatusSettings.Instance;

            return new PlasticSCMStatusExecutor(ctx.FileSystem, ctx.Environment, ctx.ProcessRunner, ctx.Tools, ctx.Log)
                .GetStatus(settings);
        }

        [CakeMethodAlias]
        [CakeAliasCategory("Status")]
        [CakeNamespaceImport("Cake.PlasticSCM.Switch")]
        public static void PlasticSCMSwitch(this ICakeContext ctx, PlasticSCMSwitchSettings settings)
        {
           new PlasticSCMSwitchExecutor(ctx.FileSystem, ctx.Environment, ctx.ProcessRunner, ctx.Tools, ctx.Log)
                .Switch(settings);
        }

        [CakeMethodAlias]
        [CakeAliasCategory("Switch")]
        [CakeNamespaceImport("Cake.PlasticSCM.Switch")]
        public static void PlasticSCMSwitch(this ICakeContext ctx, string objectSpec)
        {
            PlasticSCMSwitch(ctx, new PlasticSCMSwitchSettings()
            {
                ObjectSpec = objectSpec
            });
        }

        [CakeMethodAlias]
        [CakeAliasCategory("Merge")]
        [CakeNamespaceImport("Cake.PlasticSCM.Merge")]
        public static PlasticSCMMergeResult PlasticSCMMerge(this ICakeContext ctx, PlasticSCMMergeSettings settings)
        {
            return new PlasticSCMMergeExecutor(ctx.FileSystem, ctx.Environment, ctx.ProcessRunner, ctx.Tools, ctx.Log )
                .Merge(settings);
        }

        [CakeMethodAlias]   
        [CakeAliasCategory("Checkin")]
        [CakeNamespaceImport("Cake.PlasticSCM.Checkin")]
        public static PlasticSCMCheckinResult PlasticSCMCheckin(this ICakeContext ctx, PlasticSCMCheckinSettings settings)
        {
            return new PlasticSCMCheckinExecutor(ctx.FileSystem, ctx.Environment, ctx.ProcessRunner, ctx.Tools, ctx.Log)
                .Checkin(settings);
        }

        [CakeMethodAlias]
        [CakeAliasCategory("Find")]
        [CakeNamespaceImport("Cake.PlasticSCM.Find")]
        public static PlasticSCMFindResult PlasticSCMFind(this ICakeContext ctx, PlasticSCMFindSettings settings)
        {
            return new PlasticSCMFindExecutor(ctx.FileSystem, ctx.Environment, ctx.ProcessRunner, ctx.Tools, ctx.Log)
                .Find(settings);
        }

        [CakeMethodAlias]
        [CakeAliasCategory("Add")]
        [CakeNamespaceImport("Cake.PlasticSCM.Add")]
        public static PlasticSCMAddResult PlasticSCMAdd(this ICakeContext ctx, PlasticSCMAddSettings settings)
        {
            return new PlasticSCMAddExecutor(ctx.FileSystem, ctx.Environment, ctx.ProcessRunner, ctx.Tools, ctx.Log)
                .Add(settings);
        }
    }
}
