FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/AggregationApp.API/AggregationApp.API.csproj", "src/AggregationApp.API/"]
RUN dotnet restore "src/AggregationApp.API/AggregationApp.API.csproj"
COPY . .
WORKDIR "/src/src/AggregationApp.API"
RUN dotnet build "AggregationApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AggregationApp.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AggregationApp.API.dll"]