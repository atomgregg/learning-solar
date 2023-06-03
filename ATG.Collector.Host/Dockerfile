FROM mcr.microsoft.com/dotnet/runtime:7.0.5-alpine3.17-amd64 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /ATG
COPY ["ATG.Collector.Host/ATG.Collector.Host.csproj", "ATG.Collector.Host/"]
COPY ["ATG.Collector.Types/ATG.Collector.Types.csproj", "ATG.Collector.Types/"]
COPY ["ATG.Collector.Source/ATG.Collector.Source.csproj", "ATG.Collector.Source/"]
RUN dotnet restore "ATG.Collector.Host/ATG.Collector.Host.csproj"

COPY . .
WORKDIR "/ATG/ATG.Collector.Host"
RUN dotnet build "ATG.Collector.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ATG.Collector.Host.csproj" -c Release -o /app/publish

FROM base AS final
LABEL maintainer="Aaron Gregg <atomgregg@outlook.com>"
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ATG.Collector.Host.dll"]



# FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
# WORKDIR /ATG.Collector.Host

# # copy everything
# # restore as distinct layers
# # build and publish a release
# COPY . ./
# RUN dotnet restore
# RUN dotnet publish -c Release -o out

# # build runtime image
# FROM mcr.microsoft.com/dotnet/runtime:7.0.5-alpine3.17-amd64
# WORKDIR /ATG.Collector.Host
# COPY --from=build-env /ATG.Collector.Host/out .
# ENTRYPOINT ["dotnet", "ATG.Collector.Host.dll"]