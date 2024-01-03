FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
ARG GH_USER_NAME
ARG GH_AUTH_TOKEN
ARG GH_NUGET_SOURCE_URL
WORKDIR /src
RUN dotnet nuget add source -u $GH_USER_NAME -p $GH_AUTH_TOKEN -n github --store-password-in-clear-text $GH_NUGET_SOURCE_URL
COPY ["NetCore.Microservices.Services.ShoppingCartApi/NetCore.Microservices.Services.ShoppingCartApi.csproj", "NetCore.Microservices.Services.ShoppingCartApi/"]
RUN dotnet restore "NetCore.Microservices.Services.ShoppingCartApi/NetCore.Microservices.Services.ShoppingCartApi.csproj"
COPY . .
WORKDIR "/src/NetCore.Microservices.Services.ShoppingCartApi"
RUN dotnet build "NetCore.Microservices.Services.ShoppingCartApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NetCore.Microservices.Services.ShoppingCartApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCore.Microservices.Services.ShoppingCartApi.dll"]
