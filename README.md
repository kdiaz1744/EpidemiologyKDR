# Epidemiology Tracking System

## Description
The Epidemiology Tracking System is a web API for managing data on individuals diagnosed with a certain illness. It allows users to create, read, and update individual records with information such as name, age, symptoms, diagnosis status, and diagnosis date. This was created as an assignment for the position of Mid-Software Developer for the Deparment of Health Puerto Rico.

## Technologies Used
- C#
- .NET Core
- ASP.NET Core Web API
- In-Memory Database

## Installation
1. Clone the repository: `git clone https://github.com/your-username/epidemiology-tracking-system.git`
2. Navigate to the project folder: `cd epidemiology-tracking-system`
3. Open the project in Visual Studio or your preferred IDE.
4. Build and run the project.

## API Endpoints
- **GET /api/individuals:** Retrieve a list of all diagnosed individuals.
- **GET /api/individuals/{id}:** Retrieve details of a specific individual by ID.
- **POST /api/individuals:** Create a new diagnosed individual.
- **PUT /api/individuals/{id}:** Update an existing individual's information.

All responses are in JSON format.
