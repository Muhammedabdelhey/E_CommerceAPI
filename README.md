# E-Commerce API

This project is an e-commerce management API built using **ASP.NET Core**. It handles key operations such as managing categories, brands, attributes, coupons, and products with multiple variants. The architecture follows **Clean Architecture** principles, ensuring scalability and maintainability.

## Key Features

- **Category Management**: Hierarchical categories with parent-child relationships.
- **Brand Management**: Manage e-commerce brands.
- **Attribute Management**: Manage product attributes like color, size, etc.
- **Coupon Management**: Create and manage discount coupons and promotions.
- **Product Management**: Create and manage products with multiple variants, each with its own category and attributes.
- **Product Variants**: Products can have multiple variants (e.g., size, color), each associated with categories.
- **Role-Based Access Control (RBAC)**: Admins can create roles, assign permissions to roles, and dynamically manage user roles and permissions.

## Technologies and Architecture

### ASP.NET Core
The API is built using ASP.NET Core for handling backend operations and services.

### Clean Architecture
The project follows **Clean Architecture** principles, structured into:
- **Domain**: Core business logic and entities.
- **Application**: Business rules and CQRS (commands and queries).
- **Infrastructure**: Data persistence, file storage, and external services.
- **Presentation**: APIs for user interaction.

### CQRS (Command Query Responsibility Segregation)
Operations are divided into:
- **Commands**: Create, update, and delete resources.
- **Queries**: Read data.

This enhances scalability and performance by optimizing write and read operations separately.

### FluentValidation
Validation logic is handled through **FluentValidation** for a clean and maintainable approach. Validators are centralized and used in the **Validation Behavior** to validate commands and queries before they are processed.

### Identity and Role-Based Access Control (RBAC)
The API includes **ASP.NET Core Identity** for user authentication and authorization, with the following features:
- **Dynamic Role and Permission Management**: Admins can create roles and define permissions for each role.
- **Role Assignment**: Assign roles and permissions to users dynamically, allowing for flexible control over access to different areas of the system.
- **Authorization Policies**: Define fine-grained authorization rules based on roles and permissions, ensuring secure access to the system's features.

### File Handling (Adapter Pattern)
The **Adapter Pattern** is used for file uploads (e.g., product images). This allows for flexibility in storing files locally or using external storage services like AWS or Azure.

### Exception Handling
A custom exception handler provides consistent and user-friendly error handling across the API. Exceptions are handled at the service level, making the codebase more maintainable and errors easier to track.

### Interceptors for Auditable Entities
Entity Framework Core interceptors are used to automatically track changes in **auditable entities**, such as creation and modification dates, ensuring that auditing information is maintained efficiently.

### Validation Behavior
The **ValidationBehavior** ensures that requests are validated through **FluentValidation** before being passed to the business logic, ensuring only valid data reaches the core logic.

## Conclusion

This e-commerce API provides a flexible and robust solution for managing various aspects of an e-commerce business. By leveraging **ASP.NET Core**, **Clean Architecture**, **CQRS**, **FluentValidation**, and **Identity with Role-Based Access Control**, it ensures a scalable, secure, and maintainable platform for administrators to efficiently manage an online store.
