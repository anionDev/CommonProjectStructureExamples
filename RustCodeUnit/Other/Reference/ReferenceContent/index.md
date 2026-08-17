# RustCodeUnit-reference

`RustCodeUnit` is the demonstration-codeunit for a rust-project. It provides a commandline-application which prints a greeting.

The functions which are not bound to the commandline-interface are located in the library `rust_code_unit` (`src/lib.rs`), so that they are testable without running the application; the binary (`src/main.rs`) only contains the entry-point.
