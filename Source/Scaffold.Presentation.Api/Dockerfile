FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Source/Scaffold.Presentation.Api/Scaffold.Presentation.Api.csproj", "Source/Scaffold.Presentation.Api/"]
RUN dotnet restore "Source/Scaffold.Presentation.Api/Scaffold.Presentation.Api.csproj"
COPY . .
WORKDIR "/src/Source/Scaffold.Presentation.Api"
RUN dotnet build "Scaffold.Presentation.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Scaffold.Presentation.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Scaffold.Presentation.Api.dll"]