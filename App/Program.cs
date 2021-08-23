using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using App.Configuration;
using App.Extensions;
using App.Models;
using App.Serializers;
using Bullseye;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BasicEmployee = App.Models.BasicSerialization.Employee;
using CustomEmployee = App.Models.CustomSerialization.Employee;
using ThirdPartyEmployee = App.Models.ThirdPartySerialization.Employee;

namespace App
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using (var host = CreateHostBuilder(args).Build())
            {
                var targets = new Targets();
                var basicSerializer = host.Services.GetRequiredService<IBinarySerializer>();
                var customSerializer = host.Services.GetRequiredService<IBinarySerializer>();
                var thirdPartySerializer = host.Services.GetRequiredService<ThirdPartyBinarySerializer>();
                targets.Add(TargetTypes.BasicSerialization, () =>
                {
                    var employeeBefore = Factory.CreateEmployeeWithBasicSerialization();
                    basicSerializer.Serialize(employeeBefore);
                    employeeBefore.WriteLine("Basic serialization done");
                    var employeeAfter = basicSerializer.Deserialize<BasicEmployee>();
                    employeeAfter.WriteLine("Basic deserialization done");
                });
                targets.Add(TargetTypes.CustomSerialization, () =>
                {
                    var employeeBefore = Factory.CreateEmployeeWithCustomSerialization();
                    customSerializer.Serialize(employeeBefore);
                    employeeBefore.WriteLine("Custom serialization done");
                    var employeeAfter = customSerializer.Deserialize<CustomEmployee>();
                    employeeAfter.WriteLine("Custom deserialization done");
                });
                targets.Add(TargetTypes.ThirdPartySerialization, () =>
                {
                    var employeeBefore = Factory.CreateEmployeeWithThirdPartySerialization();
                    thirdPartySerializer.Serialize(employeeBefore);
                    employeeBefore.WriteLine("ThirdParty serialization done");
                    var employeeAfter = thirdPartySerializer.Deserialize<ThirdPartyEmployee>();
                    employeeAfter.WriteLine("ThirdParty deserialization done");
                });
                targets.Add(TargetTypes.Default, dependsOn: new List<string>
                {
                    TargetTypes.BasicSerialization,
                    TargetTypes.CustomSerialization,
                    TargetTypes.ThirdPartySerialization
                });
                targets.RunAndExit(args);
            }

            Console.WriteLine("Press any key to exit !");
            Console.ReadKey();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((_, config) =>
                {
                    config.AddCommandLine(args);
                    config.AddEnvironmentVariables();
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    var environment = Environment.GetEnvironmentVariable("ENVIRONMENT");
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    config.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<ThirdPartyBinarySerializer>();
                    services.AddTransient<IBinarySerializer, BinarySerializer>();
                    services.AddTransient<ISurrogateSelector, ThirdPartySurrogateSelector>();
                    services.Configure<Settings>(context.Configuration.GetSection(nameof(Settings)));
                })
                .ConfigureLogging((_, loggingBuilder) =>
                {
                    loggingBuilder.AddNonGenericLogger();
                })
                .UseConsoleLifetime();

        private static class TargetTypes
        {
            public const string Default = "Default";
            public const string BasicSerialization = "Basic";
            public const string CustomSerialization = "Custom";
            public const string ThirdPartySerialization = "ThirdParty";
        }
    }
}
