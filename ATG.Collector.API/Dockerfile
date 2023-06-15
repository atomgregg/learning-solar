FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-preview-alpine AS build
ARG TARGETARCH
WORKDIR /source
EXPOSE 80

# copy csproj and restore as distinct layers
COPY src/ATG.Collector.API.csproj .
RUN dotnet restore -a $TARGETARCH

# copy everything else and build app
COPY src/. .
RUN dotnet publish -a $TARGETARCH --no-restore -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview-alpine

# these ENVs are only needed because our API uses .NET 7
ENV DOTNET_ROLL_FORWARD=Major
ENV DOTNET_ROLL_FORWARD_PRE_RELEASE=1

WORKDIR /app
COPY --from=build /app .

USER $APP_UID
ENTRYPOINT ["./ATG.Collector.API"]