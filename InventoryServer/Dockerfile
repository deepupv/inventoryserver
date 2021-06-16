#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

EXPOSE 50051
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["InventoryServer.csproj", ""]
RUN dotnet restore "InventoryServer.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "InventoryServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InventoryServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InventoryServer.dll"]