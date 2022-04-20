#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["AdminAccessFightBooking/AdminAccessFightBooking.csproj", "AdminAccessFightBooking/"]
RUN dotnet restore "AdminAccessFightBooking/AdminAccessFightBooking.csproj"
COPY . .
WORKDIR "/src/AdminAccessFightBooking"
RUN dotnet build "AdminAccessFightBooking.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdminAccessFightBooking.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdminAccessFightBooking.dll"]