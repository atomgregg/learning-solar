FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ATG.Utils.csproj", "src/"]
RUN dotnet restore "src/ATG.Utils.csproj"

COPY . .
WORKDIR /src
RUN dotnet build "ATG.Utils.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ATG.Utils.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ATG.Utils.dll"]