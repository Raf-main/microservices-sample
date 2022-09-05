# Microservices sample

    Console.WriteLine("Hello");

## About The Project

Sample project with microservice architecture

## Status

Development

![](https://st.depositphotos.com/1760000/4498/i/600/depositphotos_44984037-stock-photo-3d-people-build-a-house.jpg)

## Technology stack

![C#](https://img.shields.io/badge/-C_Sharp-239120?style=flat-square&logo=csharp) ![.NET](https://img.shields.io/badge/-.NET-512BD4?style=flat-square&logo=.NET) ![TypeScript](https://img.shields.io/badge/-TypeScript-white?style=flat-square&logo=typescript&color=white) ![Angular](https://img.shields.io/badge/-Angular-DD0031?style=flat-square&logo=Angular) ![Microsoft Sql Server](https://img.shields.io/badge/-Microsoft_Sql_Server-DD0031?style=flat-square&logo=microsoftsqlserver) ![MongoDB](https://img.shields.io/badge/-MongoDB-white?style=flat-square&logo=mongodb) ![RabbitMQ](https://img.shields.io/badge/-RabbitMQ-white?style=flat-square&logo=rabbitmq) ![Docker](https://img.shields.io/badge/-Docker-white?style=flat-square&logo=docker)

Project architecture

-  Microservice architecture

| Service  | Description |
| --- | --- |
| Identity | Responsible for users authentication |
| Project  | Responsible for managing projects. Architecture: Clean + DDD |
| Other    | ... |

Patterns and principles

- Repository
- Factory
- Singleton
- Adapter (Wrapper)
- Mediator
- CQRS
- Event Sourcing
- Unit of work (mb)

Backend

- ASP.NET Core

UI

- Angular

Database

- MS SQL (write db)
- MongoDB (read db)
- DB Connectivity : Entityframework Core - Code First

Features and packages

- Ocelot
- Versioning (API)
- Swagger
- MediatR
- Fluent validation
- EF Core
- Automapper
- Mailkit
- Hangfire

Testing

- Unit (xUnit)
- Integration (xUnit)

CI/CD

- Docker

## Contact

If you have troubles or questions, drop a mail to rafikrrrafik@gmail.com