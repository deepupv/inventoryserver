#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["InventoryServer/InventoryServer.csproj", "InventoryServer/"]
RUN dotnet restore "InventoryServer/InventoryServer.csproj"
COPY . .
WORKDIR "/src/InventoryServer"
RUN dotnet build "InventoryServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InventoryServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InventoryServer.dll"]