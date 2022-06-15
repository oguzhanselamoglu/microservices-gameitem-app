#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Services/IdentityServer/Identity.Api/Identity.Api.csproj", "Services/IdentityServer/Identity.Api/"]
COPY ["Frameworks/GameStore.Infrastructure/GameStore.Infrastructure.csproj", "Frameworks/GameStore.Infrastructure/"]
RUN dotnet restore "Services/IdentityServer/Identity.Api/Identity.Api.csproj"
COPY . .
WORKDIR "/src/Services/IdentityServer/Identity.Api"
RUN dotnet build "Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.Api.dll"]
