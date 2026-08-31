# CPPLibrary

## Purpose

`CPPLibrary` is the demonstration-codeunit for a c++-library. It shows which shape such a codeunit has in a
repository which implements the CommonProjectStructure, not a realistic library: it provides one
example-function, exposed through a c-linkage api so that it can also be used by a plain c-codeunit (see
`CExecutable`, which depends on this codeunit and uses its build-artifact).

Unlike the other example-codeunits, `CPPLibrary` is built via `TFCPS_CodeUnitSpecific_CPP` (from
ScriptCollection) instead of a codeunit-type-specific automation: there is no single, universal c++-build-tool
the way `cargo` is for Rust, so which command builds the codeunit is configured in `Other/Build/Build.py`
itself. `CPPLibrary` is built for linux only, and always inside a docker-container, so the build is
reproducible independent of the operating-system of the machine which builds it.

## Structure

- `src` contains the c++-sourcecode (`cpplibrary.cpp`, `include/cpplibrary.h`) and the `Makefile` which compiles it.
- `Other` contains the scripts and the configuration which the CommonProjectStructure defines.

## Build

The codeunit is buildable by using the command `scbuildcodeunits` to build the entire product which includes
this codeunit.

## Further information

- Which requirements have to be fulfilled to run the scripts of this codeunit is documented in [Hints.md](./Other/Reference/ReferenceContent/Hints.md).
- How this codeunit is built is documented in [HowToBuild.md](./Other/Reference/ReferenceContent/HowToBuild.md).
