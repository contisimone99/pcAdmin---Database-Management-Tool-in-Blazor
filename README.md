# pcAdmin - Database Management Tool

A web-based database management tool built with Blazor WebAssembly that supports multiple database systems including SQL Server, SQLite, and PostgreSQL. This application serves as a comprehensive database management interface, allowing users to interact with different types of databases through a unified web interface.

## Purpose and Overview

pcAdmin is designed to simplify database management and exploration tasks for developers, database administrators, and data analysts. It provides a unified interface for working with different database systems, eliminating the need to switch between different management tools for different database types.

### Key Benefits
- Single interface for multiple database types
- No installation required (web-based)
- Real-time query execution and results
- Easy data import/export capabilities
- Visual representation of database structure

### How It Works

1. **Database Connection**
   - Users start by selecting their database type (SQL Server, SQLite, or PostgreSQL)
   - Connection details are entered (server address, credentials, etc.)
   - The application establishes and maintains a secure connection to the database

2. **Database Structure Visualization**
   - Upon successful connection, pcAdmin automatically retrieves and displays:
     - List of all tables in the database
     - Detailed table structure information
     - Relationships between tables (foreign keys)
     - Indexes and constraints

3. **Query Management**
   - Users can execute SQL queries through a simple interface
   - For SELECT queries:
     - Results are displayed in a tabular format
     - Data can be exported to CSV
   - For other queries (INSERT, UPDATE, DELETE, etc.):
     - Execution status is shown
     - Changes are reflected immediately in the database

4. **Data Import/Export**
   - CSV Import:
     - Upload CSV files
     - Preview data before import
     - Automatic data type detection
   - CSV Export:
     - Export query results
     - Custom file naming
     - Standard CSV format compatible with most tools

5. **Real-time Updates**
   - Changes to database structure are reflected immediately
   - Query results update automatically
   - Error messages and status updates appear in real-time

### Common Use Cases

1. **Database Development**
   - Quickly test and execute queries
   - Verify database structure
   - Check relationships between tables

2. **Data Analysis**
   - Execute complex SELECT queries
   - Export data for further analysis
   - Import processed data

3. **Database Administration**
   - Monitor database structure
   - Manage indexes and keys
   - Execute maintenance queries

4. **Teaching and Learning**
   - Explore database concepts
   - Visualize database relationships
   - Practice SQL queries

## Features

- Multi-database system support:
  - Microsoft SQL Server
  - SQLite
  - PostgreSQL
- Database structure visualization:
  - Table listings
  - Column information
  - Primary key details
  - Foreign key relationships
  - Index information
- Query execution:
  - Execute SQL queries
  - View query results
  - Export results to CSV
- CSV Import/Export functionality
- Real-time query response
- User-friendly interface with tab-based navigation

## Prerequisites

- .NET 6.0 SDK
- One or more of the following database systems:
  - Microsoft SQL Server
  - SQLite
  - PostgreSQL
- Visual Studio 2022 or later (recommended) or Visual Studio Code

## Dependencies

### Server-side (.NET 6.0)
- Microsoft.AspNetCore.Components.WebAssembly.Server (6.0.8)
- Microsoft.EntityFrameworkCore (6.0.8)
- Microsoft.EntityFrameworkCore.SqlServer (6.0.8)
- Microsoft.EntityFrameworkCore.Sqlite (6.0.8)
- Npgsql.EntityFrameworkCore.PostgreSQL (6.0.6)
- Swashbuckle.AspNetCore (6.4.0)

### Client-side
- Blazored.SessionStorage
- System.Net.Http.Json (6.0.0)

## Installation

1. Clone the repository:
```bash
git clone https://github.com/yourusername/pcAdmin.git
cd pcAdmin
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Build the solution:
```bash
dotnet build
```

4. Run the application:
```bash
dotnet run --project pcAdmin.Server
```

## Configuration

### Database Connection Strings

For each database type, you'll need to provide the appropriate connection string:

#### SQL Server
```
Server=serveraddress;Database=dbname;User Id=username;Password=password;
```

#### SQLite
```
Data Source=path/to/your/database.db;
```

#### PostgreSQL
```
Server=serveraddress;Database=dbname;Port=5432;User ID=username;Password=password;
```

## Usage

1. Launch the application and navigate to the main page
2. Click on "DBMS" in the navigation menu
3. Select your database type (SQL Server, SQLite, or PostgreSQL)
4. Enter your connection details
5. Once connected, you can:
   - Browse database tables and their structure
   - Execute SQL queries
   - Import/Export CSV files
   - View relationships between tables

## Project Structure

```
pcAdmin/
├── Client/             # Blazor WebAssembly Client
│   ├── Pages/         # Razor Pages
│   └── Services/      # Client Services
├── Server/            # ASP.NET Core Server
│   ├── Controllers/   # API Controllers
│   ├── Data/         # Data Context
│   └── Helper/       # Helper Classes
└── Shared/           # Shared Models and DTOs
```

## Features Details

### Table Structure View
- View all tables in the database
- Column information including data types and constraints
- Primary and foreign key relationships
- Index information

### Query Execution
- Execute SELECT queries with results display
- Execute DDL and DML statements
- Query success/failure feedback
- Export query results to CSV

### CSV Operations
- Import CSV files into the application
- Export query results to CSV format
- CSV parsing and validation

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## Authors

- Matteo Pasotti (20035991)
- Simone Conti (20034446)

## Acknowledgments

- Built for the Web Applications: Languages and Architectures course (a.a. 2021/2022)
- Uses Entity Framework Core for database operations
- Built with Blazor WebAssembly for client-side operations

## Support

For support, please open an issue in the GitHub repository or contact the authors.
