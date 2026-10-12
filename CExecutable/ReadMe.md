# CExecutable

## Purpose

`CExecutable` is the demonstration-codeunit for a c-executable which depends on another codeunit. It shows
which shape such a codeunit has in a repository which implements the CommonProjectStructure, not a realistic
application: it is a commandline-application which prints the example-message it gets from `CPPLibrary`, the
c++-library this codeunit depends on (declared in `CExecutable.codeunit.xml`'s `dependentcodeunits`).

Like `CPPLibrary`, `CExecutable` is built via `TFCPS_CodeUnitSpecific_CPP` (from ScriptCollection) instead of a
codeunit-type-specific automation. `CExecutable` is built for linux only, and always inside a docker-container,
so the build is reproducible independent of the operating-system of the machine which builds it.

## Structure

- `src` contains the c-sourcecode (`main.c`) and the `Makefile` which compiles and links it against `CPPLibrary`.
- `Other` contains the scripts and the configuration which the CommonProjectStructure defines.

## Build

The codeunit is buildable by using the command `scbuildcodeunits` to build the entire product which includes
this codeunit; `CPPLibrary` is then built first automatically, because `scbuildcodeunits` builds codeunits in
dependency-order.

## Further information

- Which requirements have to be fulfilled to run the scripts of this codeunit is documented in [Hints.md](./Other/Reference/ReferenceContent/Hints.md).
- How this codeunit is built is documented in [HowToBuild.md](./Other/Reference/ReferenceContent/HowToBuild.md).
