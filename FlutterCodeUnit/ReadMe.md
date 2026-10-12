# FlutterCodeUnit

## Purpose

`FlutterCodeUnit` is the demonstration-codeunit for a Flutter-application. It shows which shape such a codeunit
has in a repository which implements the CommonProjectStructure, not a realistic application: it is a
Material-Design hello-world-application with a single page.

`FlutterCodeUnit` is built via `TFCPS_CodeUnitSpecific_Flutter` (from ScriptCollection), the same wrapper-classes
`DartLibraryCodeUnit` uses; only the build-target-list differs (see `Other/Build/Build.py`): `FlutterCodeUnit`
is built for the `linux`- and `web`-targets, `DartLibraryCodeUnit` has no native build-target at all. Unlike
`DartLibraryCodeUnit`, this codeunit's `pubspec.lock` is deliberately committed, because an application (unlike
a library) should be built and tested against one reproducible, fixed set of resolved dependency-versions.

## Structure

- `flutter_code_unit` contains the Flutter-application itself: `lib/main.dart` (the application, `MyApp` and
  `HelloWorldPage`), `test` (the widget-testcases), `linux` and `web` (the platform-specific project-files for
  the two build-targets) and `pubspec.yaml`.
- `Other` contains the scripts and the configuration which the CommonProjectStructure defines.

## Build

The codeunit is buildable by using the command `scbuildcodeunits` to build the entire product which includes
this codeunit. Note that the `linux`-build-target is built inside a docker sibling-container (`flutter build
linux`); the `web`-build-target and the quality-checks (`flutter analyze`, `flutter test`) run directly on the
host.

## Further information

- Which requirements have to be fulfilled to run the scripts of this codeunit is documented in [Hints.md](./Other/Reference/ReferenceContent/Hints.md).
