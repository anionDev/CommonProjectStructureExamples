# SpringAPI-reference

`SpringAPI` is the demonstration-codeunit for a Spring-Boot-web-API-application. It provides an HTTP-API with an example-endpoint which does basic calculations, and a health-check-endpoint.

## Endpoints

- `GET /API/v<major-version>/ExampleController/Calculator/<function>?parameter1=<value>&parameter2=<value>` applies `<function>` (`Add`, `Sub`, `Mul` or `Div`) to both values and returns the result. Decimal-places are separated by a dot. An unknown function and a division by zero are answered with statuscode 400.
- `GET /HealthCheck` returns the health-state of the application, provided by spring-boot-actuator.

The application listens on port 8080.
