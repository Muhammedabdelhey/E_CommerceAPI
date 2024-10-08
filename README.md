# E-Commerce Dashboard

This project is an e-commerce management dashboard built using **ASP.NET Core**. It handles all key operations such as managing categories, brands, attributes, coupons, and products with multiple variants. The architecture follows **Clean Architecture** principles, providing a scalable and maintainable solution.

## Key Features

- **Category Management**: Hierarchical categories with parent-child relationships.
- **Brand Management**: Manage e-commerce brands.
- **Attribute Management**: Manage product attributes like color, size, etc.
- **Coupon Management**: Create and manage discount coupons and promotions.
- **Product Management**: Create and manage products with multiple variants, each with its own category and attributes.
- **Product Variants**: Products can have multiple variants (e.g., size, color), each associated with categories.

## Technologies and Architecture

### ASP.NET Core
The web application is built using ASP.NET Core for handling backend operations and services.

### Clean Architecture
The project follows **Clean Architecture** principles, structured into:
- **Domain**: Core business logic and entities.
- **Application**: Business rules and CQRS (commands and queries).
- **Infrastructure**: Data persistence, file storage, and external services.
- **Presentation**: APIs and user interaction.

### CQRS (Command Query Responsibility Segregation)
Operations are divided into:
- **Commands**: To create, update, and delete resources.
- **Queries**: To read data.
  
This enhances scalability and performance by optimizing write and read operations separately.

### FluentValidation
All validation logic is handled through **FluentValidation** for a clean and maintainable approach. Validators are centralized and used in the **Validation Behavior** to validate commands and queries before they are processed.

### File Handling (Adapter Pattern)
The **Adapter Pattern** is used for file uploads (e.g., product images). This allows for flexibility, whether storing files locally or using external storage services like AWS or Azure.

### Exception Handling
A custom exception handler provides consistent and user-friendly error handling across the application. Exceptions are handled at the service level, making the codebase more maintainable and errors easier to track.

### Interceptors for Auditable Entities
Entity Framework Core interceptors are used to automatically track changes in **auditable entities**, such as creation and modification dates, ensuring that auditing information is maintained efficiently.

### Validation Behavior
The **ValidationBehavior** ensures that requests are validated through **FluentValidation** before being passed to the business logic. This ensures that only valid data reaches the core logic.
