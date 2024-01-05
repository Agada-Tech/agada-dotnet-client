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
To access the Agada API you'll first need to obtain API credentials via API key If you don't already have a Agada account, you can signup at [https://one.agada.io/](https://one.agada.io)

Once you've obtained your API credentials, you can start using Agada by instantiating a `Agada` with your credentials.

```dotnet

var agadaOptions = new AgadaOptions(AgadaEnvironment.Production, "<API-KEY>", "<CULTURE>", "<CHANNEL-NAME>");
var client = new AgadaClient(agadaOptions);
```


### Contributions
For all contributions to this client please see the contribution guide [here](CONTRIBUTING.md).

## License
MIT
