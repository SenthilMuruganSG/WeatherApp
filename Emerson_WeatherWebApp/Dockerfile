#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Emerson_WeatherApp/Emerson_WeatherApp.csproj", "Emerson_WeatherApp/"]
RUN dotnet restore "Emerson_WeatherApp/Emerson_WeatherApp.csproj"
COPY . .
WORKDIR "/src/Emerson_WeatherApp"
RUN dotnet build "Emerson_WeatherApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Emerson_WeatherApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Emerson_WeatherApp.dll"]