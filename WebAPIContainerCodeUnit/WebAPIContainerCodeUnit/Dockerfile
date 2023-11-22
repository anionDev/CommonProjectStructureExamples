FROM mcr.microsoft.com/dotnet/aspnet:7.0

RUN mkdir /Workspace \
  && mkdir /Workspace/Data \
  && mkdir /Workspace/Configuration \
  && mkdir /Workspace/Logs

ADD ./Other/Resources/DependentCodeUnits/DotNetWebAPICodeUnit/BuildResult_DotNet_win-x64 /Workspace/Application

WORKDIR /Workspace/Application
HEALTHCHECK CMD curl --insecure --fail https://localhost:443/HealthCheck
ENTRYPOINT ["dotnet", "/Workspace/Application/DotNetWebAPICodeUnit.dll"]
