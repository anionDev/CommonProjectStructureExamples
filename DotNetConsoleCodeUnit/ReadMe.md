# DotNetConsoleCodeUnit

## Purpose

`DotNetConsoleCodeUnit` is the demonstration-codeunit for a .NET-console-application. It shows which shape such a codeunit has in a repository which implements the CommonProjectStructure, not a realistic application: it prints a greeting, the target-environment it was compiled for, and the result of one example-function.

## Structure

The console-application is located in `DotNetConsoleCodeUnit` and its testcases are located in `DotNetConsoleCodeUnitTests`, which is the layout the CommonProjectStructure defines. Both projects are tied together by the solution-file `DotNetConsoleCodeUnit.sln`.

- `Program.cs` contains the entry-point (`Main`). It only prints the output and calls `Utilities`.
- `Utilities.cs` contains the example-functions (`Add`) and the function which resolves the configured target-environment (`GetEnvironmentTargetType`), separated from `Program.cs` so that they are testable without running the executable.
- `DotNetConsoleCodeUnitTests/Testcases/UtilitiesTests.cs` contains the testcases for `Utilities.cs`.

## Build and test

The codeunit is built and tested by the scripts of the CommonProjectStructure, so by the pipeline of the repository (`task bb` in the repository-root) and not by calling `dotnet` directly. The scripts are `Other/Build/Build.py`, `Other/QualityCheck/Linting.py` and `Other/QualityCheck/RunTestcases.py`.

What they run:

- The build runs `dotnet build` for the `win-x64` runtime declared in the `.csproj`-files. The result is not self-contained (it requires the matching .NET-runtime to be installed) and is stored as artifact in `Other/Artifacts/BuildResult_DotNet_win-x64`.
- The linting normalizes the `.cs`-files, formats the `.csproj`-files as XML, verifies that both `.csproj`-files match the standardized CommonProjectStructure-format (for example that every package-reference is pinned to exactly one version), and then builds the solution again to collect the compiler- and analyzer-diagnostics. It fails if any diagnostic has the severity "error".
- The testcases are run by `dotnet test` on the solution, using the coverage-collector configured in `runsettings.xml` ("XPlat Code Coverage", cobertura-format). The resulting coverage-file is stored in `Other/Artifacts/TestCoverage`, and the html-report, the badges and the check of the coverage-threshold are generated from that file.

## Run locally

After the build, run `Other/Artifacts/BuildResult_DotNet_win-x64/DotNetConsoleCodeUnit.exe`. It prints a greeting, the target-environment-type the executable was compiled for, and the result of the example-function `Utilities.Add`.

## Further information

- Which requirements have to be fulfilled to run the scripts of this codeunit is documented in [Hints.md](./Other/Reference/ReferenceContent/Hints.md).
- How this codeunit is built is documented in [HowToBuild.md](./Other/Reference/ReferenceContent/HowToBuild.md).
