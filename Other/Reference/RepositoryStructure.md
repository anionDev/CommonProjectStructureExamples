# Repository-structure

## Codeunits

This repository has code-modules called "codeunit"s.
Every codeunit has an only subfolder.
A codeunit-folder can only be on the root-level of the repository.
A codeunit-folder can be identified by a `<codeunitname>.codeunit.xml`-file which is contained in the codeunit-folder.
For each codeunit there are certain files which will be executed on `scbuildcodeunits` in this order:

- `<codeunit-folder>/Other/CommonTasks.py`
- `<codeunit-folder>/Other/Build/Build.py`
- `<codeunit-folder>/Other/QualityCheck/Linting.py`
- `<codeunit-folder>/Other/QualityCheck/RunTestcases.py`
- `<codeunit-folder>/Other/Reference/GenerateReference.py`

When a change is fully implemented, an acceptance criteria is always that these scripts must  be runnable without any error in that order (because sometimes they depend on each other).
This can be used as test if the implementation was correct.
