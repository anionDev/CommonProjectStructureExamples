# WebAPIContainerCodeUnit

## Purpose

`WebAPIContainerCodeUnit` is the demonstration-codeunit for a containerized web-API. It shows which shape such a codeunit has in a repository which implements the CommonProjectStructure, not a realistic deployment: it packages the build-result of `DotNetWebAPICodeUnit`, another codeunit of this repository, into an OCI-image.

This codeunit has no source-code of its own. `DotNetWebAPICodeUnit` is declared in its `dependentcodeunits` and is reached exclusively through `Other/Resources/DependentCodeUnits`, which is where the `Dockerfile` takes the build-result from.

## Structure

- `WebAPIContainerCodeUnit/Dockerfile` defines the image: it is based on `mcr.microsoft.com/dotnet/aspnet:8.0`, copies the build-result of `DotNetWebAPICodeUnit` (`Other/Resources/DependentCodeUnits/DotNetWebAPICodeUnit/BuildResult_DotNet_win-x64`) into `/Workspace/Application` and starts it with `dotnet /Workspace/Application/DotNetWebAPICodeUnit.dll`. A `HEALTHCHECK` calls the health-check-endpoint of the API over https.
- `Other/Examples/MinimalDockerComposeFile` contains a minimal `docker-compose.yml` and a `RunExample.py` which starts the built image locally.

## Build and test

The codeunit is built by the scripts of the CommonProjectStructure, so by the pipeline of the repository (`task bb` in the repository-root) and not by calling `docker build` directly. The scripts are `Other/Build/Build.py`, which builds the image for `linux/amd64` and `linux/arm64` and merges the BOM of `DotNetWebAPICodeUnit` into its own, and `Other/QualityCheck/Linting.py`.

This codeunit does not have testable source code (`codeunithastestablesourcecode="false"` in its `codeunit.xml`), so it has no `RunTestcases.py`.

## Run the example locally

After the build, run `Other/Examples/MinimalDockerComposeFile/RunExample.py` in its own folder to start the built image with the `docker-compose.yml` next to it, then open `http://127.0.0.1:80` in the browser.

## Further information

- Which requirements have to be fulfilled to run the scripts of this codeunit is documented in [Hints.md](./Other/Reference/ReferenceContent/Hints.md).
- How this codeunit is built is documented in [HowToBuild.md](./Other/Reference/ReferenceContent/HowToBuild.md).
