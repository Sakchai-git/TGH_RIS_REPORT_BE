#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RIS_Api/RIS_Api.csproj", "RIS_Api/"]
RUN dotnet restore "RIS_Api/RIS_Api.csproj"
COPY . .
WORKDIR "/src/RIS_Api"
RUN dotnet build "RIS_Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RIS_Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RIS_Api.dll"]