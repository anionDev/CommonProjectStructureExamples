# PythonCodeUnit

## Purpose

`PythonCodeUnit` is the demonstration-codeunit for a python-package. It shows which shape such a codeunit has in a repository which implements the CommonProjectStructure, not a realistic package: it provides two example-functions and one commandline-executable per function.

The package is not published anywhere. It exists to be copied as the starting-point of a real python-codeunit.

## Structure

The package is located in `PythonCodeUnit` and its testcases are located in `PythonCodeUnitTests`, which is the layout the CommonProjectStructure defines.

- `PythonCodeUnitCore.py` contains the functions. They are separated from the commandline-interface so that they are testable without running an executable.
- `Executables.py` contains one function per commandline-executable. Each of them only parses the arguments and calls the corresponding function of `PythonCodeUnitCore`. Which executable is installed under which name is declared in `setup.cfg`.

## Build and test

The codeunit is built and tested by the scripts of the CommonProjectStructure, so by the pipeline of the repository (`task bb` in the repository-root). The scripts are `Other/Build/Build.py`, `Other/QualityCheck/Linting.py` and `Other/QualityCheck/RunTestcases.py`.

What they run:

- The build creates the wheel of the package and stores it as artifact in `Other/Artifacts/BuildResult_Wheel`.
- The linting runs `pylint`. The ruleset comes from the `.pylintrc`-file of the repository if there is one.
- The testcases are run by `pytest` and the coverage is measured by `coverage`, which writes its report in the cobertura-format. The html-report, the badges and the check of the coverage-threshold are generated from that report.

## Install locally

Install the built wheel with `pip install --force-reinstall Other/Artifacts/BuildResult_Wheel/PythonCodeUnit-<version>-py3-none-any.whl`. After that the executables of the package are available on the commandline.

## Further information

- Which requirements have to be fulfilled to run the scripts of this codeunit is documented in [Hints.md](./Other/Reference/ReferenceContent/Hints.md).
- How this codeunit is built is documented in [HowToBuild.md](./Other/Reference/ReferenceContent/HowToBuild.md).
