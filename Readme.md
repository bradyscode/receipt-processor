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
  "retailer": "M&M Corner Market",
  "purchaseDate": "2022-03-20",
  "purchaseTime": "14:33",
  "items": [
    {
      "shortDescription": "Gatorade",
      "price": "2.25"
    },{
      "shortDescription": "Gatorade",
      "price": "2.25"
    },{
      "shortDescription": "Gatorade",
      "price": "2.25"
    },{
      "shortDescription": "Gatorade",
      "price": "2.25"
    }
  ],
  "total": "9.00"
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
    "points": 109
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
   git clone https://github.com/bradyscode/receipt-processor.git
   cd receipt-processor
   ```

2. **Run the application using the .NET CLI:**
   ```sh
   dotnet run
   ```
   This will start the server, review the command line to find the port the api is running on`.

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

---