# Tennis opdracht V2.0

This is a school project for AP.

A manegement tool for a tennis club.

Add members add matches.

## Requirements
* Dotnet 5
* mssql
* Windows (for the WPF application)

## Installation

1. Clone or download this repository
2. cd in the project directory

### Using in the command line

1. Run command `dotnet restore`
2. cd in `Tennis.Web`
3. run command `dotnet run` for running it in debug mode

### Creating the WPF (Windows only)

1. Run `dotnet restore`
2. Run `dotnet build`
3. The builed versuin should be in `Tennis.App/bin/debug/netcoreapp3.1`

## Configuration

in `appsettings.json` in the section `ConnectionStrings`

Change the value in `connection`

in the following ways.

1. `"Server=[SERVER_NAME];Database=[DATABASE_NAME];uid=[USER_NAME];password=[USER_PASSWORD];"`
2. `"Server=.;Database=[DATABASE_NAME];Trusted_Connection=True;MultipleActiveResultSets=True;Integrated Security=true;"`

## Inline querry

The inline querry is in the `Gender repository`

## Usage

[Here](usage.md)

## Contrubution

This is a solo project so there are no need for contrubution
