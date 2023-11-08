FROM nginx:latest

COPY CombinedBackendFrontendCodeUnit/nginx.configuration /etc/nginx
ADD CombinedBackendFrontendCodeUnit/EntryPoint.sh /Workspace/Other/EntryPoint/EntryPointScript.sh
ADD Other/Resources/DependentCodeUnits/DotNetWebAPICodeUnit/BuildResult_DotNet_win-x64 /Workspace/Backend/Application
ADD Other/Resources/DependentCodeUnits/AngularCodeUnit/BuildResult_Website /Workspace/Frontend/Application
#TODO set healthckeck
WORKDIR /usr/src/app
ENTRYPOINT ["/Workspace/Other/EntryPoint/EntryPointScript.sh"]