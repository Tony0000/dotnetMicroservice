FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Microservice.csproj", "./"]
RUN dotnet restore "Microservice.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservice.dll"]
