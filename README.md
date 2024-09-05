# Takerman.Publishing

## Migrations
On Takerman.Publishing.Server:
dotnet ef migrations add [name] --project ../Takerman.Publishing.Data/Takerman.Publishing.Data.csproj
dotnet ef database update --project ../Takerman.Publishing.Data/Takerman.Publishing.Data.csproj
dotnet ef migrations remove

## E2E tests
npm i -g cypress
npx cypress open
cypress run --browser chrome

## Upgrade NPM packages
ncu --upgrade
npm install