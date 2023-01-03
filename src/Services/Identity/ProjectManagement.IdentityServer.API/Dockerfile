FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Identity/ProjectManagement.IdentityServer.API/ProjectManagement.IdentityServer.API.csproj", "src/Services/Identity/ProjectManagement.IdentityServer.API/"]
COPY ["src/Services/Identity/ProjectManagement.IdentityServer.BLL/ProjectManagement.IdentityServer.BLL.csproj", "src/Services/Identity/ProjectManagement.IdentityServer.BLL/"]
COPY ["src/Services/Identity/ProjectManagement.IdentityServer.DAL/ProjectManagement.IdentityServer.DAL.csproj", "src/Services/Identity/ProjectManagement.IdentityServer.DAL/"]
COPY ["src/BuildingBlocks/ProjectManagement.Infrastructure.Shared/ProjectManagement.Infrastructure.Shared.csproj", "src/BuildingBlocks/ProjectManagement.Infrastructure.Shared/"]
COPY ["src/BuildingBlocks/ProjectManagement.Domain.Shared/ProjectManagement.Domain.Shared.csproj", "src/BuildingBlocks/ProjectManagement.Domain.Shared/"]
COPY ["src/BuildingBlocks/ProjectManagement.Auth.JWT/ProjectManagement.Auth.JWT.csproj", "src/BuildingBlocks/ProjectManagement.Auth.JWT/"]
COPY ["src/BuildingBlocks/ProjectManagement.Utils/ProjectManagement.Utils.csproj", "src/BuildingBlocks/ProjectManagement.Utils/"]
RUN dotnet restore "src/Services/Identity/ProjectManagement.IdentityServer.API/ProjectManagement.IdentityServer.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Identity/ProjectManagement.IdentityServer.API"
RUN dotnet build "ProjectManagement.IdentityServer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectManagement.IdentityServer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectManagement.IdentityServer.API.dll"]