FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY SimpleGuestbookMariaDb/*.csproj ./SimpleGuestbookMariaDb/
COPY SimpleGuestbookMariaDb.Tests/*.csproj ./SimpleGuestbookMariaDb.Tests/
RUN dotnet restore

# copy everything else and build app
COPY SimpleGuestbookMariaDb/. ./SimpleGuestbookMariaDb/
COPY SimpleGuestbookMariaDb.Tests/. ./SimpleGuestbookMariaDb.Tests/
WORKDIR /source/SimpleGuestbookMariaDb
RUN dotnet publish -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "SimpleGuestbookMariaDb.dll"]