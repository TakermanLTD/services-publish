# Takerman.Marketplace

## Migrations
On Takerman.Marketplace.Server:
dotnet ef migrations add [name] --project ../Takerman.Marketplace.Data/Takerman.Marketplace.Data.csproj
dotnet ef database update --project ../Takerman.Marketplace.Data/Takerman.Marketplace.Data.csproj
dotnet ef migrations remove

## E2E tests
npm i -g cypress
npx cypress open
cypress run --browser chrome

## Upgrade NPM packages
ncu --upgrade
npm install