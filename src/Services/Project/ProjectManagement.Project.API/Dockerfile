#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Project/ProjectManagement.Project.API/ProjectManagement.Project.API.csproj", "src/Services/Project/ProjectManagement.Project.API/"]
COPY ["src/BuildingBlocks/ProjectManagement.Auth.JWT/ProjectManagement.Auth.JWT.csproj", "src/BuildingBlocks/ProjectManagement.Auth.JWT/"]
COPY ["src/BuildingBlocks/ProjectManagement.Utils/ProjectManagement.Utils.csproj", "src/BuildingBlocks/ProjectManagement.Utils/"]
COPY ["src/BuildingBlocks/ProjectManagement.API.Shared/ProjectManagement.API.Shared.csproj", "src/BuildingBlocks/ProjectManagement.API.Shared/"]
RUN dotnet restore "src/Services/Project/ProjectManagement.Project.API/ProjectManagement.Project.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Project/ProjectManagement.Project.API"
RUN dotnet build "ProjectManagement.Project.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectManagement.Project.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectManagement.Project.API.dll"]