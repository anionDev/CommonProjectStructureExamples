# CPPLibrary-reference

`CPPLibrary` is the demonstration-codeunit for a c++-library which is compiled with `TFCPS_CodeUnitSpecific_CPP`
(from ScriptCollection) instead of a codeunit-type-specific automation, because there is no single, universal
c++-build-tool. It provides one example-function (`cpplibrary_get_example_message`) through a c-linkage api, so
that it can also be used from a plain c-codeunit (see `CExecutable`, which depends on this codeunit).

`CPPLibrary` is built for linux only, and always inside a docker-container, so the build is reproducible
independent of the operating-system of the machine which builds it.
