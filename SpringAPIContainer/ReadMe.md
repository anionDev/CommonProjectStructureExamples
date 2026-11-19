# SpringAPIContainer

## Purpose

`SpringAPIContainer` is the demonstration-codeunit for a containerized Spring-Boot-web-API. It shows which shape such a codeunit has in a repository which implements the CommonProjectStructure, not a realistic deployment: it packages the build-result of `SpringAPI`, another codeunit of this repository, into an OCI-image. It is the java-counterpart of `WebAPIContainerCodeUnit`.

This codeunit has no source-code of its own. `SpringAPI` is declared in its `dependentcodeunits` and is reached exclusively through `Other/Resources/DependentCodeUnits`, which is where the `Dockerfile` takes the build-result from.

## Structure

- `SpringAPIContainer/Dockerfile` defines the image: it is based on `eclipse-temurin` as java-runtime, copies the executable jar of `SpringAPI` (`Other/Resources/DependentCodeUnits/SpringAPI/BuildResult_Maven/SpringAPI.jar`) into `/Workspace/Application` and starts it with `java -jar`. A `HEALTHCHECK` calls the health-check-endpoint of the API through `HealthCheck.sh`, which sends the request with the tcp-redirection of bash, because the base-image contains neither `curl` nor `wget`.
- The base-image is not written into the `Dockerfile` but declared as `ARG image_java`: the build passes the address of every image of `.ScriptCollection/OCIImages/ImageDefinition.csv` as argument `image_<imagename in lowercase>`, so the version of the java-runtime is defined by the entry `Java` there.
- `Other/Reference/ReferenceContent/Examples/MinimalDockerComposeFile` contains a minimal `docker-compose.yml` and a `RunExample.py` which starts the built image locally.

## Build and test

The codeunit is built by the scripts of the CommonProjectStructure, so by the pipeline of the repository (`task bb` in the repository-root) and not by calling `docker build` directly. The scripts are `Other/Build/Build.py`, which builds the image for `linux/amd64` and `linux/arm64`, and `Other/QualityCheck/Linting.py`.

This codeunit does not have testable source code (`codeunithastestablesourcecode="false"` in its `codeunit.xml`), so it has no `RunTestcases.py`.

## Run the example locally

After the build, run `Other/Reference/ReferenceContent/Examples/MinimalDockerComposeFile/RunExample.py` in its own folder to start the built image with the `docker-compose.yml` next to it, then open `http://127.0.0.1:80/API/v1/ExampleController/Calculator/Add?parameter1=2&parameter2=3.5` in the browser.

## Further information

- Which requirements have to be fulfilled to run the scripts of this codeunit is documented in [Hints.md](./Other/Reference/ReferenceContent/Hints.md).
- How this codeunit is built is documented in [HowToBuild.md](./Other/Reference/ReferenceContent/HowToBuild.md).
