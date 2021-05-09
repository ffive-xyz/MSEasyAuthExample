# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY dotnetAsp/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY dotnetAsp ./
RUN dotnet publish -c Release -o out -r linux-x64 -p:PublishSingleFile=true --self-contained true

# Build runtime image
FROM nginx
WORKDIR /app
COPY --from=build-env /app/out /app
COPY frontend /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
COPY entrypoint.sh /
RUN chmod +x /entrypoint.sh
ENTRYPOINT ["/entrypoint.sh"]
