FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SearchFight.ConsoleUI/SearchFight.ConsoleUI.csproj", "SearchFight.ConsoleUI/"]
COPY ["SearchFight.Infraestructure/SearchFight.Infraestructure.csproj", "SearchFight.Infraestructure/"]
COPY ["SearchFight.App.Core/SearchFight.App.Core.csproj", "SearchFight.App.Core/"]
RUN dotnet restore "SearchFight.ConsoleUI/SearchFight.ConsoleUI.csproj"
COPY . .
WORKDIR "/src/SearchFight.ConsoleUI"
RUN dotnet build "SearchFight.ConsoleUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SearchFight.ConsoleUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SearchFight.ConsoleUI.dll"]