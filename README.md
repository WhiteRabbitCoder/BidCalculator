# 🚗 Bid Calculator API + Vue UI

A full-stack application to calculate vehicle bid fees based on base price and type (Common or Luxury). Developed with **.NET 8** (C#) for the backend and **Vue 3** (Vite) for the frontend.

---

## 📋 Table of Contents

- [Overview](#-overview)
- [Technologies Used](#-technologies-used)
- [Architecture](#-architecture)
- [Getting Started](#-getting-started)
  - [Prerequisites](#prerequisites)
  - [Local Setup](#local-setup)
  - [GitHub Codespaces Setup](#github-codespaces-setup)
- [API Documentation](#-api-documentation)
- [Testing](#-testing)
- [Project Structure](#-project-structure)
- [Author](#-author)

---

## 🎯 Overview

The system allows users to input a vehicle's price and type. It then calculates different fee types using clean OOP architecture and returns a full breakdown.

**Example Output:**
```json
{
  "buyerFee": 1000,
  "specialFee": 200,
  "associationFee": 50,
  "storageFee": 30,
  "total": 1280
}
```

---

## 🛠 Technologies Used

### Backend
- **.NET 8** (ASP.NET Web API)
- **FluentValidation** - Input validation
- **xUnit** - Unit & integration tests
- **Swagger/OpenAPI** - API documentation
- **C# 12** - Latest language features
- **Dependency Injection** - Built-in DI container

### Frontend
- **Vue 3** - Progressive JavaScript framework
- **Vite** - Fast build tool
- **Axios** - HTTP client
- **Composition API** - Modern Vue patterns
- **Reactive Components** - Real-time updates

---

## 🏗 Architecture

Clean Layered Design with **SOLID principles** and **Strategy Pattern**:

```
┌─────────────────────────────────────────────────┐
│              Frontend (Vue 3)                   │
│  ┌──────────────────┐  ┌──────────────────┐   │
│  │ VehicleForm.vue  │  │ FeeBreakdown.vue │   │
│  │ (User Input)     │  │ (Results Display)│   │
│  └──────────────────┘  └──────────────────┘   │
└─────────────────────────────────────────────────┘
                      ↕ HTTP (Axios)
┌─────────────────────────────────────────────────┐
│           Backend (ASP.NET Web API)             │
│  ┌──────────────────────────────────────────┐  │
│  │ Controllers → API endpoints              │  │
│  ├──────────────────────────────────────────┤  │
│  │ Services → Business logic                │  │
│  │   • FeeCalculators (Strategy pattern)    │  │
│  │   • Interfaces                           │  │
│  │   • TotalFeeService                      │  │
│  ├──────────────────────────────────────────┤  │
│  │ Models → Data structures                 │  │
│  ├──────────────────────────────────────────┤  │
│  │ Validators → FluentValidation rules      │  │
│  ├──────────────────────────────────────────┤  │
│  │ Middlewares → Error handling             │  │
│  └──────────────────────────────────────────┘  │
└─────────────────────────────────────────────────┘
```

**Design Patterns:**
- ✅ Strategy Pattern (Fee calculators)
- ✅ Dependency Injection
- ✅ SOLID Principles
- ✅ Clean Architecture

---

## 🚀 Getting Started

### Prerequisites

- **.NET 8 SDK** or higher ([Download](https://dotnet.microsoft.com/download))
- **Node.js 18+** and **npm** ([Download](https://nodejs.org/))
- **Git**

### Local Setup

#### 1️⃣ Clone the repository

```bash
git clone https://github.com/WhiteRabbitCoder/BidCalculator.git
cd BidCalculator
```

#### 2️⃣ Backend Setup

```bash
# Navigate to backend folder
cd backend-bidCalculator/BidCalculator/BidCalculatorAPI

# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the API
dotnet run
```

✅ **Backend running at:** `http://localhost:5088`  
📚 **Swagger UI:** `http://localhost:5088/swagger`

#### 3️⃣ Frontend Setup

Open a **new terminal** and run:

```bash
# Navigate to frontend folder
cd frontend-bidCalculator

# Install dependencies
npm install

# Run development server
npm run dev
```

✅ **Frontend running at:** `http://localhost:5173`

---

### GitHub Codespaces Setup

#### 1️⃣ Open in Codespaces

Click the **Code** button → **Codespaces** → **Create codespace on main**

#### 2️⃣ Start the Backend

```bash
# Navigate to backend
cd backend-bidCalculator/BidCalculator/BidCalculatorAPI

# Restore and run
dotnet restore
dotnet build
dotnet run
```

#### 3️⃣ Configure Port Visibility ⚠️ **IMPORTANT**

This is the critical step that fixes the `net::ERR_FAILED` error:

1. Go to the **PORTS** tab in Codespaces (bottom panel)
2. Find port **5088** (Backend API)
3. Right-click → **Port Visibility** → Select **Public**
4. Find port **5173** (Frontend) and do the same


#### 4️⃣ Start the Frontend

Open a **new terminal** in Codespaces:

```bash
# Navigate to frontend
cd frontend-bidCalculator

# Install and run
npm install
npm run dev
```

#### 5️⃣ Update API URL (if needed)

If your frontend can't connect to the backend, update the API URL:

**File:** `frontend-bidCalculator/src/api/api.js`

```javascript
// Replace localhost with your Codespace URL
const API_BASE_URL = 'https://your-codespace-name-5088.app.github.dev';
```

You can copy the forwarded URL from the **PORTS** tab.

---

## 📚 API Documentation

### Endpoints

#### **POST** `/api/calculate`

Calculate vehicle bid fees.

**Request Body:**
```json
{
  "price": 1000,
  "type": "Common"  // or "Luxury"
}
```

**Response:**
```json
{
  "buyerFee": 50,
  "specialFee": 20,
  "associationFee": 10,
  "storageFee": 100,
  "totalFees": 180,
  "bidTotal": 1180
}
```

**Validation Rules:**
- `price` must be > 0
- `type` must be "Common" or "Luxury"

### Interactive API Docs

Visit Swagger UI for interactive documentation:
- **Local:** `http://localhost:5088/swagger`
- **Codespaces:** `https://your-codespace-5088.app.github.dev/swagger`

---

## 🧪 Testing

The project includes a comprehensive test suite using **xUnit** framework with full coverage of business logic and API endpoints.

### 🏃 Run Tests

```bash
# Navigate to the solution folder
cd backend-bidCalculator/BidCalculator

# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --logger "console;verbosity=detailed"

# Run tests with code coverage
dotnet test --collect:"XPlat Code Coverage"
```

### 📊 Test Structure

The test project (`BidCalculatorAPI.Tests`) includes the following test suites:

#### **1. Fee Calculator Tests**

Each fee calculator has dedicated unit tests to verify correct calculations:

**`BuyerFeeCalculatorTests.cs`**
- ✅ Tests for **Common** vehicles (10% fee, max $50)
- ✅ Tests for **Luxury** vehicles (25% fee, max $200)
- Uses `[Theory]` and `[InlineData]` for data-driven testing

```csharp
[Theory]
[InlineData(100, FeeTypes.Common, 10)]   // 10% of $100 = $10
[InlineData(500, FeeTypes.Common, 50)]   // 10% of $500 = $50 (max)
[InlineData(1000, FeeTypes.Common, 50)]  // Capped at $50
```

**`SpecialFeeCalculatorTests.cs`**
- ✅ Tests for **Common** vehicles (2% special fee)
- ✅ Tests for **Luxury** vehicles (4% special fee)

```csharp
[Theory]
[InlineData(1000, FeeTypes.Common, 20)]  // 2% of $1000 = $20
[InlineData(1000, FeeTypes.Luxury, 40)]  // 4% of $1000 = $40
```

**`AssociationFeeCalculatorTests.cs`**
- ✅ Tests tiered pricing structure:
  - $1 - $500 → $5
  - $501 - $1000 → $10
  - $1001 - $3000 → $15
  - $3001+ → $20

```csharp
[Theory]
[InlineData(100, 5)]    // Under $500 → $5
[InlineData(501, 10)]   // $501-$1000 → $10
[InlineData(1001, 15)]  // $1001-$3000 → $15
[InlineData(3001, 20)]  // Over $3000 → $20
```

**`StorageFeeCalculatorTests.cs`**
- ✅ Tests flat $100 storage fee for all vehicles

#### **2. Service Layer Tests**

**`TotalFeeServiceTests.cs`**
- ✅ Integration tests for complete fee breakdown
- ✅ Tests for **Common** vehicles
- ✅ Tests for **Luxury** vehicles
- Verifies correct calculation of:
  - Individual fees (buyer, special, association, storage)
  - Total fees sum
  - Final bid total (price + fees)

**Example test case:**
```csharp
[Fact]
public void CalculateBreakdown_ReturnsCorrectBreakdown_ForCommonVehicle()
{
    var vehicle = new Vehicle { Price = 1000, Type = FeeTypes.Common };
    var result = _service.CalculateBreakdown(vehicle);
    
    Assert.Equal(50m, result.BuyerFee);        // 10% of $1000
    Assert.Equal(20m, result.SpecialFee);      // 2% of $1000
    Assert.Equal(10m, result.AssociationFee);  // $501-$1000 tier
    Assert.Equal(100m, result.StorageFee);     // Flat fee
    Assert.Equal(180m, result.TotalFees);      // Sum
    Assert.Equal(1180m, result.BidTotal);      // Price + fees
}
```

#### **3. Controller Tests**

**`CalculateControllerTests.cs`**
- ✅ Integration tests for API endpoints
- ✅ Verifies HTTP 200 OK response
- ✅ Validates response structure

### 📈 Test Coverage

| Component | Coverage | Test Count |
|-----------|----------|------------|
| **BuyerFeeCalculator** | ✅ 100% | 8 tests |
| **SpecialFeeCalculator** | ✅ 100% | 6 tests |
| **AssociationFeeCalculator** | ✅ 100% | 8 tests |
| **StorageFeeCalculator** | ✅ 100% | 1 test |
| **TotalFeeService** | ✅ 100% | 2 tests |
| **CalculateController** | ✅ 100% | 1 test |

**Total: 26+ unit and integration tests**

### 🎯 Testing Best Practices Used

- ✅ **Arrange-Act-Assert (AAA)** pattern
- ✅ **Theory-based tests** with `[InlineData]` for data-driven scenarios
- ✅ **Descriptive test names** following convention: `MethodName_Scenario_ExpectedResult`
- ✅ **Isolated tests** - each test is independent
- ✅ **Edge case coverage** - boundary values and limits tested
- ✅ **Integration tests** - verifying components work together

### 🔍 Example Test Output

```bash
$ dotnet test

Test run for BidCalculatorAPI.Tests.dll (.NET 8.0)
Microsoft (R) Test Execution Command Line Tool Version 17.8.0

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:    26, Skipped:     0, Total:    26
```

---

## 📁 Project Structure

```
BidCalculator/
├── backend-bidCalculator/
│   └── BidCalculator/
│       ├── BidCalculatorAPI/              # Main API project
│       │   ├── Controllers/
│       │   │   └── CalculateController.cs # API endpoints
│       │   ├── Services/
│       │   │   ├── FeeCalculators/
│       │   │   │   ├── BuyerFeeCalculator.cs
│       │   │   │   ├── SpecialFeeCalculator.cs
│       │   │   │   ├── AssociationFeeCalculator.cs
│       │   │   │   └── StorageFeeCalculator.cs
│       │   │   ├── Interfaces/
│       │   │   │   └── IFeeCalculator.cs
│       │   │   └── TotalFeeService.cs
│       │   ├── Models/
│       │   │   ├── Vehicle.cs
│       │   │   └── FeeBreakdown.cs
│       │   ├── Validators/              # FluentValidation
│       │   ├── Middlewares/             # Error handling
│       │   ├── Constants/
│       │   │   └── FeeTypes.cs
│       │   ├── Program.cs
│       │   └── BidCalculatorAPI.csproj
│       │
│       └── BidCalculatorAPI.Tests/        # Test project
│           ├── AssociationFeeCalculatorTests.cs
│           ├── BuyerFeeCalculatorTests.cs
│           ├── CalculateControllerTests.cs
│           ├── SpecialFeeCalculatorTests.cs
│           ├── StorageFeeCalculatorTests.cs
│           ├── TotalFeeServiceTests.cs
│           └── BidCalculatorAPI.Tests.csproj
│
├── frontend-bidCalculator/
│   ├── src/
│   │   ├── components/
│   │   │   ├── VehicleForm.vue       # Input form
│   │   │   └── FeeBreakdown.vue      # Results display
│   │   ├── api/
│   │   │   └── api.js                # HTTP client
│   │   ├── App.vue
│   │   └── main.js
│   ├── package.json
│   └── vite.config.js
│
└── README.md
```

---

## 👨‍💻 Author

**Angelo Gaviria**  
Full-stack developer in progress 🚀

- GitHub: [@WhiteRabbitCoder](https://github.com/WhiteRabbitCoder)

---

## 💡 Troubleshooting

### Common Issues

**1. `net::ERR_FAILED` in Codespaces**
- ✅ Make sure port 5088 visibility is set to **Public** in the PORTS tab

**2. Package version conflicts**
- ✅ Make sure you're using .NET 8.0 compatible packages

**3. Frontend can't connect to API**
- ✅ Check the API URL in `frontend-bidCalculator/src/api/api.js`
- ✅ Verify backend is running (`dotnet run`)

**4. Tests failing**
- ✅ Ensure you're in the correct directory: `backend-bidCalculator/BidCalculator`
- ✅ Run `dotnet restore` before running tests
- ✅ Check that all dependencies are installed

---

<div align="center">
  
Made with ❤️ and ☕

</div>