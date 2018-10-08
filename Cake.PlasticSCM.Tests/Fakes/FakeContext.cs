using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing;

namespace Cake.PlasticSCM.Tests.Fakes
{
    public static class FakeContextBuilder
    {
        public static ICakeContext GetFakeContext()
        {
            var testDir = Environment.GetEnvironmentVariable("CAKEPLASTIC_TESTDIR");
            var fileSystem = new FileSystem();
            var environment = new FakeEnvironment(PlatformFamily.Windows);
            var log = new FakeLog();
            var globber = new Globber(fileSystem, environment);

            var context =  new CakeContext
            (
                fileSystem: fileSystem,
                environment: environment,
                globber: globber,
                log: log,
                arguments: new FakeCakeArguments(),
                processRunner: new ProcessRunner(environment, log),
                registry: new WindowsRegistry(),
                tools: new ToolLocator(environment, new ToolRepository(environment),
                    new ToolResolutionStrategy(fileSystem, environment, globber,
                        new CakeConfigurationProvider(fileSystem, environment).CreateConfiguration(testDir,
                            new Dictionary<string, string>()))),
                data: new FakeDataService()
            );

            context.Environment.WorkingDirectory = testDir;
            return context;
        }
    }
}