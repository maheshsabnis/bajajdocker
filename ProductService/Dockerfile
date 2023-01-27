ARG ARCH=amd64
ARG TAG=6.0-bullseye-slim-$ARCH
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY ./ProductService.csproj .
RUN dotnet restore
COPY . .
WORKDIR /source/
RUN dotnet publish -c release -o /app --no-restore
FROM mcr.microsoft.com/dotnet/aspnet:$TAG
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "ProductService.dll"]
