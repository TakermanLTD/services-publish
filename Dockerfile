FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV ASPNETCORE_ENVIRONMENT=Production
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN apt-get update
RUN apt-get install -y curl gnupg
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -fsSL https://deb.nodesource.com/nsolid_setup_deb.sh | sh -s 20
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -fsSL https://deb.nodesource.com/nsolid_setup_deb.sh | sh -s 20
RUN apt-get install -y nodejs
ARG BUILD_CONFIGURATION=Release
RUN --mount=type=secret,id=NUGET_PASSWORD export NUGET_PASSWORD=$(cat /run/secrets/NUGET_PASSWORD) && echo $NUGET_PASSWORD

WORKDIR /src

COPY Takerman.Publishing.Tests/. ./Takerman.Publishing.Tests/

COPY ["takerman.publishing.client/nuget.config", "./"]
COPY ["takerman.publishing.client/nuget.config", "takerman.publishing.client/"]

RUN dotnet nuget add source https://nuget.pkg.github.com/takermanltd/index.json -n github -u takerman --store-password-in-clear-text -p ${NUGET_PASSWORD} 
RUN dotnet nuget list source

COPY ["Takerman.Publishing.Server/Takerman.Publishing.Server.csproj", "Takerman.Publishing.Server/"]
COPY ["takerman.publishing.client/takerman.publishing.client.esproj", "takerman.publishing.client/"]
COPY ["takerman.publishing.client/package.json", "package.json"]
COPY . .

RUN echo //npm.pkg.github.com/:_authToken=$NUGET_PASSWORD >> ~/.npmrc
RUN echo @takermanltd:registry=https://npm.pkg.github.com/ >> ~/.npmrc
RUN echo "user.email=tivanov@takerman.net" > .npmrc
RUN echo "user.name=takerman" > .npmrc
RUN echo "user.username=takerman" > .npmrc
RUN npm install --production
# RUN npm ci

WORKDIR "/src/Takerman.Publishing.Server"
RUN dotnet clean "./Takerman.Publishing.Server.csproj"
RUN dotnet restore "./Takerman.Publishing.Server.csproj"
RUN dotnet build "./Takerman.Publishing.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet test "./Takerman.Publishing.Server.csproj"
RUN rm -f .npmrc

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Takerman.Publishing.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Takerman.Publishing.Server.dll"]