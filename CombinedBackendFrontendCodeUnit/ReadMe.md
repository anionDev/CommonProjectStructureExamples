# CombinedBackendFrontendCodeUnit

## Purpose

`CombinedBackendFrontendCodeUnit` is the demonstration-codeunit for serving a backend-server-application and a frontend-web-application together behind one reverse-proxy. It shows which shape such a codeunit has in a repository which implements the CommonProjectStructure, not a realistic deployment: it packages the build-results of `DotNetWebAPICodeUnit` and `AngularCodeUnit`, two other codeunits of this repository, into a single OCI-image.

This codeunit has no source-code of its own. `DotNetWebAPICodeUnit` and `AngularCodeUnit` are declared in its `dependentcodeunits` and are reached exclusively through `Other/Resources/DependentCodeUnits`, which is where the `Dockerfile` takes their build-results from.

## Structure

- `CombinedBackendFrontendCodeUnit/Dockerfile` defines the image: it is based on `nginx:latest`, copies the build-result of `DotNetWebAPICodeUnit` (`Other/Resources/DependentCodeUnits/DotNetWebAPICodeUnit/BuildResult_DotNet_win-x64`) into `/Workspace/Backend/Application` and the build-result of `AngularCodeUnit` (`Other/Resources/DependentCodeUnits/AngularCodeUnit/BuildResult_Website`) into `/Workspace/Frontend/Application`, and copies `nginx.configuration` and `EntryPoint.sh` into the image.
- `CombinedBackendFrontendCodeUnit/nginx.configuration` is the nginx-configuration which is meant to route requests to the backend and to the frontend depending on the route.
- `CombinedBackendFrontendCodeUnit/EntryPoint.sh` is the entrypoint of the container.
- `Other/Examples/MinimalDockerComposeFile` contains a minimal `docker-compose.yml` and a `RunExample.py` which starts the built image locally.

**Known limitation:** this codeunit is not finished yet. `EntryPoint.sh` currently only contains a `#TODO start nginx` placeholder and does not start nginx, and `nginx.configuration` contains the two unresolved placeholder-tokens `__.httpserverconfiguration.__` and `__.httpsserverconfiguration.__` which something would have to substitute with the actual backend-/frontend-routing before nginx could parse the file. The `Dockerfile` also still has a `#TODO set healthcheck` instead of a `HEALTHCHECK` instruction. Until these TODOs are resolved, the built image does not actually serve anything.

## Build and test

The codeunit is built by the scripts of the CommonProjectStructure, so by the pipeline of the repository (`task bb` in the repository-root) and not by calling `docker build` directly. The scripts are `Other/Build/Build.py`, which builds the image for `linux/amd64` and `linux/arm64`, and `Other/QualityCheck/Linting.py`.

This codeunit does not have testable source code (`codeunithastestablesourcecode="false"` in its `codeunit.xml`), so it has no `RunTestcases.py`.

## Run the example locally

After the build, run `Other/Examples/MinimalDockerComposeFile/RunExample.py` in its own folder to start the built image with the `docker-compose.yml` next to it, then open `http://127.0.0.1:80` in the browser. See the known limitation above: as long as the entrypoint and the nginx-configuration are not finished, the container will not actually serve the backend or the frontend.

## Further information

- Which requirements have to be fulfilled to run the scripts of this codeunit is documented in [Hints.md](./Other/Reference/ReferenceContent/Hints.md).
- How this codeunit is built is documented in [HowToBuild.md](./Other/Reference/ReferenceContent/HowToBuild.md).
