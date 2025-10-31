# Bid Calculator API + Vue UI

A full-stack application to calculate vehicle bid fees based on base price and type (Common or Luxury). Developed with .NET 9 (C#) for the backend and Vue 3 (Vite) for the frontend.

---

## Overview

The system allows users to input a vehicle’s price and type. It then calculates different fee types using clean OOP architecture and returns a full breakdown.

Example Output:
{
  "buyerFee": 1000,
  "specialFee": 200,
  "associationFee": 50,
  "storageFee": 30,
  "total": 1280
}

---

## Architecture

Clean Layered Design:
Frontend (Vue)
  - VehicleForm.vue → Handles user input
  - FeeBreakdown.vue → Displays results
Backend (C# / ASP.NET)
  - Controllers → API endpoints
  - Services → Business logic
    - FeeCalculators (Strategy pattern)
    - Interfaces
    - TotalFeeService
  - Models → Data structures
  - Validators → Input validation
  - Middlewares → Error handling

---

## Technologies Used

Backend:
- .NET 9 (ASP.NET Web API)
- FluentValidation
- xUnit (unit & integration tests)
- Swagger (OpenAPI)
- C# 12
- Dependency Injection

Frontend:
- Vue 3 (Vite)
- Axios
- Composition API
- Reactive Components

---

## Design Principles & Patterns

- SOLID principles
- Strategy Pattern
- Dependency Injection
- Clean Architecture

---

## Testing

All business logic is tested with xUnit.
Each fee calculator has unit tests to ensure formulas behave correctly.

Run tests:
dotnet test

---

## How to Run

Backend:
cd BidCalculatorAPI
dotnet run
Swagger: http://localhost:5088/swagger

Frontend:
cd bid-calculator-ui
npm install
npm run dev
Vite dev server: http://localhost:5173

---

## Validation & Error Handling

- FluentValidation for validation
- ErrorHandlingMiddleware for exceptions
- Returns clear messages for invalid requests.

---

## Swagger Documentation

Swagger is available at:
http://localhost:5088/swagger
---

## Future Improvements

- Add authentication (JWT)
- Store bids and vehicles in a database
- Add currency selector and localization
- Deploy to Azure or Render + Vercel

---

## Author
Angelo Gaviria
Full-stack developer in progress 🚀