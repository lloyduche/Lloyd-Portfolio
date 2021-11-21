#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Lloyd/Lloyd.csproj", "Lloyd/"]
RUN dotnet restore "Lloyd/Lloyd.csproj"
COPY . .
WORKDIR "/src/Lloyd"
RUN dotnet build "Lloyd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lloyd.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /data
COPY --from=publish /src/Lloyd/Data/JsonFile/Data.json


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lloyd.dll"]