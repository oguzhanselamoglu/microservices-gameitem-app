#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Ordering/Game.Ordering.Api/Game.Ordering.Api.csproj", "Services/Ordering/Game.Ordering.Api/"]
COPY ["Services/Ordering/Game.Ordering.Application/Game.Ordering.Application.csproj", "Services/Ordering/Game.Ordering.Application/"]
COPY ["Services/Ordering/Game.Ordering.Domain/Game.Ordering.Domain.csproj", "Services/Ordering/Game.Ordering.Domain/"]
COPY ["Services/Ordering/Game.Ordering.Infrastructure/Game.Ordering.Infrastructure.csproj", "Services/Ordering/Game.Ordering.Infrastructure/"]
RUN dotnet restore "Services/Ordering/Game.Ordering.Api/Game.Ordering.Api.csproj"
COPY . .
WORKDIR "/src/Services/Ordering/Game.Ordering.Api"
RUN dotnet build "Game.Ordering.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Game.Ordering.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Game.Ordering.Api.dll"]
