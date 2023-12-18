FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NetCore.Microservices.Services.OrderApi/NetCore.Microservices.Services.OrderApi.csproj", "NetCore.Microservices.Services.OrderApi/"]
RUN dotnet restore "NetCore.Microservices.Services.OrderApi/NetCore.Microservices.Services.OrderApi.csproj"
COPY . .
WORKDIR "/src/NetCore.Microservices.Services.OrderApi"
RUN dotnet build "NetCore.Microservices.Services.OrderApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NetCore.Microservices.Services.OrderApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCore.Microservices.Services.OrderApi.dll"]
