#!/bin/bash
# The base-image "eclipse-temurin" contains neither curl nor wget, so the request is sent through the
# tcp-redirection of bash, which avoids installing an additional package into the image only for this purpose.
set -o errexit
set -o pipefail

exec 3<>/dev/tcp/127.0.0.1/8080
printf 'GET /HealthCheck HTTP/1.0\r\nHost: 127.0.0.1\r\n\r\n' >&3
response=$(cat <&3)
exec 3>&-
echo "$response"
# spring-boot-actuator answers with statuscode 200 only if the application is healthy.
echo "$response" | head -n 1 | grep --quiet " 200 "
