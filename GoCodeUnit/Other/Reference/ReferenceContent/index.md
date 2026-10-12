# GoCodeUnit-reference

`GoCodeUnit` is the demonstration-codeunit for a go-project. It provides a commandline-application which prints a greeting.

The functions which are not bound to the commandline-interface are located in `utilities.go`, so that they are testable without running the application; `main.go` only contains the entry-point.
