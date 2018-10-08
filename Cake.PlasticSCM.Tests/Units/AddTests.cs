using Cake.PlasticSCM.Add;
using Cake.PlasticSCM.Tests.Fixtures;
using NUnit.Framework;

namespace Cake.PlasticSCM.Tests.Units
{
    [TestFixture]
    public class AddTests
    {
        private const string ADD_MIXEDRESULT_FILE = "add_mixedresult.txt";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_Generate_All_Arguments()
        {
            var settings = new PlasticSCMAddSettings()
            {
                Paths = { "Path1" , "Path2"},
                Recursive = true,
                IncludeParents= true,
                CheckoutParent = true,
                SkipContentCheck = true,
                IgnoreFailed = true,
                FileTypesFilePath = "filepath",

            };
            AddFixture fixture = new AddFixture(ADD_MIXEDRESULT_FILE)
            {
                Settings = settings
            };

            var result = fixture.Run();

            Assert.That(result.Args, Does.StartWith("add"));
            Assert.That(result.Args, Does.Contain(settings.Paths[0]));
            Assert.That(result.Args, Does.Contain(settings.Paths[1]));
            Assert.That(result.Args, Does.Contain("-R"));
            Assert.That(result.Args, Does.Contain("--ignorefailed"));
            Assert.That(result.Args, Does.Contain("--skipcontentcheck"));
            Assert.That(result.Args, Does.Contain("--coparent"));
            Assert.That(result.Args, Does.Contain($"--filetypes=\"{settings.FileTypesFilePath}\""));
            Assert.That(result.Args, Does.Contain("--format=\"OK$$${0}"));
            Assert.That(result.Args, Does.Contain("--errorformat=\"ERR$$${0}\""));
        }

        [Test]
        public void Should_Read_Results()
        {   
            var settings = new PlasticSCMAddSettings();

            AddFixture fixture = new AddFixture(ADD_MIXEDRESULT_FILE)
            {
                Settings = settings
            };

            var result = fixture.Run();

            Assert.AreEqual(1,result.Data.Ok.Count);
            Assert.AreEqual(1,result.Data.Error.Count);
        }


        [Test]
        public void Should_Throw_If_Settings_Are_Null()
        {
            AddFixture fixture = new AddFixture(ADD_MIXEDRESULT_FILE);
            fixture.Settings = null;

            Assert.Catch(() => fixture.Run());
        }
    }
}