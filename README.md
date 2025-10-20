
# Introduction to ASP.NET Core

This repository is for a **class presentation and live demo** to introduce the fundamentals of building web APIs using **ASP.NET Core**. The goal is to show how simple and structured .NET can be for modern backend development.

---

## Objectives
By the end of the demo, you will understand how to:
- Set up a basic ASP.NET Core project in VS Code
- Create **Controllers**, **Models**, and **Services**
- Understand **Dependency Injection** and **Routing**
- Test endpoints using **Postman**
- Organize clean and maintainable API architecture

---

## Project Overview
We’ll build a simple **Todo API** that allows users to:
- **Get** all tasks  
- **Get** a specific task by ID  
- **Add** new tasks  
- **Update** or **delete** existing tasks  

This is a small but complete example of CRUD operations.

---

## Project Structure
```
src/
├── Controllers/
│   └── TaskController.cs      # Handles API requests
├── Data/
│   └── tasks.json             # In-memory data storage
├── Models/
│   └── TaskItem.cs            # Data structure (Model)
└── Services/
    └── TaskService.cs         # Business logic
Program.cs                     # Application entry point and DI setup
```

---

## Key Concepts

### 1. **Controllers**
Controllers define your API endpoints.  
Example: `TaskController` responds to `/api/task` routes.

### 2. **Models**
Models represent the data structure you work with; similar to classes in object-oriented programming.

### 3. **Services**
Services handle logic, data access, and rules. This keeps controllers lightweight and testable.

### 4. **Dependency Injection (DI)**
ASP.NET automatically provides registered services to your controllers, reducing coupling and improving testability.

### 5. **Routing**
Routes define how URLs map to actions. Attribute routing makes this simple and explicit:
```csharp
[HttpGet("{id}")]
public ActionResult<TaskItem> GetTaskById(string id) { ... }
```

---

## Getting Started

### 1. Install .NET SDK
Check if you have .NET installed:
```bash
dotnet --version
```
If not, download from [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).

### 2. Clone this Repository
```bash
git clone https://github.com/KobenjiSan/ASP.NET-Demo.git
cd ASP.NET-Demo
```

### 3. Run the Application
```bash
dotnet run
```
Visit `http://localhost:5000` or `https://localhost:7000` to test it.\
(or whatever localhost it maps to)

### 4. Test with Postman
Use Postman to call endpoints like:
```
GET    /api/task
GET    /api/task/{id}
POST   /api/task
PUT    /api/task/{id}
DELETE /api/task/{id}
```

---

## Requirements
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- VS Code or Visual Studio
- Postman (optional for testing)

---

## Learn More
- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [Routing in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing)
- [Dependency Injection](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)

---

## Author
**Sam Keller**  
Student at *Georgia Gwinnett College*  
Presentation for *Software Development II*

---

> “Simple structure, powerful foundation — ASP.NET gives you both.”
