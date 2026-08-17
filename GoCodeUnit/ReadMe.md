# GoCodeUnit

## Purpose

`GoCodeUnit` is the demonstration-codeunit for a go-project. It shows which shape such a codeunit has in a repository which implements the CommonProjectStructure, not a realistic application: it is a commandline-application which prints a greeting.

## Structure

The go-module is located in `GoCodeUnit`. The functions are in `utilities.go` and the entry-point is in `main.go`, so that the functions are testable without running the application.

The testcases are part of the same module and not of a sibling-project `<codeunit>Tests`, because that is the layout go defines: the testcases of a file live in a `_test.go`-file next to it.

## Build and test

The codeunit is built and tested by the scripts of the CommonProjectStructure, so by the pipeline of the repository (`task bb` in the repository-root) and not by calling go directly. The scripts are `Other/Build/Build.py`, `Other/QualityCheck/Linting.py` and `Other/QualityCheck/RunTestcases.py`.

What they run:

- The build runs `go build` and stores the resulting executable as artifact in `Other/Artifacts/BuildResult_Go`.
- The linting runs `go vet` and additionally verifies that every file is formatted as `gofmt` formats it. `gofmt -l` only prints the files which are not formatted and exits successfully either way, so its output is evaluated instead of its exit-code.
- The testcases are run by `go test -coverprofile`. The resulting coverprofile is converted into the cobertura-format, because that is the format from which the html-report, the badges and the check of the coverage-threshold are generated.

## Run locally

Run `go run . <name>` in the folder `GoCodeUnit`. Without an argument the application greets the world.

## Further information

- Which requirements have to be fulfilled to run the scripts of this codeunit is documented in [Hints.md](./Other/Reference/ReferenceContent/Hints.md).
- How this codeunit is built is documented in [HowToBuild.md](./Other/Reference/ReferenceContent/HowToBuild.md).
