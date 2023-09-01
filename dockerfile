# FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
# WORKDIR /app
# COPY *.csproj .
# # RUN dotnet restore
# COPY . .
# # RUN dotnet build -c Release -o /out
# CMD ["dotnet", "test"]
# # FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
# # WORKDIR /app
# # COPY --from=build /out .
# # ENTRYPOINT ["dotnet", "","InflueriAutomationCore.dll"]



FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY *.csproj .
COPY . .
RUN dotnet build -c Release -o /out
CMD ["dotnet", "test"]
