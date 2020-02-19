#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Example.RealTimeService/Example.RealTimeService.csproj", "Example.RealTimeService/"]
RUN dotnet restore "Example.RealTimeService/Example.RealTimeService.csproj"
COPY . .
WORKDIR "/src/Example.RealTimeService"
RUN dotnet build "Example.RealTimeService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Example.RealTimeService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.RealTimeService.dll"]