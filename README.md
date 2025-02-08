# Takerman.Publish

## Migrations
On Takerman.Publish.Server:
dotnet ef migrations add [name] --project ../Takerman.Publish.Data/Takerman.Publish.Data.csproj
dotnet ef database update --project ../Takerman.Publish.Data/Takerman.Publish.Data.csproj
dotnet ef migrations remove

## E2E tests
npm i -g cypress
npx cypress open
cypress run --browser chrome

## Upgrade NPM packages
ncu --upgrade
npm install


## Mixing
social networks
get 15 music tracks from YouTube or Spotify or another platform
get movie trailers or scenes with the min length of the length of the music, randomize them, combine them, cut as the length of the music
combine music and video
add fade in with very short logo intro and fade out effect
if is possible add moviemix logo to the bottom of the screen
generate good description with or without AI and add the important links and hashtags in it
add hashtags in the video
generate standard good, interesting video title
publish the video to the YouTube channel
make automatic posts to the social networks and to the website
