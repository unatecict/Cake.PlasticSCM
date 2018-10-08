using System;
using Cake.PlasticSCM.Common;
using Cake.PlasticSCM.Find;
using Cake.PlasticSCM.Tests.Fixtures;
using NUnit.Framework;

namespace Cake.PlasticSCM.Tests.Units
{
    [TestFixture]
    public class FindTests
    {
        private const string STATUS_ALL_CHANGELIST_XML = "status_all_changelist.xml";

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Should_Parse_ChangeSets()
        {
            FindFixture fixture = new FindFixture("find_changesets.xml") {Settings = new PlasticSCMFindSettings()};

            var result = fixture.Run();
            var found = result.Data;

            Assert.IsNotNull(found);
            Assert.AreEqual(1,found.Changesets.Count);
            var cs = found.Changesets[0];
            Assert.AreEqual(5, cs.Id);
            Assert.AreEqual(0,cs.ChangesetId);
            Assert.AreEqual("Root dir",cs.Comment);
            Assert.AreEqual(new DateTime(2018,8,28,17,48,29), cs.Date);
            Assert.AreEqual("ruben.ruiz", cs.Owner);
            Assert.AreEqual("Test", cs.Repository);
            Assert.AreEqual("plastic1:8087", cs.Repserver);
            Assert.AreEqual("Test", cs.Repname);
            Assert.AreEqual("/main", cs.Branch);
            Assert.AreEqual("-1", cs.Parent);
            Assert.AreEqual("0497ef04-4c81-4090-8458-649885400c84", cs.Guid);
        }

        [Test]
        public void Should_Parse_Branches()
        {
            FindFixture fixture = new FindFixture("find_branch.xml") { Settings = new PlasticSCMFindSettings() { ObjectType = PlasticSCMObjectTypes.Branch } };

            var result = fixture.Run();
            var found = result.Data;

            Assert.IsNotNull(found);
            Assert.AreEqual(1, found.Branches.Count);
            var br = found.Branches[0];
            Assert.AreEqual(3, br.Id);
            Assert.AreEqual("main branch", br.Comment);
            Assert.AreEqual(new DateTime(2018, 8, 28, 17, 48, 29), br.Date);
            Assert.AreEqual("ruben.ruiz", br.Owner);
            Assert.AreEqual("", br.Parent);
            Assert.AreEqual("Test", br.Repository);
            Assert.AreEqual("Test", br.Repname);
            Assert.AreEqual("plastic1:8087", br.Repserver);
            Assert.AreEqual("T", br.Type);
            Assert.AreEqual(11, br.Changeset);
        }

        [Test]
        public void Should_Parse_Labels()
        {
            FindFixture fixture = new FindFixture("find_label.xml") { Settings = new PlasticSCMFindSettings() { ObjectType = PlasticSCMObjectTypes.Label } };
                
            var result = fixture.Run();
            var found = result.Data;

            Assert.IsNotNull(found);
            Assert.AreEqual(1, found.Labels.Count);
            var lbl = found.Labels[0];
            Assert.AreEqual(110, lbl.Id);
            Assert.AreEqual("A label", lbl.Name);
            Assert.AreEqual("Label comment", lbl.Comment);
            Assert.AreEqual(new DateTime(2018, 8, 22, 14, 53, 25), lbl.Date);
            Assert.AreEqual("ruben.ruiz", lbl.Owner);
            Assert.AreEqual("Test", lbl.Repository);
            Assert.AreEqual("Test", lbl.Repname);
            Assert.AreEqual("plastic1:8087", lbl.Repserver);
            Assert.AreEqual("/main/asdad", lbl.Branch);
            Assert.AreEqual(42, lbl.BranchId);
            Assert.AreEqual(9, lbl.Changeset);
        }

        [Test]
        public void Should_Parse_Revisions()
        {
            FindFixture fixture = new FindFixture("find_revision.xml") { Settings = new PlasticSCMFindSettings() { ObjectType = PlasticSCMObjectTypes.Revision } };

            var result = fixture.Run();
            var found = result.Data;

            Assert.IsNotNull(found);    
            Assert.AreEqual(1, found.Revisions.Count);
            var rev = found.Revisions[0];
            Assert.AreEqual(12, rev.Id);
            Assert.AreEqual("Rev comment", rev.Comment);
            Assert.AreEqual(new DateTime(2018, 8, 20, 18, 18, 43), rev.Date);
            Assert.AreEqual("ruben.ruiz", rev.Owner);
            Assert.AreEqual("txt", rev.Type);
            Assert.AreEqual(7, rev.Size);
            Assert.AreEqual(1, rev.Changeset);
            Assert.AreEqual(-1, rev.Parent);
            Assert.AreEqual(@"e:\Proyectos\TestPlastic\f1_new", rev.Item);
            Assert.AreEqual(17, rev.ItemId);
            Assert.AreEqual("br:/main", rev.Branch);
            Assert.AreEqual(@"e:\Proyectos\TestPlastic\f1_new", rev.Path);
            Assert.AreEqual("Test", rev.Repository);
            Assert.AreEqual("Test", rev.Repname);
            Assert.AreEqual("plastic1:8087", rev.Repserver);
            Assert.AreEqual("91/k7YfME23I1kO0x319CA==", rev.Hash);  
        }

        [Test]
        public void Should_Parse_Attributes()
        {
            FindFixture fixture = new FindFixture("find_attribute.xml") { Settings = new PlasticSCMFindSettings() {ObjectType = PlasticSCMObjectTypes.Attribute}};

            var result = fixture.Run();
            var found = result.Data;

            Assert.IsNotNull(found);
            Assert.AreEqual(1, found.Attributes.Count);
            var attr = found.Attributes[0];
            Assert.AreEqual(112, attr.Id);
            Assert.AreEqual("Attr comment", attr.Comment);
            Assert.AreEqual(new DateTime(2018, 8, 22, 15, 55, 13), attr.Date);
            Assert.AreEqual("ruben.ruiz", attr.Owner);
            Assert.AreEqual("Atributo 1", attr.Type);
            Assert.AreEqual(109, attr.SrcId);
            Assert.AreEqual("comment", attr.SrcComment);
            Assert.AreEqual(new DateTime(2018, 8, 21, 17, 08, 37), attr.SrcDate);
            Assert.AreEqual("ruben.ruiz", attr.SrcOwner);
            Assert.AreEqual(466, attr.SrcRepId);
            Assert.AreEqual("Test", attr.SrcRepName);
            Assert.AreEqual("plastic1:8087", attr.SrcRepServer);
            Assert.AreEqual("Atributo 1", attr.Name);
            Assert.AreEqual("123", attr.Value);
        }

        [Test]
        public void Should_Parse_Merges()
        {
            FindFixture fixture = new FindFixture("find_merge.xml") { Settings = new PlasticSCMFindSettings() { ObjectType = PlasticSCMObjectTypes.Merge } };

            var result = fixture.Run();
            var found = result.Data;

            Assert.IsNotNull(found);
            Assert.AreEqual(1, found.Merges.Count);
            var merge = found.Merges[0];
            Assert.AreEqual(57, merge.Id);
            Assert.AreEqual(new DateTime(2018, 8, 20, 19, 44, 07), merge.Date);
            Assert.AreEqual("ruben.ruiz", merge.Owner);
            Assert.AreEqual("merge", merge.Type);
            Assert.AreEqual(53, merge.SrcId);
            Assert.AreEqual("Source comment", merge.SrcComment);
            Assert.AreEqual(new DateTime(2018, 8, 20, 19, 41, 00), merge.SrcDate);
            Assert.AreEqual("ruben.ruiz", merge.SrcOwner);
            Assert.AreEqual(7, merge.SrcChangeset);
            Assert.AreEqual("br:/main", merge.SrcBranch);

            Assert.AreEqual(56, merge.DstId);
            Assert.AreEqual("Destination comment", merge.DstComment);
            Assert.AreEqual(new DateTime(2018, 8, 20, 19, 44, 07), merge.DstDate);
            Assert.AreEqual("ruben.ruiz", merge.DstOwner);
            Assert.AreEqual(8, merge.DstChangeset);
            Assert.AreEqual("br:/main/asdad", merge.DstBranch);

            Assert.AreEqual(99, merge.BaseId);
            Assert.AreEqual("Base comement", merge.BaseComment);
            Assert.AreEqual(new DateTime(2018, 8, 20, 19, 44, 08), merge.BaseDate);
            Assert.AreEqual("ruben.ruiz", merge.BaseOwner);
            Assert.AreEqual(123, merge.BaseChangeset);
            Assert.AreEqual("br:/main", merge.BaseBranch);

            Assert.AreEqual("br:/main@7", merge.Src);
            Assert.AreEqual("br:/main/asdad@8", merge.Dst);
        }


        [Test]
        public void Should_Parse_Reviews()
        {
            FindFixture fixture = new FindFixture("find_review.xml") { Settings = new PlasticSCMFindSettings() { ObjectType = PlasticSCMObjectTypes.Review } };

            var result = fixture.Run();
            var found = result.Data;

            Assert.IsNotNull(found);
            Assert.AreEqual(1, found.Reviews.Count);
            var rev = found.Reviews[0];
            Assert.AreEqual(114, rev.Id);
            Assert.AreEqual("ruben.ruiz", rev.Owner);
            Assert.AreEqual(new DateTime(2018, 8, 22, 17, 54, 18), rev.Date);
            Assert.AreEqual("Rev 1", rev.Title);
            Assert.AreEqual("Status0", rev.Status);
            Assert.AreEqual("Someone", rev.Assignee);
            Assert.AreEqual("ChangeSet", rev.TargetType);
            Assert.AreEqual(3, rev.Target);
        }

        [Test]  
        public void Should_Generate_All_Arguments()
        {
            var settings = new PlasticSCMFindSettings()
            {
                RepositorySpecs = {"RepoSpec1", "RepoSpec2"},
                WhereClause = "Date >= '2018-01-01:00:00:00'",
                ObjectType = PlasticSCMObjectTypes.Review
            };
            FindFixture fixture = new FindFixture("find_changesets.xml")
            {
                Settings = settings
            };

            var result = fixture.Run();

            Assert.That(result.Args, Does.StartWith("find"));
            Assert.That(result.Args, Does.Contain($"where {settings.WhereClause}"));
            Assert.That(result.Args, Does.Contain($"on repositories {string.Join(",", settings.RepositorySpecs)}"));
            Assert.That(result.Args, Does.Contain("--dateformat=s"));
            Assert.That(result.Args, Does.Contain("--xml"));
        }

        [Test]
        public void Should_Throw_If_Settings_Are_Null()
        {
            StatusFixture fixture = new StatusFixture(STATUS_ALL_CHANGELIST_XML) {Settings = null};

            Assert.Throws<ArgumentNullException>(() => fixture.Run());
        }
    }
}