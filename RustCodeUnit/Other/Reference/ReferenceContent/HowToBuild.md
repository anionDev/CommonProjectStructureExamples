# How to build

This codeunit contains one cargo-project, which is located in `RustCodeUnit`. It consists of a library, which contains the functions, and a binary, which contains the entry-point and uses the library. The testcases are part of the same project, which is the layout cargo defines.

The codeunit is buildable by using the command `scbuildcodeunits` to build the entire product which includes this codeunit.
