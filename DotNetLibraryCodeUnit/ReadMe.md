# DotNetLibraryCodeUnit

## Purpose

`DotNetLibraryCodeUnit` is the demonstration-codeunit for a .NET-library. It shows which shape such a codeunit has in a repository which implements the CommonProjectStructure, not a realistic library: it provides a small set of example arithmetic-functions.

## Structure

The library is located in `DotNetLibraryCodeUnit` and its testcases are located in the sibling-project `DotNetLibraryCodeUnitTests`, which is the layout the CommonProjectStructure defines.

- `DotNetLibraryCodeUnit/Miscellaneous/Utilities.cs` contains the `Utilities`-class with the example-functions `Add`, `Sub`, `Mul` and `Div`, in the namespace `DotNetLibraryCodeUnit.Core.Miscellaneous`.
- `DotNetLibraryCodeUnitTests/Testcases/UtilitiesTests.cs` contains the corresponding MSTest-testcases.

## Build and test

The codeunit is built and tested by the scripts of the CommonProjectStructure, so by the pipeline of the repository (`task bb` in the repository-root). The scripts are `Other/Build/Build.py`, `Other/QualityCheck/Linting.py` and `Other/QualityCheck/RunTestcases.py`.

What they run:

- The build compiles the library for the `win-x64`-runtime and stores the result as artifact in `Other/Artifacts/BuildResult_DotNet_win-x64`. It also packs the built dll into a NuGet-package, based on `Other/Build/DotNetLibraryCodeUnit.nuspec`, which is stored in `Other/Artifacts/BuildResult_NuGet`.
- The linting normalizes and formats the csproj- and nuspec-files and then evaluates the diagnostics of the dotnet-build (compiler-warnings and analyzer-findings); any diagnostic reported with severity "error" fails the linting.
- The testcases are run by `dotnet test` (MSTest) using the projects declared in `DotNetLibraryCodeUnit.sln`, with `runsettings.xml` configuring coverage-collection via "XPlat Code Coverage" in the cobertura-format. The html-report, the badges and the check of the coverage-threshold are generated from that report.

## Install locally

Install the built NuGet-package with `dotnet add package DotNetLibraryCodeUnit --source Other/Artifacts/BuildResult_NuGet --version <version>`, or reference the built dll in `Other/Artifacts/BuildResult_DotNet_win-x64/DotNetLibraryCodeUnit.dll` directly.

## Further information

- Which requirements have to be fulfilled to run the scripts of this codeunit is documented in [Hints.md](./Other/Reference/ReferenceContent/Hints.md).
- How this codeunit is built is documented in [HowToBuild.md](./Other/Reference/ReferenceContent/HowToBuild.md).
