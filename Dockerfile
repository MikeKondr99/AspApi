FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY AspApi.csproj .
RUN dotnet restore AspApi.csproj
COPY . .
RUN dotnet build AspApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish AspApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AspApi.dll"]