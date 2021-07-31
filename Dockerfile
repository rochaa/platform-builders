FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
COPY . /app

WORKDIR /app/src/PBuilders.WebAPI
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app/dll
COPY --from=build-env /app/src/PBuilders.WebAPI/out /app/dll

ENV ASPNETCORE_ENVIRONMENT=Development

CMD ["dotnet", "PBuilders.WebAPI.dll"]