# DotNetWebAPICodeUnit

## Purpose

`DotNetWebAPICodeUnit` is the demonstration-codeunit for a .NET-web-API-application. It shows which
shape such a codeunit has in a repository which implements the CommonProjectStructure, not a
realistic product: it offers a small calculator-example (`ExampleController`) and a customer-CRUD-
example (`CustomerController`) whose data is either kept in memory or stored in a MariaDB- or a
PostgreSQL-database.

The package is not published anywhere. It exists to be copied as the starting-point of a real
.NET-web-API-codeunit. It depends on `DotNetLibraryCodeUnit`.

## Structure

The application is located in `DotNetWebAPICodeUnit` and its testcases are located in
`DotNetWebAPICodeUnitTests`, which is the layout the CommonProjectStructure defines.

- `Controller` contains the http-controllers. A controller only translates between http and the
  business-logic and contains no rules of its own.
- `Services` contains the business-logic-service (`BusinessLogicService`) and the persistence-
  implementations: `TransientPersistence` (in-memory, used when the application runs without a
  database) and `DatabasePersistence` (backed by MariaDB or PostgreSQL, selected through the
  database-interactor which `Miscellaneous/GetDatabaseInteractorVisitor` returns).
- `Model/BusinessTypes` contains the example business-type `Customer`.
- `Miscellaneous` contains the sql-provider (which loads the embedded sql-scripts), the health-check
  and small utilities.
- `Configuration` contains the codeunit-specific commandline-parameter and configuration classes
  which the library uses to build the server.
- `BackgroundServices` contains `MetricsService`, an example of a periodically-running background-
  service which reports a metric.
- `Resources/Database/MariaDB` and `Resources/Database/PostgreSQL` each contain a `Migrations`-
  folder (the schema-migrations) and a `Statements`-folder (the sql-statements the persistence
  executes), one pair per supported database-type, because the sql-dialects differ.

## Build and test

The codeunit is built and tested by the scripts of the CommonProjectStructure, so by the pipeline of
the repository (`task bb` in the repository-root). The scripts are `Other/Build/Build.py`,
`Other/QualityCheck/Linting.py` and `Other/QualityCheck/RunTestcases.py`.

What they run:

- The build compiles the application and its test-project and stores the result as artifact in
  `Other/Artifacts/BuildResult_DotNet_win-x64` (respectively `Other/Artifacts/BuildResultTests_DotNet_win-x64`
  for the test-project). It also generates the api-specification of this codeunit into
  `Other/Artifacts/APISpecification`, because the codeunits which consume this api
  (`DotNetWebAPIClientCodeUnit` and `AngularCodeUnit`) generate their client out of that artifact.
- The linting verifies that the `.csproj`-files of this codeunit follow the standardized format the
  CommonProjectStructure defines (for example matching metadata and the urls from the repository's
  product-information), and then builds the codeunit so that the configured .NET-code-analyzers run
  over it.
- The testcases are run by MSTest, and the coverage is measured via the "XPlat Code Coverage"-
  collector, which writes its report in the cobertura-format (configured in `runsettings.xml`). The
  html-report, the badges and the check of the coverage-threshold are generated from that report.

Not every testcase can run without further setup: the testcases in `Testcases/Services/DatabaseTests`,
`Testcases/Services/PersistenceTests/PersistenceTestsForMariaDB`/`...ForPostgreSQL` and
`DatabaseStructureTestsForMariaDB`/`...ForPostgreSQL` are integration-tests which need a running
MariaDB- respectively PostgreSQL-test-service. Start these with `task ldmu` respectively `task ldpu`
from the repository-root before running the testcases locally; running the whole pipeline with
`task bb` brings the test-services up itself. The remaining testcases need nothing but the process
itself and are unit-tests (for example `BusinessLogicServiceTests`, `PersistenceTestsForTransient`
and `SQLProviderTests`).

## Run locally

Run `Other/Artifacts/BuildResult_DotNet_win-x64/DotNetWebAPICodeUnit.exe` after the build. Without a
persisted configuration the application initializes itself with the transient in-memory persistence,
so it can be tried out without a database; a MariaDB- or PostgreSQL-backed persistence is configured
through the generated configuration-file afterwards (see the initialization-code in `Program.cs`).

## Further information

- Which requirements have to be fulfilled to run the scripts of this codeunit is documented in
  [Hints.md](./Other/Reference/ReferenceContent/Hints.md).
- How this codeunit is built is documented in
  [HowToBuild.md](./Other/Reference/ReferenceContent/HowToBuild.md).
