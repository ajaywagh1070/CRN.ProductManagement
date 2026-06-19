# CRN Product Management API

## Overview

ASP.NET Core Web API built using Clean Architecture principles.

## Features

* Product CRUD Operations
* Item CRUD Operations
* JWT Authentication
* Refresh Token Support
* API Versioning
* Fluent Validation
* Global Exception Handling
* Serilog Logging
* Docker Support
* Docker Compose
* Health Checks
* Unit Testing

## Architecture

* API Layer
* Application Layer
* Infrastructure Layer
* Domain Layer

## Technologies Used

* ASP.NET Core 10
* Entity Framework Core
* SQL Server
* JWT Authentication
* FluentValidation
* Serilog
* Docker
* Docker Compose
* xUnit

## Run Locally

dotnet restore

dotnet build

dotnet run --project CRN.ProductManagement.API

## Run With Docker

docker compose up -d --build

## Health Check

GET /health

## Authentication

POST /api/auth/login

POST /api/auth/refresh-token

## Testing

dotnet test
