---
name: product-knowledge
description: What CommonProjectStructureExamples is, how this repository is structured and which mechanisms exist for building and testing it. Use this before fixing a defect or developing a feature in this repository, to know where things belong and how to verify a change.
---

# CommonProjectStructureExamples

This repository contains one example-code-unit per programming-language and project-type. It is the reference
which is copied from when a new code-unit is created somewhere, and it is what a code-unit is compared with
when it behaves differently than expected.

That purpose decides everything else about this repository: **the examples are minimal on purpose.** They show
the *shape* of a code-unit (its `codeunit.xml`, all its scripts, its folder-structure, its reference-content),
not a realistic product. Content is only added here when it demonstrates a mechanism which somebody else has
to copy.

## Structure of the repository

The repository follows the "common project structure" itself. Use the
`work-with-common-project-structure`-skill when you need the details of that structure.

The code-units are, among others: `DotNetLibraryCodeUnit`, `DotNetConsoleCodeUnit`, `DotNetWebAPICodeUnit`,
`DotNetWebAPIClientCodeUnit`, `AngularCodeUnit`, `CombinedBackendFrontendCodeUnit`, `PythonCodeUnit`,
`MavenCodeUnit`, `RustCodeUnit` and the image-definitions `WebAPIContainerCodeUnit` and
`WebAppContainerCodeUnit`.

`DotNetWebAPICodeUnit` is the biggest one, because it demonstrates the mechanisms which a real backend needs:
a database with both supported database-types (MariaDB and PostgreSQL) behind an `ISQLProvider`, an
`IPersistence` with a transient implementation, a business-logic-service, and the corresponding test-structure
(persistence-tests written against the interface, database-tests, business-logic-tests). It is the same shape
as in ConSurv, OpenDMS and RSSArchivist - deliberately, so that the example and the real products do not
drift apart.

## When something is changed here

A change here is a change of a template: whoever copies this example afterwards gets it. So prefer the
mechanism which the real products use, and if the example must deviate from them, say why in a comment.

The reverse holds as well: when a mechanism changes in the real products (a new script, a new element in the
`codeunit.xml`, a different way of doing something), the example has to follow, otherwise the next code-unit
which is created from it starts outdated.

## Building

`scbuildcodeunits` builds everything: compile, tests, linting and security-checks. The task `task bb`
(`BaseBuildAllCodeunits`) does the same. Since the examples are what everybody else copies, a warning in this
repository is worth more attention than in a product-repository.
