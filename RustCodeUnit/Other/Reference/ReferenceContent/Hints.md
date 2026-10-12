# Hints

## Requirements

The following tools are required to build this codeunit:

- `cargo` (including `rustc` and `clippy`, which are part of a usual rust-installation)
- `cargo-cyclonedx` (installable with `cargo install cargo-cyclonedx`)
- `cargo-llvm-cov` (installable with `cargo install cargo-llvm-cov`)
- `docfx`
- `git`
- `python`
- `reportgenerator`
- `scriptcollection`

`cargo-llvm-cov` additionally requires the rust-component `llvm-tools-preview`, which is installable with `rustup component add llvm-tools-preview`.

## IDE

The recommended IDE for this codeunit is [Visual Studio Code](https://code.visualstudio.com/) with the [rust-analyzer-extension](https://marketplace.visualstudio.com/items?itemName=rust-lang.rust-analyzer).
