#tool "nuget:?package=xunit.runner.console"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories
var rootDir = MakeAbsolute(Directory("../"));
var outputDir = rootDir.Combine(Directory("release"));
var binariesDir = outputDir.Combine(Directory("binaries"));
var testResultsDir = outputDir.Combine(Directory("testresults"));
var packagesDir = outputDir.Combine(Directory("packages"));

var solution = rootDir.CombineWithFilePath(File("DataValidation.sln"));

var productVersion = "0.2.0";
var buildVersion = productVersion + ".0";
if (AppVeyor.IsRunningOnAppVeyor)
{
    Information("Running on AppVeyor");
    buildVersion = productVersion + "." + AppVeyor.Environment.Build.Number;
    AppVeyor.UpdateBuildVersion(buildVersion);

    Information("Build version: " + buildVersion);
}

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

void PrintEnvironment(ICakeContext context)
{
    context.Information("Root dir:         " + rootDir);
    context.Information("Output dir:       " + outputDir);
    context.Information("Binaries dir:     " + binariesDir);
    context.Information("Test results dir: " + testResultsDir);
    context.Information("Packages dir:     " + packagesDir);
    context.Information("Product version:  " + productVersion);
    context.Information("Build version:    " + buildVersion);
}

Task("Clean")
    .Does(() =>
{
    CleanDirectory(outputDir);
});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore(solution);
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
    if(IsRunningOnWindows())
    {
      // Use MSBuild
      MSBuild(solution, settings =>
        settings.SetConfiguration(configuration));
    }
    else
    {
      // Use XBuild
      XBuild(solution, settings =>
        settings.SetConfiguration(configuration));
    }
});

Task("UnitTests")
    .IsDependentOn("Build")
    .Does(() =>
{
    CreateDirectory(testResultsDir);

    var msTestTests = new FilePath[]
    {
        rootDir.CombineWithFilePath("tests/MSTest/bin/" + configuration + "/ImpruvIT.DataValidation.MSTest.UnitTests.dll"),
    };
    var msTest2Tests = new FilePath[]
    {
        rootDir.CombineWithFilePath("tests/MSTest2/ImpruvIT.DataValidation.MSTest2.UnitTests.csproj"),
        rootDir.CombineWithFilePath("tests/XUnit2/ImpruvIT.DataValidation.XUnit2.UnitTests.csproj"),
    };
    var xUnitTests = new FilePath[]
    {
        rootDir.CombineWithFilePath("tests/Core/ImpruvIT.DataValidation.UnitTests.csproj"),
        rootDir.CombineWithFilePath("tests/XUnit2/ImpruvIT.DataValidation.XUnit2.UnitTests.csproj"),
    };

    MSTest(msTestTests, new MSTestSettings
    {
        //ResultsFile = testResultsDir.CombineWithFilePath("MSTest.testresults").ToString(),
    });

    /* VSTest(vsTestTests, new VSTestSettings
    {
        FrameworkVersion = VSTestFrameworkVersion.NET45,
        Logger = AppVeyor.IsRunningOnAppVeyor ? "AppVeyor" : "trx",
        //ResultsFile = testResultsDir.CombineWithFilePath("MSTest.testresults").ToString(),
    }); */

    foreach(var project in xUnitTests.Concat(msTest2Tests))
    {
        Information("Running tests: " + project);
        DotNetCoreTool(project, "test",  "--no-restore --no-build --configuration " + configuration + " --results-directory " + testResultsDir);
    }
});

Task("PackNuGet")
    .IsDependentOn("Build")
    .Does(() =>
{
    var nuSpecs = new FilePath[]
    {
        rootDir.CombineWithFilePath(File("src/Core/ImpruvIT.DataValidation.nuspec")),
        rootDir.CombineWithFilePath(File("src/XUnit2/ImpruvIT.DataValidation.Xunit2.nuspec")),
        rootDir.CombineWithFilePath(File("src/MSTest/ImpruvIT.DataValidation.MSTest.nuspec")),
        rootDir.CombineWithFilePath(File("src/MSTest2/ImpruvIT.DataValidation.MSTest2.nuspec")),
    };

    foreach (var nuSpec in nuSpecs)
    {
        NuGetPack(
            nuSpec, 
            new NuGetPackSettings
            {
                Version = productVersion,
                BasePath = nuSpec.GetDirectory().Combine("bin/" + configuration),
                OutputDirectory = packagesDir
            });
    }
});

Task("PushNuGet")
    .IsDependentOn("PackNuGet")
    .Does(() =>
{
    var packages = GetFiles(packagesDir + "/*.nupkg");

    // Push the package.
    NuGetPush(packages, new NuGetPushSettings {
        Source = "https://api.nuget.org/v3/index.json",
        ApiKey = EnvironmentVariable("NUGET_ORG_API_KEY")
    });
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("UnitTests")
    .IsDependentOn("PackNuGet");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

PrintEnvironment(Context);
RunTarget(target);
