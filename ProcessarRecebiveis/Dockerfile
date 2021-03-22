FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProcessarRecebiveis.csproj", "./"]
RUN dotnet restore "ProcessarRecebiveis.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ProcessarRecebiveis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProcessarRecebiveis.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProcessarRecebiveis.dll"]
