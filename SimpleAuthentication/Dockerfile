#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SimpleAuthentication/SimpleAuthentication.csproj", "SimpleAuthentication/"]
COPY ["SimpleAuthenticationData/SimpleAuthenticationData.csproj", "SimpleAuthenticationData/"]
COPY ["SimpleAuthenticationDomain/SimpleAuthenticationDomain.csproj", "SimpleAuthenticationDomain/"]
RUN dotnet restore "SimpleAuthentication/SimpleAuthentication.csproj"
COPY . .
WORKDIR "/src/SimpleAuthentication"
RUN dotnet build "SimpleAuthentication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleAuthentication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleAuthentication.dll"]