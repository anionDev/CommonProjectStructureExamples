FROM nginx:latest

ADD ./Other/Resources/DependentCodeUnits/AngularCodeUnit/BuildResult_WebApplication/browser /usr/share/nginx/html
HEALTHCHECK CMD curl --insecure --fail https://localhost:443
