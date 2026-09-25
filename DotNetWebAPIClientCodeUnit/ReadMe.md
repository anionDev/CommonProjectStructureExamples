# DotNetWebAPIClientCodeUnit

## Purpose

`DotNetWebAPIClientCodeUnit` is the demonstration-codeunit for the case that one codeunit uses another one of the same repository. It is a C#-client for `DotNetWebAPICodeUnit`: it declares `DotNetWebAPICodeUnit` in its `dependentcodeunits` (see `DotNetWebAPIClientCodeUnit.codeunit.xml`) and reaches it exclusively through `Other/Resources/DependentCodeUnits/DotNetWebAPICodeUnit`, which contains the build-artifacts (source-code, build-results, BOM, test-coverage) of that dependency. The client never reaches into `DotNetWebAPICodeUnit`'s own folder directly.

It shows which shape such a client-codeunit has in a repository which implements the CommonProjectStructure, not a realistic client: it wraps a single endpoint of `DotNetWebAPICodeUnit`'s example-calculator.

## Structure

The client is located in `DotNetWebAPIClientCodeUnit` and its testcases are located in `DotNetWebAPIClientCodeUnitTests`, which is the layout the CommonProjectStructure defines.

- `IDotNetWebAPIClient` declares the client's contract (`Add`, plus `IDisposable`).
- `DotNetWebAPIClient` implements it. It wraps `GRYLibrary`'s `GenericAPIClient`, builds the route for the server's `ExampleController`-calculator-endpoint and delegates the HTTP-call to it.
- `DotNetWebAPIClientCodeUnitTests/Testcases/ClientTests` contains the unit-tests, which do not need a running server.
- `DotNetWebAPIClientCodeUnitTests/Testcases/Integration` contains `EndToEndTests`, which start the built binary of the dependent `DotNetWebAPICodeUnit` (from `Other/Resources/DependentCodeUnits`) as a local test-server and call the client against it. These tests therefore need the actual `DotNetWebAPICodeUnit`-API to be reachable and do not run in every environment (for example not without the dependency's build-result being present).
- `DotNetWebAPIClientCodeUnitTests/TestUtilities` contains helpers used by the testcases, for example the resolution of the dependent codeunit's server-binary.

## Build and test

The codeunit is built and tested by the scripts of the CommonProjectStructure, so by the pipeline of the repository (`task bb` in the repository-root). The scripts are `Other/Build/Build.py`, `Other/QualityCheck/Linting.py` and `Other/QualityCheck/RunTestcases.py`.

What they run:

- The build compiles the class-library with `dotnet build` and stores the result as artifact in `Other/Artifacts/BuildResult_DotNet_win-x64`.
- The linting normalizes and formats the `csproj`-files and checks the `dotnet build`-diagnostics (analyzers) of the codeunit.
- The testcases are run with `dotnet test`. Code-coverage is collected and written to `Other/Artifacts/TestCoverage/TestCoverage.xml`, from which the html-report, the badges and the check of the coverage-threshold (`minimalcodecoverageinpercent` in `DotNetWebAPIClientCodeUnit.codeunit.xml`) are generated. The `EndToEndTests` in `Testcases/Integration` need the actual `DotNetWebAPICodeUnit`-API to be reachable to pass; without it, only the unit-tests in `Testcases/ClientTests` succeed.

## Use locally

This codeunit is a class-library and not a standalone application. After the build, reference the compiled assembly from `Other/Artifacts/BuildResult_DotNet_win-x64` (or the project itself) from another .NET-project, and use `DotNetWebAPIClientCodeUnit.Core.DotNetWebAPIClient` against a reachable instance of `DotNetWebAPICodeUnit`:

```
IGenericAPIClientConfiguration configuration = new GenericAPIClientConfiguration
{
    APIAddress = "http://127.0.0.1:1234",
    APIKey = null
};
using DotNetWebAPIClient client = new DotNetWebAPIClient(configuration);
decimal result = client.Add(2.5m, 3m);
```

## Further information

- Which requirements have to be fulfilled to run the scripts of this codeunit is documented in [Hints.md](./Other/Reference/ReferenceContent/Hints.md).
- How this codeunit is built is documented in [HowToBuild.md](./Other/Reference/ReferenceContent/HowToBuild.md).
