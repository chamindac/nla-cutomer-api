FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

#  Allow swagger.
#ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 443
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/NLA.CustomerAPI.RestAPI/NLA.CustomerAPI.RestAPI.csproj", "src/NLA.CustomerAPI.RestAPI/"]
COPY ["src/NLA.CustomerAPI.Contracts/NLA.CustomerAPI.Contracts.csproj", "src/NLA.CustomerAPI.Contracts/"]
COPY ["src/NLA.CustomerAPI.Services/NLA.CustomerAPI.Services.csproj", "src/NLA.CustomerAPI.Services/"]
COPY ["src/NLA.CustomerAPI.Repositories/NLA.CustomerAPI.Repositories.csproj", "src/NLA.CustomerAPI.Repositories/"]
COPY ["src/NLA.CustomerAPI.Domains/NLA.CustomerAPI.Domains.csproj", "src/NLA.CustomerAPI.Domains/"]
RUN dotnet restore "src/NLA.CustomerAPI.RestAPI/NLA.CustomerAPI.RestAPI.csproj"
COPY . .
WORKDIR "/src/src/NLA.CustomerAPI.RestAPI"
RUN dotnet build "NLA.CustomerAPI.RestAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NLA.CustomerAPI.RestAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NLA.CustomerAPI.RestAPI.dll"]