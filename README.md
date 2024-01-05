# Agada .NET Client

[![Agada Dotnet CI](https://github.com/Agada-Tech/agada-dotnet-client/actions/workflows/agada-dotnet-build.yml/badge.svg?branch=main)](https://github.com/Agada-Tech/agada-dotnet-client/actions/workflows/agada-dotnet-build.yml)
[![NuGet](https://img.shields.io/nuget/v/Agada.svg)](https://www.nuget.org/packages/Agada/)
[![Gitpod ready-to-code](https://img.shields.io/badge/Gitpod-ready--to--code-blue?logo=gitpod)](https://gitpod.io/#https://github.com/Agada-Tech/agada-dotnet-client)

## Requirements
- .NET Framework 4.6+
- .NET Core 1.1+
- .NET Core 2.0+

## Installation
```bash
Install-Package Agada
```

## Usage
To access the Agada API, you'll first need to obtain API credentials via an API key. If you don't already have an Agada account, you can sign up at [https://one.agada.io/](https://one.agada.io).

Once you've obtained your API credentials, you can start using Agada by instantiating an `AgadaClient` with your credentials.

```dotnet
var agadaOptions = new AgadaOptions(AgadaEnvironment.Production, "<API-KEY>", "<CULTURE>", "<CHANNEL-NAME>");
var client = new AgadaClient(agadaOptions);
```

## Examples
Included in the project are a number of examples that cover almost all use-cases. Refer to [the `Samples/` folder](./Samples)] for more info.

### Running the Examples
If you've cloned this repo on your development machine and wish to run the examples you can run an example with the command `dotnet test`

### Feed Event Use Case
Let's quickly review an example where we implement a Feed Event scenario.

```dotnet
await client.Hub.SendEventAsync(new SendEventRequest
{
  Event = "test-event",
  UserId = "<UNIQUE-USER-ID>",
  SessionId = "<SESSION-ID>",
  Metadata = new Dictionary<string, object>
  {
    {"total", 100},
    {"currency", "USD"},
    {"location", "Istanbul"},
  }
}, cancellationToken);
```
### Contributions
For all contributions to this client, please see the contribution guide [here](CONTRIBUTING.md).

## License
MIT
