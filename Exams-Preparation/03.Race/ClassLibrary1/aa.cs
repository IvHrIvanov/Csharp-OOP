using System;
using System.Linq;
using System.Reflection;
using EasterRaces;
using NUnit.Framework;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

[TestFixture]
public class Tests_000_004
{
    // MUST exist within project, otherwise a Compile Time Error will be thrown.
    private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

    [Test]
    public void ValidateRepositoriesExist()
    {
        var typesToAssert = new[]
        {
            "CarRepository",
            "RaceRepository",
            "DriverRepository"
        };

        foreach (var typeName in typesToAssert)
        {
            Assert.That(GetType(typeName), Is.Not.Null, $"{typeName} type doesn't exist!");
        }
    }

    private static Type GetType(string name)
    {
        var type = ProjectAssembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == name);

        return type;
    }
}