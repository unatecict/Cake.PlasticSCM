using System;
using Cake.PlasticSCM.Switch;
using Cake.PlasticSCM.Tests.Fixtures;
using NUnit.Framework;

namespace Cake.PlasticSCM.Tests.Units
{
    [TestFixture]
    public class SwitchTests    
    {
        [SetUp] 
        public void Setup()
        {
        }

        [Test]  
        public void Should_Generate_All_Arguments() 
        {
            var objectSpec = "cs:1234";

            SwitchFixture fixture = new SwitchFixture
            {
                Settings = new PlasticSCMSwitchSettings()
                {
                    ObjectSpec = objectSpec
                }
            };

            var result = fixture.Run();

            Assert.That(result.Args, Does.StartWith("switch"));
            Assert.That(result.Args, Does.Contain(objectSpec));
        }

        [Test]
        public void Should_Throw_If_Settings_Are_Null()
        {
            SwitchFixture fixture = new SwitchFixture();
            fixture.Settings = null;

            Assert.Throws<ArgumentNullException>(() => fixture.Run());
        }

        [Test]
        public void Should_Throw_If_ObjectSpec_Is_Null()
        {
            SwitchFixture fixture = new SwitchFixture();
            fixture.Settings = new PlasticSCMSwitchSettings()
            {
                ObjectSpec = null
            };

            Assert.Throws<ArgumentNullException>(() => fixture.Run());
        }
    }
}