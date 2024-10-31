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

## Contributing

This project demonstrates two different approaches to repository implementation:

1. **Main Repository (Traditional Pattern)**
    - Located in the main repository
    - Uses conventional repository pattern implementation

2. **Main-Generic Repository**
    - Implements generic repository with specification pattern
    - Available in the generic repository branch

### Contribution Guidelines

When contributing to this project:
1. Assess your use case requirements
2. Choose the appropriate repository implementation
3. Follow the existing pattern in your chosen branch
4. Maintain consistent code style
5. Include unit tests for new features

The choice between implementations should be based on your specific project requirements and needs.