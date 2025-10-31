#  Bid Calculator API + Vue UI

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
  "basePrice": 1000,
  "vehicleType": "Common"  // or "Luxury"
}
```

**Response:**
```json
{
  "buyerFee": 50,
  "sellerFee": 50,
  "associationFee": 20,
  "storageFee": 100,
  "total": 1220
}
```

**Validation Rules:**
- `basePrice` must be > 0
- `vehicleType` must be "Common" or "Luxury"

### Interactive API Docs

Visit Swagger UI for interactive documentation:
- **Local:** `http://localhost:5088/swagger`
- **Codespaces:** `https://your-codespace-5088.app.github.dev/swagger`

---

## 🧪 Testing

All business logic is tested with **xUnit**.

### Run all tests

```bash
cd backend-bidCalculator/BidCalculator
dotnet test
```

### Run tests with coverage

```bash
dotnet test --collect:"XPlat Code Coverage"
```

**Test Coverage:**
- ✅ Fee calculators (unit tests)
- ✅ Validation logic
- ✅ API endpoints (integration tests)
- ✅ Error handling

---

## 📁 Project Structure

```
BidCalculator/
├── backend-bidCalculator/
│   └── BidCalculator/
│       ├── BidCalculatorAPI/         # Main API project
│       │   ├── Controllers/          # API endpoints
│       │   ├── Services/             # Business logic
│       │   │   ├── FeeCalculators/   # Strategy pattern
│       │   │   └── Interfaces/
│       │   ├── Models/               # DTOs and entities
│       │   ├── Validators/           # FluentValidation
│       │   ├── Middlewares/          # Error handling
│       │   └── Program.cs            # App configuration
│       └── BidCalculatorAPI.Tests/   # Unit tests
├── frontend-bidCalculator/
│   ├── src/
│   │   ├── components/
│   │   │   ├── VehicleForm.vue       # Input form
│   │   │   └── FeeBreakdown.vue      # Results display
│   │   ├── api/
│   │   │   └── api.js                # HTTP client
│   │   └── App.vue
│   ├── package.json
│   └── vite.config.js
└── README.md
```

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

**4. Frontend can't connect to API**
- ✅ Check the API URL in `frontend-bidCalculator/src/api/api.js`
- ✅ Verify backend is running (`dotnet run`)

---

<div align="center">
  
Made with ❤️ and ☕

</div>