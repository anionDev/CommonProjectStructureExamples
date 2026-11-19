# SpringAPIContainer reference

`SpringAPIContainer` packages the build-result of the codeunit `SpringAPI` into an OCI-image which uses `eclipse-temurin` as java-runtime.

The application in the container listens on port 8080. The folders `/Workspace/Configuration` (additional spring-configuration-files), `/Workspace/Data` and `/Workspace/Logs` (log-file of spring) are intended to be mounted as volumes.

An example for the usage is located in `Examples/MinimalDockerComposeFile`.
