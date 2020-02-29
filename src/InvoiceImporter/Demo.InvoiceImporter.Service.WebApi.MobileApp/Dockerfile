#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/InvoiceImporter/Demo.InvoiceImporter.Service.WebApi.MobileApp/Demo.InvoiceImporter.Service.WebApi.MobileApp.csproj", "src/InvoiceImporter/Demo.InvoiceImporter.Service.WebApi.MobileApp/"]
RUN dotnet restore "src/InvoiceImporter/Demo.InvoiceImporter.Service.WebApi.MobileApp/Demo.InvoiceImporter.Service.WebApi.MobileApp.csproj"
COPY . .
WORKDIR "/src/src/InvoiceImporter/Demo.InvoiceImporter.Service.WebApi.MobileApp"
RUN dotnet build "Demo.InvoiceImporter.Service.WebApi.MobileApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo.InvoiceImporter.Service.WebApi.MobileApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.InvoiceImporter.Service.WebApi.MobileApp.dll"]