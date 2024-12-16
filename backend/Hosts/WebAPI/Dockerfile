FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY backend/HanhTest.sln ./
COPY ./ .

RUN dotnet restore "backend/Hosts/WebAPI/WebAPI.csproj"

RUN dotnet build "backend/Hosts/WebAPI/WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "backend/Hosts/WebAPI/WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]
