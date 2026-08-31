# How to build

This codeunit contains one c++-project, which is located in `src`. It consists of a small static library
(`cpplibrary.cpp` and `include/cpplibrary.h`) which exposes one example-function through a c-linkage api
(`extern "C"`), so that a plain c-codeunit (see `CExecutable`) can use it without having to deal with c++
name-mangling.

The build (`Other/Build/Build.py`) uses `TFCPS_CodeUnitSpecific_CPP` (from ScriptCollection) to compile `src`
for the linux-target only, inside a docker-container (the "Debian"-image defined in
`.ScriptCollection/OCIImages/ImageDefinition.csv`, with `g++` and `make` installed into it first): it runs
`make` in `src`, which produces `build/libcpplibrary.a`. That file and `include/cpplibrary.h` are published
together as the `BuildResult_Linux`-artifact of this codeunit, because a codeunit which depends on this one
needs both to compile against it.

The codeunit is buildable by using the command `scbuildcodeunits` to build the entire product which includes
this codeunit.
