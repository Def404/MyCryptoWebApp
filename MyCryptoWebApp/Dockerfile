FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MyCryptoWebApp/MyCryptoWebApp.csproj", "MyCryptoWebApp/"]
RUN dotnet restore "MyCryptoWebApp/MyCryptoWebApp.csproj"
COPY . .
WORKDIR "/src/MyCryptoWebApp"
RUN dotnet build "MyCryptoWebApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MyCryptoWebApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyCryptoWebApp.dll"]
