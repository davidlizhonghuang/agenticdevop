FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "src/AgenticDemo/AgenticDemo.csproj"
RUN dotnet publish "src/AgenticDemo/AgenticDemo.csproj" -c Release -o /app/publish
FROM build AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AgenticDemo.dll"]
