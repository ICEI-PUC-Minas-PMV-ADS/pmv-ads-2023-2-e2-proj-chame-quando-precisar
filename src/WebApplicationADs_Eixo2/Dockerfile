
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY ["WebApplicationADs_Eixo2/WebApplicationADs_Eixo2.csproj", "WebApplicationADs_Eixo2/"]
RUN dotnet restore "WebApplicationADs_Eixo2/WebApplicationADs_Eixo2.csproj"
COPY . .
WORKDIR /app
RUN dotnet build "WebApplicationADs_Eixo2/WebApplicationADs_Eixo2.csproj" -c Release -o /app/build
RUN dotnet tool install --global dotnet-ef --version 3.1
ENV PATH="$PATH:/root/.dotnet/tools"
#RUN dotnet ef migrations add InitialCreate
#RUN dotnet ef database update

FROM build AS publish
RUN dotnet publish "WebApplicationADs_Eixo2/WebApplicationADs_Eixo2.csproj" -c Release -o /app/publish /p:UseAppHost=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish ./
ENTRYPOINT ["dotnet", "WebApplicationADs_Eixo2.dll"]