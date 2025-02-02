# **Receipt Processor API Documentation**

## **Overview**
The **Receipt Processor API** provides endpoints to process and evaluate receipts by calculating points based on various criteria. This API is built using **ASP.NET Core 8** with **Entity Framework Core In-Memory Database** for data persistence.

---

## **Endpoints**

### **1. Process a Receipt**
#### **Endpoint:**  
```http
POST /receipts/process
```
#### **Description:**  
Stores a receipt in the database and returns its unique identifier.

#### **Request Body (JSON):**
```json
{
    "retailer": "Walgreens",
    "purchaseDate": "2022-01-02",
    "purchaseTime": "08:13",
    "total": "2.65",
    "items": [
        { "shortDescription": "Pepsi - 12-oz", "price": "1.25" },
        { "shortDescription": "Dasani", "price": "1.40" }
    ]
}
```
#### **Response (JSON):**
```json
{
    "id": "550e8400-e29b-41d4-a716-446655440000"
}
```
- The response contains the unique `id` assigned to the receipt.

#### **Possible Responses:**
| Status Code | Description |
|-------------|------------|
| 200 OK | Receipt was successfully saved, returns receipt ID |
| 400 Bad Request | Invalid request format |

---

### **2. Get Receipt Points**
#### **Endpoint:**  
```http
GET /receipts/{id}/points
```
#### **Description:**  
Retrieves the total points earned for a given receipt.

#### **Path Parameter:**
| Parameter | Type | Description |
|-----------|------|-------------|
| `id` | `GUID` | The unique ID of the receipt |

#### **Example Request:**
```http
GET /receipts/550e8400-e29b-41d4-a716-446655440000/points
```
#### **Example Response (JSON):**
```json
{
    "points": 82
}
```
#### **Possible Responses:**
| Status Code | Description |
|-------------|------------|
| 200 OK | Returns the calculated points |
| 404 Not Found | No receipt found with the given ID |

---

## **How to Run the Application**

### **Prerequisites**
Ensure you have the following installed:
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- A terminal or command prompt

### **Steps to Run**
1. **Clone the repository (if applicable):**
   ```sh
   git clone https://github.com/your-repo/receipt-processor.git
   cd receipt-processor
   ```

2. **Run the application using the .NET CLI:**
   ```sh
   dotnet run
   ```
   This will start the server, typically on `http://localhost:5000` or `https://localhost:7000`.

3. **Test the API using a tool like Postman or CURL:**
   ```sh
   curl -X POST "http://localhost:5000/receipts/process" -H "Content-Type: application/json" -d @receipt.json
   ```

4. **Access Swagger UI for interactive API testing (if enabled):**
   Open in a browser:
   ```
   http://localhost:5000/swagger
   ```

---

## **Project Configuration: In-Memory Database**
This application uses an **In-Memory Database** with **Entity Framework Core** for temporary storage.

### **Configuring the Database in `AppDbContext.cs`**
```csharp
using Microsoft.EntityFrameworkCore;
using receipt_processor.Models;

namespace receipt_processor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Receipt> Receipt { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ReceiptsDB");
        }
    }
}
```

### **Registering the Database in `Program.cs`**
```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ReceiptsDB"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
```

---

## **Next Steps**
- Extend functionality by using **SQL Server** or **SQLite** instead of an In-Memory Database.
- Add authentication and authorization to secure endpoints.
- Implement more validation for input data.

---

This documentation should give you everything needed to **run, test, and extend** the API. 🚀 Let me know if you need any refinements!