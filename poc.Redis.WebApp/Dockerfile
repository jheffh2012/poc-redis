#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["poc.Redis.WebApp.csproj", "poc.Redis.WebApp/"]
RUN dotnet restore "poc.Redis.WebApp/poc.Redis.WebApp.csproj"
WORKDIR "/src/poc.Redis.WebApp"
COPY . .
RUN dotnet build "poc.Redis.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "poc.Redis.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "poc.Redis.WebApp.dll"]