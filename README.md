# Platform Builders Test

## Services
1. Check word is palindromo
2. Play with Bynary Search Tree

## Pattners
> Principles -> DDD and KISS

## Requirements

> .Net 6.0 -> https://dotnet.microsoft.com/download/dotnet/6.0

> Docker -> https://docs.docker.com/desktop/

## Local tests (docker)

> docker build -f Dockerfile -t pbuilder:latest .

> docker run --rm -d -p 6333:80 pbuilder

## Local tests (dotnet)

> dotnet restore

> dotnet publish -c Release -o out

> dotnet out/PBuilder.WebAPI.dll

## Swagger / Open API

> {{url}}/swagger

## Local automated tests

> dotnet test -v n