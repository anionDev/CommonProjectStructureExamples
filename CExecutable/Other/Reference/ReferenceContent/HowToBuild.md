# How to build

This codeunit contains one c-project, which is located in `src`: a single `main.c` which prints the message it
gets from `cpplibrary_get_example_message()` (declared in `cpplibrary.h`, implemented by the dependent codeunit
`CPPLibrary`).

The build (`Other/Build/Build.py`) uses `TFCPS_CodeUnitSpecific_CPP` (from ScriptCollection) to compile `src`
for the linux-target only, inside a docker-container (the "Debian"-image defined in
`.ScriptCollection/OCIImages/ImageDefinition.csv`, with `g++` and `make` installed into it first - `g++` and
not only `gcc`, because linking against CPPLibrary's static library needs `libstdc++`).

Before the build runs, `CommonTasks.py` (via `do_common_tasks_base`, because `CPPLibrary` is declared in
`CExecutable.codeunit.xml`'s `dependentcodeunits`) copies the whole `Other/Artifacts`-folder of `CPPLibrary`
into `Other/Resources/DependentCodeUnits/CPPLibrary` of this codeunit. `src/Makefile` compiles and links
`main.c` against `Other/Resources/DependentCodeUnits/CPPLibrary/BuildResult_Linux/libcpplibrary.a`, using the
header published next to it in the same folder. The resulting binary is published as this codeunit's own
`BuildResult_Linux`-artifact.

The codeunit is buildable by using the command `scbuildcodeunits` to build the entire product which includes
this codeunit; `CPPLibrary` is then built first automatically, because `scbuildcodeunits` builds codeunits in
dependency-order.
