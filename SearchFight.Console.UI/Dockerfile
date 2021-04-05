#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SearchFight.Console.UI/SearchFight.Console.UI.csproj", "SearchFight.Console.UI/"]
COPY ["SearchFight.Infraestructure/SearchFight.Infraestructure.csproj", "SearchFight.Infraestructure/"]
COPY ["SearchFight.App.Core/SearchFight.App.Core.csproj", "SearchFight.App.Core/"]
RUN dotnet restore "SearchFight.Console.UI/SearchFight.Console.UI.csproj"
COPY . .
WORKDIR "/src/SearchFight.Console.UI"
RUN dotnet build "SearchFight.Console.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SearchFight.Console.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SearchFight.Console.UI.dll"]