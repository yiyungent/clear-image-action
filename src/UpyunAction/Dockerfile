#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/UpyunAction/UpyunAction.csproj", "src/UpyunAction/"]
RUN dotnet restore "src/UpyunAction/UpyunAction.csproj"
COPY . .
WORKDIR "/src/src/UpyunAction"
RUN dotnet build "UpyunAction.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UpyunAction.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# 注意: 由于 GitHub Actions 会设置 GITHUB_WORKSPACE 为工作目录, 因此使用绝对路径
ENTRYPOINT ["dotnet", "/app/UpyunAction.dll"]