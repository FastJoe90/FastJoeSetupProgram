# FastJoeSetupProgram

FastJoeSetupProgram is a simple desktop tool for managing and saving racecar setup data..

This repo contains two projects:
- `FastJoeSetupProgram` — core model and utilities (.NET 8)
- `DigitalCrewChiefUI` — WPF front-end that consumes the core library (.NET 10)

What this build does
- Stores per-corner chassis data and shock settings.
- UI allows editing compression and adjusting rebound by clicks (click range: 0..-26).

Quick start
1. Install .NET SDK 8.0 and 10.0 (desktop workload for WPF).
2. Build from the solution root:
   `dotnet build DigitalCrewChiefUI\DigitalCrewChiefUI.csproj`
3. Run the WPF app from Visual Studio or:
   `dotnet run --project DigitalCrewChiefUI\DigitalCrewChiefUI.csproj`

Notes
- Save files are plain text for now and include a compact export of shock valving. Consider switching to JSON for better interoperability.
- Need to fix Shocks to properly save Rebound values (Was holding off for when I switched to JSON.)
- ToDo: Switch saving to JSON. Implement all properties of my Component classes (Tire, Shock, CarCorner). 
- ToDo: Consider ways to add more layers to the UI, itself.

Contributing
Open an issue or submit a PR — small focused changes are easiest to review.
