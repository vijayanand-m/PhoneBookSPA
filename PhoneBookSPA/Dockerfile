#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY PhoneBookSPA/PhoneBookSPA.csproj PhoneBookSPA/
COPY PhoneBookSPA.Entities/PhoneBookSPA.Entities.csproj PhoneBookSPA.Entities/
COPY PhoneBookSPA.Interface/PhoneBookSPA.Interface.csproj PhoneBookSPA.Interface/
COPY PhoneBookSPA.Services/PhoneBookSPA.Services.csproj PhoneBookSPA.Services/
RUN dotnet restore "PhoneBookSPA/PhoneBookSPA.csproj"
COPY . .
WORKDIR "/src/PhoneBookSPA"
RUN dotnet build "PhoneBookSPA.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PhoneBookSPA.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhoneBookSPA.dll"]
