# Ski Store API
API for Ski Store project

## Development Setup Requirements
- .NET 8 SDK
- Docker Desktop
- Git

## Getting Started

1. Clone the repository
```bash
git clone https://github.com/viniciusmorgado/skistore-api.git
```

2. Create a `.env` file in the root directory with these variables:
```
POSTGRES_USER=your_username
POSTGRES_PASSWORD=your_password
```
Note: Choose any username/password for development, but remember to update `appsettings.Development.json` with the same credentials.

3. Start the PostgreSQL container:
```bash
docker-compose up -d
```

4. Run the API:
```bash
dotnet restore
dotnet run
```

## Database Configuration

The PostgreSQL container runs with these specifications:
- CPU: 1 core (minimum 0.5)
- Memory: 1GB (minimum 512MB)
- Port: 5432 (default)

These resources are sufficient for local development.
