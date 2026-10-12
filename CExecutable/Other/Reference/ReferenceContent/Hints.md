# Hints

## Requirements

The following tools are required to build this codeunit:

- `docker`
- `docfx`
- `git`
- `python`
- `scriptcollection`

No local c-compiler is required on the building machine: the codeunit is built exclusively for linux and always
inside a docker-container (see [HowToBuild.md](./HowToBuild.md)), so `gcc` and `make` only have to be present
inside that container, not on the host.

## IDE

The recommended IDE for this codeunit is [Visual Studio Code](https://code.visualstudio.com/) with the
[C/C++-extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.cpptools).
