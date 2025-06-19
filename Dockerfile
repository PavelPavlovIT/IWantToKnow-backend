FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG TARGETARCH
WORKDIR /source

COPY src/IWantKnowNet.Api/*.csproj ./IWantKnowNet.Api/
COPY src/IWantKnowNet.Data/*.csproj ./IWantKnowNet.Data/

RUN dotnet restore ./IWantKnowNet.Api/IWantKnowNet.Api.csproj -a $TARGETARCH

COPY src/IWantKnowNet.Api/. ./IWantKnowNet.Api/.
COPY src/IWantKnowNet.Data/. ./IWantKnowNet.Data/.
RUN dotnet publish ./IWantKnowNet.Api/IWantKnowNet.Api.csproj --no-restore -a $TARGETARCH -o /app


FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine

EXPOSE 8080

ENV \
    DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
    LC_ALL=en_US.UTF-8 \
    LANG=en_US.UTF-8
RUN apk add --no-cache \
    icu-data-full \
    icu-libs

WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet","./IWantKnowNet.Api.dll"]
