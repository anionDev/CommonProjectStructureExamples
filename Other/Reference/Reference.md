# Reference

## Features

| id      | state       | description                                                                                               |
| ------- | ----------- | --------------------------------------------------------------------------------------------------------- |
| feat-1  | available   | Example of a common-project-structure codeunit for an Angular-web-application (`AngularCodeUnit`).        |
| feat-2  | available   | Example of a reverse-proxy serving a backend and a frontend together (`CombinedBackendFrontendCodeUnit`). |
| feat-3  | available   | Example of a Flutter-application (`FlutterCodeUnit`).                                                     |
| feat-4  | available   | Example of a .NET-console-application (`DotNetConsoleCodeUnit`).                                          |
| feat-5  | available   | Example of a .NET-library (`DotNetLibraryCodeUnit`).                                                      |
| feat-6  | available   | Example of a .NET-web-API-application (`DotNetWebAPICodeUnit`).                                           |
| feat-7  | available   | Example of a C#-client for another codeunit of the same repository (`DotNetWebAPIClientCodeUnit`).        |
| feat-8  | available   | Example of a containerized .NET-web-API-application (`WebAPIContainerCodeUnit`).                          |
| feat-9  | available   | Example of a containerized Angular-web-application (`WebAppContainerCodeUnit`).                           |
| feat-10 | available   | Example of a python-package (`PythonCodeUnit`).                                                           |
| feat-11 | available   | Example of a maven-project (`MavenCodeUnit`).                                                             |
| feat-12 | available   | Example of a go-project (`GoCodeUnit`).                                                                   |
| feat-13 | available   | Example of a rust-project (`RustCodeUnit`).                                                               |
| feat-14 | available   | Example of a Dart-library (`DartLibraryCodeUnit`).                                                        |
| feat-15 | available   | Example of a C++-library (`CPPLibrary`).                                                                  |
| feat-16 | available   | Example of a C-executable which uses a dependent codeunit (`CExecutable`).                                |
| feat-17 | unavailable | Example for an Ant-project (`AntCodeUnit`) is planned but does not exist yet.                             |
| feat-18 | unavailable | Example for an Electron-application (`ElectronCodeUnit`) is planned but does not exist yet.               |
| feat-19 | unavailable | Example for a Gradle-project (`GradleCodeUnit`) is planned but does not exist yet.                        |
| feat-20 | unavailable | Example for a Kotlin-project (`KotlinCodeUnit`) is planned but does not exist yet.                        |
| feat-21 | unavailable | Example for a python-backend (`PythonBackendCodeUnit`) is planned but does not exist yet.                 |
| feat-22 | unavailable | Example for a React-application (`ReactCodeUnit`) is planned but does not exist yet.                      |
| feat-23 | unavailable | Example for a static-HTML-application (`StaticHTMLCodeUnit`) is planned but does not exist yet.           |
| feat-24 | unavailable | Example for a TypeScript-backend (`TypeScriptBackendCodeUnit`) is planned but does not exist yet.         |
| feat-25 | unavailable | Example for a Vue.js-application (`VueJSCodeUnit`) is planned but does not exist yet.                     |
| feat-26 | unavailable | Example for web-components (`WebComponentsCodeUnit`) is planned but does not exist yet.                   |

## Findings

| Id        | Priority | State | Description                                                                                                                                                                                                             | Impact                                                                          | Notes                                                                                                                                                                            |
| --------- | -------- | ----- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ~~OTH-1~~ | low      | fixed | The visual-regression baseline-images and their test-references used the `light-`/`dark-` (dash) prefix instead of the `light_`/`dark_` (underscore) prefix required by the `visual-regression-baseline`-specification. | The baseline-filenames did not follow the specified `<theme-mode>_<name>`-form. | Found during the specification-verification-audit for the release. Resolved by renaming the six baseline-images and the names the tests refer to them by to the underscore-form. |
