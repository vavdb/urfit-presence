**URfit Presence Tracker App**
========================

A Blazor application to track presence and availability for the bootcamp activity and users.

**Table of Contents**
-----------------

- [**Presence Tracker App**](#presence-tracker-app)
  - [**Table of Contents**](#table-of-contents)
  - [**Overview**](#overview)
  - [**Features**](#features)
  - [**Requirements**](#requirements)
  - [**Getting Started**](#getting-started)
  - [**Ruminations**](#contributing)
  - [**Contributing**](#contributing)
  - [**License**](#license)

**Overview**
------------

The Presence Tracker App is a Blazor application that allows administrators to manage available moments and the presence of individuals. Users can also login and register their intention to be present. The available people are fetched from Informer, an online accounting system, using the Kiota API client.

**Features**
------------

* Manage available moments
* Track presence of individuals
* User login and registration
* Integration with Informer online accounting system
* API client generated using Kiota

**Requirements**
---------------

*.NET 8.0 or later
* Blazor Server 
* MudBlazor library
* Entity Framework Core
* Kiota API client

**Getting Started**
-------------------

1. Clone the repository: `git clone https://github.com/vavdb/urfit-presence.git`
2. Restore the NuGet packages: `dotnet restore`
3. Run the application: `dotnet run`
4. Access the application at `https://localhost:7296/`


**Ruminations**
---------------

~~Api Client generated with NSwagStudio with https://api.informer.eu/docs/api-docs.json as endpoint.~~ 

~~Api Client generated with kiota~~
~~kiota generate --openapi https://api.informer.eu/docs/api-docs.json -l csharp -n InformerApi -c InformerClient -o ./InformerApiClient --ebc~~


npm install @openapitools/openapi-generator-cli -g

openapi-generator-cli generate -i https://api.informer.eu/docs/api-docs.json -g csharp -o InformerApiClient --library httpclient --apiDocs false --modelDocs false --apiTests false --modelTests false

**Contributing**
---------------

Contributions are welcome! Please fork the repository and submit a pull request.


**License**
----------

The Presence Tracker App is licensed under the MIT License. See the `LICENSE` file for details.

I hope this helps! Let me know if you need any further assistance.