# DotNetWebAPIClientCodeUnit reference

`DotNetWebAPIClientCodeUnit` is the demonstration-codeunit for a C#-client that uses another codeunit of the same repository: it is the client for `DotNetWebAPICodeUnit`, which it reaches exclusively through `Other/Resources/DependentCodeUnits`.

The client is implemented in `DotNetWebAPIClientCodeUnit.Core.DotNetWebAPIClient`, which wraps `GRYLibrary`'s `GenericAPIClient` and exposes the server's calculator-endpoint as `Add`.
