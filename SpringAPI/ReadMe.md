# SpringAPI

## Purpose

`SpringAPI` is the demonstration-codeunit for a Spring-Boot-web-API-application. It shows which shape such a codeunit has in a repository which implements the CommonProjectStructure, not a realistic application: it provides an HTTP-API with an example-endpoint which does basic calculations, which is the same functionality as the `ExampleController` of `DotNetWebAPICodeUnit`, and a health-check-endpoint.

## Structure

The maven-project is located in `SpringAPI` and contains its testcases in its own `src/test`-folder, like `MavenCodeUnit` does: `src/main` and `src/test` in one project is the layout maven defines.

- `de.aniondev.springapi.Program` contains the entry-point.
- `de.aniondev.springapi.controller.ExampleController` provides the endpoint `GET /API/v<major-version>/ExampleController/Calculator/<function>?parameter1=<value>&parameter2=<value>`, where `<function>` is `Add`, `Sub`, `Mul` or `Div`. The major-version in the route is inserted by maven into `application.properties` (`build-helper-maven-plugin` provides it), so that a breaking change of the API gets a new route.
- `de.aniondev.springapi.services` contains the logic of the calculations behind the interface `MathService`.
- The health-check-endpoint `GET /HealthCheck` is provided by spring-boot-actuator, which is configured in `application.properties`.

The versions of the spring-dependencies are defined by the parent-pom `spring-boot-starter-parent`, so they are not declared in the dependencies themselves. The update of the dependencies does therefore not update them; the version of the parent-pom has to be updated manually.

## Build and test

The codeunit is built and tested by the scripts of the CommonProjectStructure, so by the pipeline of the repository (`task bb` in the repository-root) and not by calling maven directly. The scripts are `Other/Build/Build.py`, `Other/QualityCheck/Linting.py` and `Other/QualityCheck/RunTestcases.py`.

What they run:

- The build runs `mvn -DskipTests clean package`. The `spring-boot-maven-plugin` repackages the jar into an executable jar which contains all dependencies. Its name does not contain the version (`<finalName>` in the `pom.xml`), so that `SpringAPIContainer` can address it by a fixed path. It is stored as artifact in `Other/Artifacts/BuildResult_Maven`.
- The linting runs `mvn checkstyle:check`. The ruleset is configured in the `pom.xml`, so it belongs to the codeunit.
- The testcases are run by `mvn verify`, which also lets jacoco write its coverage-report.

## Run locally

Run `java -jar Other/Artifacts/BuildResult_Maven/SpringAPI.jar` after the build, then open for example `http://localhost:8080/API/v1/ExampleController/Calculator/Add?parameter1=2&parameter2=3.5` in the browser.

## Further information

- Which requirements have to be fulfilled to run the scripts of this codeunit is documented in [Hints.md](./Other/Reference/ReferenceContent/Hints.md).
- How this codeunit is built is documented in [HowToBuild.md](./Other/Reference/ReferenceContent/HowToBuild.md).
