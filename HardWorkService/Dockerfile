FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY ./*.sln .
COPY ./HardWorkService.API/*.csproj ./HardWorkService.API/
COPY ./HardWorkService/*.csproj ./HardWorkService/
COPY ./HardWorkService.Interface/*.csproj ./HardWorkService.Interface/
COPY ./HardWorkService.Test/*.csproj ./HardWorkService.Test/
RUN dotnet restore

# copy everything else and build app
COPY ./HardWorkService.API/. ./HardWorkService.API/
COPY ./HardWorkService/. ./HardWorkService/
COPY ./HardWorkService.Interface/. ./HardWorkService.Interface/
WORKDIR /app/HardWorkService.API
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/HardWorkService.API/out ./
ENTRYPOINT ["dotnet", "HardWorkService.API.dll"]