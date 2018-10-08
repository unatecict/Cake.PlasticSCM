using System;
using Cake.PlasticSCM.Status;
using Cake.PlasticSCM.Tests.Fixtures;
using NUnit.Framework;

namespace Cake.PlasticSCM.Tests.Units
{
    [TestFixture]
    public class StatusTests
    {
        private const string STATUS_ALL_CHANGELIST_XML = "status_all_changelist.xml";

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Should_Parse_Status()
        {
            StatusFixture fixture = new StatusFixture("status_all.xml") {Settings = new PlasticSCMStatusSettings()};

            var result = fixture.Run();
            var status = result.Data;

            Assert.IsNotNull(status);
            Assert.AreEqual("plastic1:8087", status.RepositoryServerName);
            Assert.AreEqual("Cake.PlasticSCM", status.RepositoryName);
            Assert.AreEqual(123, status.Changeset);
        }

        [Test]
        public void Should_Parse_Changes()
        {
            StatusFixture fixture = new StatusFixture("status_all.xml") {Settings = new PlasticSCMStatusSettings()};

            var result = fixture.Run();
            var status = result.Data;

            Assert.IsNotNull(status);
            Assert.IsNotNull(status.Changes);
            Assert.AreEqual(11, status.Changes.Count);

            var change = status.Changes[9];

            Assert.AreEqual("moved", change.Path);
            Assert.AreEqual("aaaa.txt", change.OldPath);
            Assert.AreEqual(1d, change.SimilarityPerUnit);
            Assert.AreEqual(PlasticSCMStatusChangeType.Moved, change.Type);
            Assert.IsNotNull(change.MergesInfo); //Language dependent, can't check contents
        }

        [Test]
        public void Show_Parse_All_ChangeTypes()
        {
            StatusFixture fixture = new StatusFixture("status_all.xml") {Settings = new PlasticSCMStatusSettings()};

            var result = fixture.Run();
            var status = result.Data;

            Assert.AreEqual(PlasticSCMStatusChangeType.Private, status.Changes[0].Type);
            Assert.AreEqual(PlasticSCMStatusChangeType.Added, status.Changes[1].Type);
            Assert.AreEqual(PlasticSCMStatusChangeType.LocalMoved, status.Changes[2].Type);
            Assert.AreEqual(PlasticSCMStatusChangeType.LocalDeleted, status.Changes[3].Type);
            Assert.AreEqual(PlasticSCMStatusChangeType.Changed, status.Changes[4].Type);
            Assert.AreEqual(PlasticSCMStatusChangeType.CheckOut, status.Changes[5].Type);
            Assert.AreEqual(PlasticSCMStatusChangeType.Ignored, status.Changes[6].Type);
            Assert.AreEqual(PlasticSCMStatusChangeType.Replaced, status.Changes[7].Type);
            Assert.AreEqual(PlasticSCMStatusChangeType.Copied, status.Changes[8].Type);
            Assert.AreEqual(PlasticSCMStatusChangeType.Moved, status.Changes[9].Type);
            Assert.AreEqual(PlasticSCMStatusChangeType.Deleted, status.Changes[10].Type);

        }

        [Test]
        public void Show_Parse_All_ChangeLists()
        {
            StatusFixture fixture =
                new StatusFixture(STATUS_ALL_CHANGELIST_XML) {Settings = new PlasticSCMStatusSettings()};

            var result = fixture.Run();
            var status = result.Data;

            Assert.IsNotNull(status);
            Assert.IsNotNull(status.ChangeLists);
            Assert.AreEqual(1, status.ChangeLists.Count);
            Assert.AreEqual(1, status.ChangeLists[0].Changes.Count);

            var changeList = status.ChangeLists[0];
            var change = status.ChangeLists[0].Changes[0];

            Assert.AreEqual("Merge desde cs:11", changeList.Name);
            Assert.AreEqual("Ficheros cambiados durante el merge", changeList.Description);


            Assert.AreEqual("moved", change.Path);
            Assert.AreEqual("aaaa.txt", change.OldPath);
            Assert.AreEqual(0.95d, change.SimilarityPerUnit);
            Assert.AreEqual(PlasticSCMStatusChangeType.Moved, change.Type);
            Assert.IsNotNull(change.MergesInfo); //Language dependent, can't check contents

            
        }

        [Test]  
        public void Should_Generate_All_Arguments()
        {
            var percentOfSimilarity = 67;

            StatusFixture fixture =
                new StatusFixture(STATUS_ALL_CHANGELIST_XML)
                {
                    Settings = new PlasticSCMStatusSettings()
                    {
                        Filters = PlasticSCMStatusFilters.Added | PlasticSCMStatusFilters.Changed | PlasticSCMStatusFilters.Ignored,
                        GetChangelists = true,
                        LimitToChangelists = { "ChangeList A", "ChangeList B"},
                        PercentOfSimilarity = percentOfSimilarity
                    }
                };

            var result = fixture.Run();

            Assert.That(result.Args, Does.StartWith("status"));
            Assert.That(result.Args, Does.Contain("--added"));
            Assert.That(result.Args, Does.Contain("--xml"));
            Assert.That(result.Args, Does.Contain("--changed"));
            Assert.That(result.Args, Does.Contain("--ignored"));
            Assert.That(result.Args, Does.Contain($"--percentofsimilarity={percentOfSimilarity}"));
            Assert.That(result.Args, Does.Contain("--changelist=ChangeList A"));
            Assert.That(result.Args, Does.Contain("--changelist=ChangeList B"));
        }

        [Test]
        public void Should_Throw_If_Settings_Are_Null()
        {
            StatusFixture fixture = new StatusFixture(STATUS_ALL_CHANGELIST_XML) {Settings = null};

            Assert.Throws<ArgumentNullException>(() => fixture.Run());
        }
    }
}