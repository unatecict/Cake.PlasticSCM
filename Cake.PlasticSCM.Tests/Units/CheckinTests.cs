using Cake.PlasticSCM.Checkin;
using Cake.PlasticSCM.Tests.Fixtures;
using NUnit.Framework;

namespace Cake.PlasticSCM.Tests.Units
{
    [TestFixture]
    public class CheckinTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_Generate_All_Arguments()
        {
            var settings = new PlasticSCMCheckinSettings()
            {
                Paths = { "Path1" , "Path2"},
                All = true,
                Dependencies = true,
                Comment = "Checkin comment",
                Symlink = true,
                NoCheck = true,
            };
            CheckinFixture fixture = new CheckinFixture("merge_with_dir_conflict.txt")
            {
                Settings = settings
            };

            var result = fixture.Run();

            Assert.That(result.Args, Does.StartWith("ci"));
            Assert.That(result.Args, Does.Contain(settings.Paths[0]));
            Assert.That(result.Args, Does.Contain(settings.Paths[1]));
            Assert.That(result.Args, Does.Contain("--all"));
            Assert.That(result.Args, Does.Contain("--dependencies"));
            Assert.That(result.Args, Does.Contain("--symlink"));
            Assert.That(result.Args, Does.Contain("--nchk"));
            Assert.That(result.Args, Does.Contain($"-c=\"{settings.Comment}\""));
            Assert.That(result.Args, Does.Contain("--machinereadable"));

        }

        [Test]
        public void Should_Detect_Commited_Needed()
        {   
            var settings = new PlasticSCMCheckinSettings();

            CheckinFixture fixture = new CheckinFixture("checkin_done.txt")
            {
                Settings = settings
            };

            var result = fixture.Run();

            Assert.IsTrue(result.Data.Commited);
        }

        [Test]
        public void Should_Detect_Not_Commited()
        {
            var settings = new PlasticSCMCheckinSettings();

            CheckinFixture fixture = new CheckinFixture("checkin_merge_needed.txt")
            {
                Settings = settings
            };

            var result = fixture.Run();

            Assert.IsFalse(result.Data.Commited);
        }

        [Test]
        public void Should_Detect_Merge_Not_Needed()
        {
            var settings = new PlasticSCMCheckinSettings();

            CheckinFixture fixture = new CheckinFixture("checkin_done.txt")
            {
                Settings = settings
            };

            var result = fixture.Run();

            Assert.IsFalse(result.Data.MergeNeeded);
        }

        [Test]
        public void Should_Detect_Merge_Needed()
        {
            var settings = new PlasticSCMCheckinSettings();

            CheckinFixture fixture = new CheckinFixture("checkin_merge_needed.txt")
            {
                Settings = settings
            };

            var result = fixture.Run();

            Assert.IsTrue(result.Data.MergeNeeded);
        }

        [Test]
        public void Should_Throw_If_Settings_Are_Null()
        {
            CheckinFixture fixture = new CheckinFixture("merge_with_dir_conflict.txt");
            fixture.Settings = null;

            Assert.Catch(() => fixture.Run());
        }
    }
}