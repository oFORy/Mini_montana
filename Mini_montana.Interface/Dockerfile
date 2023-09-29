#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Mini_montana.Interface/Mini_montana.Interface.csproj", "Mini_montana.Interface/"]
COPY ["Mini_montana.Application/Mini_montana.Application.csproj", "Mini_montana.Application/"]
COPY ["Mini_montana/Mini_montana.Domain.csproj", "Mini_montana/"]
COPY ["Mini_montana.Infrastructure/Mini_montana.Infrastructure.csproj", "Mini_montana.Infrastructure/"]
RUN dotnet restore "Mini_montana.Interface/Mini_montana.Interface.csproj"
COPY . .
WORKDIR "/src/Mini_montana.Interface"
RUN dotnet build "Mini_montana.Interface.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mini_montana.Interface.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mini_montana.Interface.dll"]