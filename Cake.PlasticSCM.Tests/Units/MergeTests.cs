using Cake.PlasticSCM.Merge;
using Cake.PlasticSCM.Tests.Fixtures;
using NUnit.Framework;

namespace Cake.PlasticSCM.Tests.Units
{
    [TestFixture]
    public class MergeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_Generate_All_Arguments()
        {
            var settings = new PlasticSCMMergeSettings()
            {
                SourceObjectSpec = "src_spec",
                DestinationObjectSpec = "dst_spec",
                IntervalChangesetSpec = "int_spec",
                Shelve = true,
                MergeType = PlasticSCMMergeType.OnlyDst,
                NoDestinationChanges = true,
                KeepSource = true,
                KeepDestination = true,
                Subtractive = true,
                TryMerge = false,
                ComparisonMethod = PlasticSCMMergeComparisonMethod.IgnoreEol,
                CherryPick = true,
                Comment = "Esto es un comentario"
            };
            MergeFixture fixture = new MergeFixture("merge_with_dir_conflict.txt")
            {
                Settings = settings
            };

            var result = fixture.Run();

            Assert.That(result.Args, Does.StartWith("merge"));
            Assert.That(result.Args, Does.Contain(settings.SourceObjectSpec));
            Assert.That(result.Args, Does.Contain($"--to={settings.DestinationObjectSpec}"));
            Assert.That(result.Args, Does.Contain($"--interval-origin={settings.IntervalChangesetSpec}"));
            Assert.That(result.Args, Does.Contain("--shelve"));
            Assert.That(result.Args, Does.Contain("--mergetype=onlydst"));
            Assert.That(result.Args, Does.Contain("--no-dst-changes"));
            Assert.That(result.Args, Does.Contain("--ks"));
            Assert.That(result.Args, Does.Contain("--kd"));
            Assert.That(result.Args, Does.Contain("--subtractive"));
            Assert.That(result.Args, Does.Contain("--merge"));
            Assert.That(result.Args, Does.Contain("--cherrypicking"));
            Assert.That(result.Args, Does.Contain("--machinereadable"));
            Assert.That(result.Args, Does.Contain($"-c=\"{settings.Comment}\""));


        }

        [Test]
        public void Should_Detect_File_Conflicts()
        {
            var settings = new PlasticSCMMergeSettings()
            {
                SourceObjectSpec = "src_spec",
            };
            MergeFixture fixture = new MergeFixture("merge_with_file_conflict.txt")
            {
                Settings = settings
            };

            var result = fixture.Run();

            Assert.IsTrue(result.Data.HasConflicts);
        }

        [Test]
        public void Should_Detect_Directory_Conflicts()
        {
            var settings = new PlasticSCMMergeSettings()
            {   
                SourceObjectSpec = "src_spec",
            };
            MergeFixture fixture = new MergeFixture("merge_with_dir_conflict.txt")
            {
                Settings = settings
            };

            var result = fixture.Run();

            Assert.IsTrue(result.Data.HasConflicts);
        }

        [Test]
        public void Should_Detect_No_Conflicts()
        {
            var settings = new PlasticSCMMergeSettings()
            {
                SourceObjectSpec = "src_spec",
            };
            MergeFixture fixture = new MergeFixture("merge_with_no_conflict.txt")
            {
                Settings = settings
            };

            var result = fixture.Run();

            Assert.IsFalse(result.Data.HasConflicts);
        }

        [Test]
        public void Should_Throw_If_Settings_Are_Null()
        {
            MergeFixture fixture = new MergeFixture("merge_with_dir_conflict.txt");
            fixture.Settings = null;

            Assert.Catch(() => fixture.Run());
        }

        [Test]
        public void Should_Throw_If_SrcSpec_Is_Null()
        {
            MergeFixture fixture = new MergeFixture("merge_with_dir_conflict.txt");
            fixture.Settings = new PlasticSCMMergeSettings()
            {
                SourceObjectSpec = null
            };

            Assert.Catch(() => fixture.Run());
        }
    }
}