FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/Services/Pedidos/Pedidos.Api/Pedidos.Api.csproj", "src/Services/Pedidos/Pedidos.Api/"]
COPY ["src/Services/Pedidos/Pedidos.Infrastructure.IoC/Pedidos.Infrastructure.IoC.csproj", "src/Services/Pedidos/Pedidos.Infrastructure.IoC/"]
COPY ["src/Services/Pedidos/Pedidos.Infrastructure/Pedidos.Infrastructure.csproj", "src/Services/Pedidos/Pedidos.Infrastructure/"]
COPY ["src/Services/Pedidos/Pedidos.Domain/Pedidos.Domain.csproj", "src/Services/Pedidos/Pedidos.Domain/"]
COPY ["src/Services/Pedidos/Pedidos.Application/Pedidos.Application.csproj", "src/Services/Pedidos/Pedidos.Application/"]
RUN dotnet restore "src/Services/Pedidos/Pedidos.Api/Pedidos.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Pedidos/Pedidos.Api"
RUN dotnet build "Pedidos.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pedidos.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pedidos.Api.dll"]