


# Используйте официальный образ Microsoft как базовый
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Стадия сборки
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["API_Project1/API_Project1.csproj", "API_Project1/"]
RUN dotnet restore "API_Project1/API_Project1.csproj"
COPY . .
WORKDIR "/src/API_Project1"
RUN dotnet build "API_Project1.csproj" -c Debug -o /app/build

# Стадия публикации
FROM build AS publish
RUN dotnet publish "API_Project1.csproj" -c Debug -o /app/publish

# Стадия финального образа
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API_Project1.dll"]

