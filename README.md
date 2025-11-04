Student Management System (C# + ADO.NET)

A simple console-based 3-Tier Student Management System built with C# and ADO.NET, connected to SQL Server.
This project demonstrates clean architecture, separation of concerns, and proper use of interfaces and dependency injection.

Project Architecture

The project is organized into three layers: Presentation Layer  →  Business Layer  →  Data Access Layer  →  Database

1. Presentation Layer

Located in StudentManagementSystem.Presentation

Contains the console user interface (MenuManager and Program.cs).

Responsible for handling user input/output.

Calls the Business Layer to perform operations.

2. Business Layer

Located in StudentManagementSystem.Business

Contains StudentService and the interface IStudentService.

Handles validation and business logic before accessing the database.

Depends only on interfaces from the Data layer, not on specific implementations.

3. Data Access Layer

Located in StudentManagementSystem.Data

Contains StudentRepository and the interface IStudentRepository.

Handles all database operations using ADO.NET (SqlConnection, SqlCommand, SqlDataReader).

Uses DataAccessSettings for the connection string configuration.

Features

Add new students

List all students

Search student by ID

Update student details

Delete student record

Input validation at the Business Layer

Centralized connection string management

Clean 3-Tier separation for easy maintenance and testing 

Technologies Used

C# (.NET 8)

ADO.NET for data access

SQL Server 

Visual Studio 2022 for development

