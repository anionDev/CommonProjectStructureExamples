# MavenCodeUnit-reference

`MavenCodeUnit` is the demonstration-codeunit for a maven-project. It provides a commandline-application which prints a greeting.

The functions which are not bound to the commandline-interface are located in `de.aniondev.mavencodeunit.Utilities`, so that they are testable without running the application; `de.aniondev.mavencodeunit.Program` only contains the entry-point.
