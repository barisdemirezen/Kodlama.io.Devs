# Kodlama IO Devs 🎉

Kodlama IO Devs is a practice project to learn CQRS and many .Net best practices. Project gets updates as followed course named "Senior Yazılım Geliştirici Yetiştirme Kampı (.NET)" by instructor "Engin Demiroğ" assigns new homeworks.

## About it 📝

Projects includes many best practices supported by core solution projects. We are able to see Cqrs with MediatR, mappings, global exception handling, fluent validations, layered architecture and middlewares.

## Install, run, dev 🏗️

- Clone repository to your local machine
- Set your startup project as *Kodlama.io.Devs*
- Start the project

## Environment Variables ♻️

You can edit *DbString* in *appsettings.json* to connect your database.

**Example appsettings.json**

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DbString": "Server=(localdb)\\MSSQLLocalDB;Database=KodlamaIo; Trusted_Connection=True;"
  }
}
```
## Tech Stack 🔥

**Languages:** C#

**Server:** IISExpress, Kestrel

**Data Store:** Microsoft Sql Server

**Packages:** Entity Framework Core, Automapper, Fluent Validation, MediatR

## Relational Projects 🗃️

Please check out "nArchitecure" which is a reference project.

[nArchitecture](https://github.com/engindemirog/nArchitecture)


## Badges 📌


![](https://img.shields.io/github/last-commit/barisdemirezen/kodlama.io.devs/master?style=for-the-badge)

![](https://img.shields.io/badge/.NET%206-brightgreen.svg?style=for-the-badge)

![](https://img.shields.io/badge/CQRS-blue.svg?style=for-the-badge)