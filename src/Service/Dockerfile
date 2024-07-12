FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Service/Service.csproj", "src/Service/"]
COPY ["src/HtmlFormatter/HtmlFormatter.csproj", "src/HtmlFormatter/"]
COPY ["src/Persistence/Persistence.fsproj", "src/Persistence/"]
COPY ["src/Logic/Logic.csproj", "src/Logic/"]
COPY ["src/EmailSender/EmailSender.csproj", "src/EmailSender/"]
COPY ["src/Api/Api.csproj", "src/Api/"]
RUN dotnet restore "src/Service/Service.csproj"
COPY . .
WORKDIR "/src/src/Service"
RUN dotnet build "Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Service.dll"]
