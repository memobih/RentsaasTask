# Employee Management API

A simple and efficient RESTful API built with **.NET 8** to manage employees.  
Supports full CRUD operations, pagination, and search filtering.

---

## 🚀 Features

- Create, Read, Update, Delete Employees  
- Pagination and search filtering on employee list  
- Lightweight and fast with EF Core and SQLite  
- Clean architecture with services, interfaces, and DTOs  

---

## 📦 Technologies Used

- .NET 8 Web API  
- Entity Framework Core with SQLite  
- Swagger for API documentation  
- Angular (frontend) - [link to your Angular repo or instructions]  

---
| Method | Endpoint                                              | Description                     | Request Body                                  | Response                      |
|--------|-------------------------------------------------------|---------------------------------|-----------------------------------------------|-------------------------------|
| GET    | `http://employeetask.runasp.net/employees`            | Get paginated list of employees | Query params: `search` (optional), `page`, `pageSize` | Returns list of employees + total count |
| GET    | `http://employeetask.runasp.net/employees/{id}`       | Get employee by ID              | N/A                                           | Employee object or 404         |
| POST   | `http://employeetask.runasp.net/employees`            | Create new employee             | Employee DTO JSON                             | Created Employee object        |
| PUT    | `http://employeetask.runasp.net/employees/{id}`       | Update existing employee        | Employee DTO JSON                             | `true` if updated, `false` if not found |
| DELETE | `http://employeetask.runasp.net/employees/{id}`       | Delete employee                 | N/A                                           | `true` if deleted, `false` if not found |

