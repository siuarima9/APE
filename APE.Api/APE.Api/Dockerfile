#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
WORKDIR /src
COPY ["APE.Api/APE.Api/APE.Api.csproj", "APE.Api/APE.Api/"]
COPY ["APE.Infra.IoC/APE.Infra.IoC/APE.Infra.IoC.csproj", "APE.Infra.IoC/APE.Infra.IoC/"]
COPY ["APE.Domain/APE.Domain/APE.Domain.csproj", "APE.Domain/APE.Domain/"]
COPY ["APE.Infra/APE.Infra/APE.Infra.csproj", "APE.Infra/APE.Infra/"]
COPY ["APE.AppService/APE.AppService/APE.Application.csproj", "APE.AppService/APE.AppService/"]
RUN dotnet restore "APE.Api/APE.Api/APE.Api.csproj"
COPY . .
WORKDIR "/src/APE.Api/APE.Api"
RUN dotnet build "APE.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APE.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APE.Api.dll"]