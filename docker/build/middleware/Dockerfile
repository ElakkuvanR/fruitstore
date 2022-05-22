# escape=`

ARG BASE_IMAGE
ARG BUILD_IMAGE
ARG BUILD_CONFIGURATION
FROM ${BUILD_IMAGE} as build

WORKDIR /src/Middleware

COPY src/Middleware/ .

RUN dotnet restore

RUN dotnet publish -c Debug -o /out/middleware

FROM ${BASE_IMAGE} as production

WORKDIR /app

COPY --from=build /out/middleware .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "FruitStore.OrderCloud.Api.dll"]


