# CommunityDragon.NET
A .NET library for fetching data from [CommunityDragon](https://communitydragon.org) written completely in C#.

[![GitHub](https://img.shields.io/github/license/craftersmine/League.CommunityDragon?color=darklime)](/LICENSE) 
[![Nuget](https://img.shields.io/nuget/v/craftersmine.League.CommunityDragon?logo=nuget)](https://www.nuget.org/packages/craftersmine.League.CommunityDragon) 
[![Nuget](https://img.shields.io/nuget/dt/craftersmine.League.CommunityDragon?label=nuget%20downloads&logo=nuget)](https://www.nuget.org/packages/craftersmine.League.CommunityDragon) 
[![GitHub Releases](https://img.shields.io/github/downloads/craftersmine/League.CommunityDragon/total?label=github%20downloads&logo=github)](https://github.com/craftersmine/SteamGridDB.NET/releases)
[![GitHub Project Wiki](https://img.shields.io/badge/docs-github--wiki-brightgreen)](https://github.com/craftersmine/League.CommunityDragon/wiki)
![Discord](https://img.shields.io/badge/discord-craftersmine-5865f2?logo=discord&logoColor=white)
![GitHub Repo stars](https://img.shields.io/github/stars/craftersmine/League.CommunityDragon)
![Maintenance](https://img.shields.io/maintenance/yes/2023)

## Supports:
* [x] Summoner icons
* [x] Summoner icon sets
* [ ] Challenges
* [ ] Champion summaries
* [ ] TFT companions
* [ ] Discord Rich Presense texts
* [ ] Event shops
* [ ] Generic Client assets
* [ ] Hextech loot
* [ ] Hextech loot milestones
* [ ] Maps metadata
* [ ] Missions metadata
* [ ] Rune and stats icons
* [ ] League game queues metadata
* [ ] Banners
* [ ] Skinlines
* [ ] Skins
* [ ] Statstones (Mastery)
* [ ] Clash banners
* [ ] Ward skin sets
* [ ] Ward skins
* [ ] Emotes
* [ ] Summoner spells
* [ ] Clash trophies
* [ ] Game modes icons and loading screens
* [x] Items
* [ ] Universes metadata

If you want a new feature for library [create new feature request issue](https://github.com/craftersmine/League.CommunityDragon.NET/issues/new?assignees=&labels=enhancement&template=feature_request.md&title=)

## Installation:
* Search for `craftersmine.League.CommunityDragon` in NuGet explorer in Visual Studio (or your IDE)
* Using NuGet Package Manager: ```PM> Install-Package craftersmine.League.CommunityDragon```
* Download NuGet package from [Releases](https://github.com/craftersmine/League.CommunityDragon/releases) page and put it in your [Local NuGet Feed](https://docs.microsoft.com/en-us/nuget/hosting-packages/overview)
* Download packaged binaries from [Releases](https://github.com/craftersmine/League.CommunityDragon/releases) and link DLL Assembly to your project

## Usage:
* Add `using craftersmine.League.CommunityDragon` directive
* Instantiate new object of type `CommunityDragon` with required game version and game locale