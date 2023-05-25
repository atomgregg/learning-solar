FROM mcr.microsoft.com/dotnet/runtime:7.0.5-alpine3.17-amd64 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /ATG
COPY ["ATG.Utils/ATG.Utils.csproj", "ATG.Utils/"]
RUN dotnet restore "ATG.Utils/ATG.Utils.csproj"

COPY . .
WORKDIR "/ATG/ATG.Utils"
RUN dotnet build "ATG.Utils.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ATG.Utils.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ATG.Utils.dll"]