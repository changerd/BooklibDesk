# BooklibDesk

BooklibDesk is a WPF desktop application designed to manage a library of books. It provides functionality to add, edit, delete, with data stored in a PostgreSQL database. The application is built using the MVVM (Model-View-ViewModel) architectural pattern.

## Features

- Add new books with title, author, and year of publication.
- Edit existing book records.
- Delete books from the library.
- View a list of books in a sortable and filterable table.
- Store and retrieve book data from a PostgreSQL database using Entity Framework Core.
- Input validation and feedback for successful/unsuccessful operations.

## Technologies Used

- **WPF (Windows Presentation Foundation)** for the user interface.
- **Entity Framework Core** for database interaction.
- **PostgreSQL** as the database.
- **MVVM Pattern** for application architecture.

## Requirements

- .NET 6 SDK or later
- PostgreSQL database server (running in Docker or locally)
- Visual Studio 2022 or another compatible IDE

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/yourusername/BooklibDesk.git
cd BooklibDesk
```

### Set Up the Database

1. Pull the official PostgreSQL Docker image:
   ```bash
   docker pull postgres
   ```
2. Run the PostgreSQL container:
   ```bash
   docker run -d --name postgres-database -e POSTGRES_PASSWORD=123 -p 5432:5432 postgres:latest
   ```
3. Create SQL table:
  ```sql
  CREATE DATABASE booklib;

  CREATE TABLE Books (
    Id SERIAL PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Author VARCHAR(255) NOT NULL,
    Year INT
  );
  ```

### Build and Run the Application

1. Open the solution in Visual Studio.
2. Restore NuGet packages and build the solution.
3. Run the application.

## Project Structure

- **Models**: Defines the `Book` entity.
- **Data**: Contains the `ApplicationDbContext` for database interactions.
- **ViewModels**: Implements the `MainViewModel` for binding data to the UI.
- **Views**: Includes the XAML files for the application's UI.
- **Utils**: Contains utility classes like `RelayCommand`.
