FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["API-Context/API-Context.csproj", "API-Context/"]
RUN dotnet restore "API-Context/API-Context.csproj"
COPY . .
WORKDIR "/src/API-Context"
RUN dotnet build "API-Context.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API-Context.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API-Context.dll"]
