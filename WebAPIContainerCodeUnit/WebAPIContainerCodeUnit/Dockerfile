FROM mcr.microsoft.com/dotnet/aspnet:7.0

RUN mkdir /Workspace \
  && mkdir /Workspace/Data \
  && mkdir /Workspace/Configuration \
  && mkdir /Workspace/Logs

ADD ./Other/Resources/DependentCodeUnits/WebAPIContainerCodeUnit/BuildResult_DotNet_win-x64 /Workspace/Application

WORKDIR /Workspace/Application
ENTRYPOINT ["dotnet", "/Workspace/Application/WebAPIContainerCodeUnit.dll"]
