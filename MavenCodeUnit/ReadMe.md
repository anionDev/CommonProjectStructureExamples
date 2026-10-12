# MavenCodeUnit

## Purpose

`MavenCodeUnit` is the demonstration-codeunit for a maven-project. It shows which shape such a codeunit has in a repository which implements the CommonProjectStructure, not a realistic application: it is a commandline-application which prints a greeting.

## Structure

The maven-project is located in `MavenCodeUnit` and contains its testcases in its own `src/test`-folder. It therefore deviates from the codeunits of this repository which put their testcases into a sibling-project `<codeunit>Tests`: `src/main` and `src/test` in one project is the layout maven defines, and it is also the layout jacoco measures the coverage of without further configuration.

## Build and test

The codeunit is built and tested by the scripts of the CommonProjectStructure, so by the pipeline of the repository (`task bb` in the repository-root) and not by calling maven directly. The scripts are `Other/Build/Build.py`, `Other/QualityCheck/Linting.py` and `Other/QualityCheck/RunTestcases.py`.

What they run:

- The build runs `mvn -DskipTests clean package`, so that a failing testcase is reported by the quality-check and not by the build. The resulting jar is executable and is stored as artifact in `Other/Artifacts/BuildResult_Maven`.
- The linting runs `mvn checkstyle:check`. The ruleset is configured in the `pom.xml`, so it belongs to the codeunit.
- The testcases are run by `mvn verify`, which also lets jacoco write its coverage-report. That report is converted into the cobertura-format afterwards, because that is the format from which the html-report, the badges and the check of the coverage-threshold are generated.

## Run locally

Run `java -jar Other/Artifacts/BuildResult_Maven/MavenCodeUnit-<version>.jar <name>` after the build. Without an argument the application greets the world.

## Further information

- Which requirements have to be fulfilled to run the scripts of this codeunit is documented in [Hints.md](./Other/Reference/ReferenceContent/Hints.md).
- How this codeunit is built is documented in [HowToBuild.md](./Other/Reference/ReferenceContent/HowToBuild.md).
