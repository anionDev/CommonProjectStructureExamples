# RustCodeUnit

## Purpose

`RustCodeUnit` is the demonstration-codeunit for a rust-project. It shows which shape such a codeunit has in a repository which implements the CommonProjectStructure, not a realistic application: it is a commandline-application which prints a greeting.

## Structure

The cargo-project is located in `RustCodeUnit` and consists of a library (`src/lib.rs`), which contains the functions, and a binary (`src/main.rs`), which contains the entry-point and uses the library. That split exists so that the functions are testable without running the application.

The testcases are part of the same project and not of a sibling-project `<codeunit>Tests`, because that is the layout cargo defines: unit-tests live next to the code they test and integration-tests live in the `tests`-folder of the project.

## Build and test

The codeunit is built and tested by the scripts of the CommonProjectStructure, so by the pipeline of the repository (`task bb` in the repository-root) and not by calling cargo directly. The scripts are `Other/Build/Build.py`, `Other/QualityCheck/Linting.py` and `Other/QualityCheck/RunTestcases.py`.

What they run:

- The build runs `cargo build --release` and stores the resulting executable as artifact in `Other/Artifacts/BuildResult_Rust`.
- The linting runs `cargo clippy --all-targets --all-features -- -D warnings`. A warning of clippy therefore fails the linting, because a warning is a linting-issue too.
- The testcases are run by `cargo llvm-cov`, which writes its coverage-report in the cobertura-format directly, so no conversion of the report-format is required. The html-report, the badges and the check of the coverage-threshold are generated from that report.

## Run locally

Run `cargo run -- <name>` in the folder `RustCodeUnit`. Without an argument the application greets the world.

## Further information

- Which requirements have to be fulfilled to run the scripts of this codeunit is documented in [Hints.md](./Other/Reference/ReferenceContent/Hints.md).
- How this codeunit is built is documented in [HowToBuild.md](./Other/Reference/ReferenceContent/HowToBuild.md).
