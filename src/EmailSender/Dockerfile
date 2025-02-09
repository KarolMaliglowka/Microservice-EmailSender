FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 4040
ENV ASPNETCORE_URLS=http://*:4040

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/EmailSender/EmailSender.csproj", "src/EmailSender/"]
RUN dotnet restore "src/EmailSender/EmailSender.csproj"
COPY . .
WORKDIR "/src/src/EmailSender"
RUN dotnet build "EmailSender.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EmailSender.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmailSender.dll"]
