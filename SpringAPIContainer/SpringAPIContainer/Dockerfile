# The base-image is the java-runtime "eclipse-temurin". Its address is passed by the build as argument "image_java",
# which is defined by the entry "Java" in ".ScriptCollection/OCIImages/ImageDefinition.csv".
ARG image_java
FROM ${image_java}

RUN mkdir /Workspace \
  && mkdir /Workspace/Data \
  && mkdir /Workspace/Configuration \
  && mkdir /Workspace/Logs \
  && mkdir /Workspace/Other

COPY ./Other/Resources/DependentCodeUnits/SpringAPI/BuildResult_Maven/SpringAPI.jar /Workspace/Application/SpringAPI.jar
COPY ./SpringAPIContainer/HealthCheck.sh /Workspace/Other/HealthCheck.sh
RUN chmod +x /Workspace/Other/HealthCheck.sh

# Spring reads additional configuration-files (for example "application.properties") from the configuration-folder
# and writes its log-file into the logs-folder, so that both can be mounted as volume.
ENV SPRING_CONFIG_ADDITIONAL_LOCATION=optional:file:/Workspace/Configuration/
ENV LOGGING_FILE_PATH=/Workspace/Logs

WORKDIR /Workspace/Application
EXPOSE 8080
HEALTHCHECK --interval=30s --timeout=10s --start-period=1m CMD /Workspace/Other/HealthCheck.sh
ENTRYPOINT ["java", "-jar", "/Workspace/Application/SpringAPI.jar"]
