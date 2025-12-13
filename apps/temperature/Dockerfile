FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS temperature-build

WORKDIR /source
COPY . .

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS temperature-server

WORKDIR /app
COPY --from=temperature-build /app/publish .
ENTRYPOINT ["dotnet", "Temperature.dll"]





