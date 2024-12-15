FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY HanhTest.sln ./
COPY ./ .

RUN dotnet restore "Hosts/WorkerService/WorkerService.csproj"

RUN dotnet build "Hosts/WorkerService/WorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hosts/WorkerService/WorkerService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkerService.dll"]
