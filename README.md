# College Management System

A Windows Forms application built in C# for managing student and lecturer information in a college database system.

## Features

- **Student Management**

  - Add new students with details like:
    - Student Number
    - Name
    - Address
    - County
    - Age
    - Phone
    - Email
    - Gender

- **Lecturer Management**

  - Add new lecturers with details like:
    - Name
    - Address
    - County
    - Age
    - Phone
    - Email
    - Gender
    - Pay

- **Query System**
  - View all students
  - View all lecturers
  - View male lecturers only
  - View students above age 25
  - View lecturers with pay above 100,000
  - View students from Oregon county

## Technical Details

- Built with C# and Windows Forms
- Uses SQL Server LocalDB for data storage
- Implements object-oriented design with inheritance (Person base class)
- Uses ADO.NET for database operations

## Database Schema

### Student Table

````sql
create table student (
    studentNumber char(10) primary key,
    name varchar(100) not null,
    address varchar(250) not null,
    county varchar(100) not null,
    age int not null,
    phone varchar(25) not null,
    email varchar(250) not null,
    gender varchar(10) not null
);

### Lecturer Table
```sql
create table lecturer (
    lecID int primary key identity(1,1),
    name varchar(100) not null,
    address varchar(250) not null,
    county varchar(100) not null,
    age int not null,
    phone varchar(25) not null,
    email varchar(250) not null,
    gender varchar(10) not null,
    pay decimal not null
);
````

# Setup Instructions

    - ## Clone the repository
    - Open the solution in Visual Studio 2022
    - Ensure you have SQL Server LocalDB installed
    - Run the SQL scripts in SQL_Script.sql to create and populate the database
    - Build and run the application

# System Requirements

    - Windows OS
    - .NET Framework 4.8
    - SQL Server LocalDB
    - Visual Studio 2022 (for development)

License
MIT License
