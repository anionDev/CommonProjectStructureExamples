# CommonProjectStructureExamples

## Purpose

The `CommonProjectStructureExamples`-repository contains examples how to implement/use the [CommonProjectStructure](https://projects.aniondev.de/PublicProjects/Common/ProjectTemplates/-/blob/main/Conventions/RepositoryStructure/CommonProjectStructure/CommonProjectStructure.md) for different programming-languages and project-types.

Each codeunit of this repository is one such example. The examples are minimal on purpose: they show the structure a codeunit of that type has to have, not a realistic product. So when a new codeunit is created, copy the shape of the matching example and not its content.

## Codeunits

| Codeunit | Demonstrates |
|----------|--------------|
| `AngularCodeUnit` | an Angular-web-application |
| `CombinedBackendFrontendCodeUnit` | a reverse-proxy which serves a backend-server-application and a frontend-web-application together |
| `FlutterCodeUnit` | a Flutter-application (Material-Design, `linux`- and `web`-build-targets) |
| `DotNetConsoleCodeUnit` | a .NET-console-application |
| `DotNetLibraryCodeUnit` | a .NET-library |
| `DotNetWebAPICodeUnit` | a .NET-web-API-application |
| `DotNetWebAPIClientCodeUnit` | a C#-client for another codeunit of the same repository (`DotNetWebAPICodeUnit`) |
| `WebAPIContainerCodeUnit` | a containerized variant of `DotNetWebAPICodeUnit` |
| `WebAppContainerCodeUnit` | a containerized variant of `AngularCodeUnit` |
| `PythonCodeUnit` | a python-package |
| `MavenCodeUnit` | a maven-project |
| `GoCodeUnit` | a go-project |
| `RustCodeUnit` | a rust-project |
| `DartLibraryCodeUnit` | a Dart-library |
| `CPPLibrary` | a C++-library |
| `CExecutable` | a C-executable which uses the library of the dependent codeunit `CPPLibrary` |

`DotNetWebAPIClientCodeUnit` is the example for the case that one codeunit uses another one of the same repository: it declares `DotNetWebAPICodeUnit` in its `dependentcodeunits` and reaches it exclusively through `Other/Resources/DependentCodeUnits`.

`MavenCodeUnit`, `GoCodeUnit` and `RustCodeUnit` are commandline-applications which print a greeting. They put their testcases into the project itself and not into a sibling-project `<codeunit>Tests` like the .NET-codeunits do, because that is the layout maven, go and cargo define; the respective `ReadMe.md` of the codeunit states that.

## Development-state

The development-state of this product is `Maintenance-updates only`, which is the state of every codeunit of it. The product carries the worst development-state of all its codeunits.

## Development

### Build

Run `task BaseBuildAllCodeunits` (or shorter: `task bb`) to run the whole pipeline for all enabled codeunits: building, linting, running the testcases, generating the reference and creating the artifacts.

### Local test-services

Some codeunits need a database to run their testcases. A local one is started and stopped with:

- `task LocaltestservicePostgresqlStart` (`task ldpu`) and `task LocaltestservicePostgresqlStop` (`task ldpd`)
- `task LocaltestserviceMariadbStart` (`task ldmu`) and `task LocaltestserviceMariadbStop` (`task ldmd`)

### Visual-regression-tests

`AngularCodeUnit` contains visual-regression-tests. After an intended change of its user-interface the baseline-screenshots are regenerated with `task UpdateVisualRegressionBaselines` (or shorter: `task uvrb`). The regenerated screenshots have to be reviewed before they are committed, because that command accepts every change of the appearance as the new expected state.

### Dependencies

The tools which are required to build a codeunit and the packages a codeunit depends on are declared in the codeunit itself and not here, so that the declaration stays where the dependency is: the tools in `<codeunit>/<codeunit>.codeunit.xml`, the packages in the package-file of the respective technology (for example the `csproj`-files, `package.json`, `requirements.txt`, `pom.xml`). Which requirements have to be fulfilled to run the scripts of a codeunit is documented in `<codeunit>/Other/Reference/ReferenceContent/Hints.md`, and how a codeunit is built is documented in `<codeunit>/Other/Reference/ReferenceContent/HowToBuild.md`.

## Planned codeunits

Examples for the following project-types do not exist yet:

- `AntCodeUnit`
- `ElectronCodeUnit`
- `GradleCodeUnit`
- `KotlinCodeUnit`
- `PythonBackendCodeUnit`
- `ReactCodeUnit`
- `StaticHTMLCodeUnit`
- `TypeScriptBackendCodeUnit`
- `VueJSCodeUnit`
- `WebComponentsCodeUnit`

## Changelog

See the [Changelog-folder](./Other/Resources/Changelog).

## Contribute

Contributions are always welcome.

See [Contributing.md](./Contributing.md) for information about that.

## Repository-structure

This product uses the [CommonProjectStructure](https://projects.aniondev.de/PublicProjects/Common/ProjectTemplates/-/blob/main/Conventions/RepositoryStructure/CommonProjectStructure/CommonProjectStructure.md) as repository-structure in the version `3.0.0`, which is the version its codeunits declare in their `codeunit.xml`.

## Build

This product requires to use `scbuildcodeunits` implemented/provided by [ScriptCollection](https://github.com/anionDev/ScriptCollection) to build the project.

## Branching-system

This product follows the [GitFlowSimplified](https://projects.aniondev.de/PublicProjects/Common/ProjectTemplates/-/blob/main/Conventions/BranchingSystem/GitFlowSimplified/GitFlowSimplified.md)-branching-system.

## Image-properties

The image-artifacts of this product must fulfil the image-properties defined by [DefaultImageUsabilityRequirements](https://projects.aniondev.de/PublicProjects/Common/ProjectTemplates/-/blob/main/Conventions/ImageProperties/DefaultImageUsabilityRequirements/DefaultImageUsabilityRequirements.md).

## Versioning

This product follows the [SemVerPractise](https://projects.aniondev.de/PublicProjects/Common/ProjectTemplates/-/blob/main/Conventions/Versioning/SemVerPractise/SemVerPractise.md)-versioning-system.

## License

See [License.txt](./License.txt) for license-information.
