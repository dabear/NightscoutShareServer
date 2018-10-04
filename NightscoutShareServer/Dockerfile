FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet NightscoutShareServer.dll
