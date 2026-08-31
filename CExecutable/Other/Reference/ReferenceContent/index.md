# CExecutable-reference

`CExecutable` is the demonstration-codeunit for a c-executable which depends on another codeunit
(`CPPLibrary`, a c++-library) and uses its build-artifact. It is a commandline-application which prints the
example-message it gets from `CPPLibrary`.

Like `CPPLibrary`, `CExecutable` is compiled with `TFCPS_CodeUnitSpecific_CPP` (from ScriptCollection) instead
of a codeunit-type-specific automation. It is built for linux only, and always inside a docker-container, so
the build is reproducible independent of the operating-system of the machine which builds it.
