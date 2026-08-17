# Hints

## Requirements

The following tools are required to build this codeunit:

- `docfx`
- `git`
- `mvn`
- `python`
- `reportgenerator`
- `scriptcollection`

A java-development-kit in the version which the `maven.compiler.release`-property of the `pom.xml` declares must be available as well.

The linting, the bill-of-materials and the coverage-measurement are implemented by maven-plugins which are declared in the `pom.xml`, so they are downloaded by maven itself and do not have to be installed separately.

## IDE

The recommended IDE for this codeunit is [Visual Studio Code](https://code.visualstudio.com/) with the [Extension Pack for Java](https://marketplace.visualstudio.com/items?itemName=vscjava.vscode-java-pack).
