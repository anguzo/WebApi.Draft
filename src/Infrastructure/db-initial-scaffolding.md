## Database Initial Scaffolding

This section covers the setup of the initial database using Entity Framework Core tools.

### 1. Scaffold Database
```sh
dotnet ef dbcontext scaffold "<connection_string>" <database_provider> --no-onconfiguring --output-dir Entities
```

### 2. Setup Design-time Factory
Implement the `IDesignTimeDbContextFactory<TContext>`. [Learn more](https://learn.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#from-a-design-time-factory).

### 3. Migrations
**Create Migration**:
```sh
dotnet ef migrations add InitialMigration
```

**Apply Migration**:
```sh
dotnet ef database update
```

> **Note**: Applying the initial migration to the database from which scaffolding was done will result in an error. In this situation, the `__EFMigrationsHistory` table will be generated. Manually add the migration as below:
> ```sh
> INSERT INTO [__EFMigrationsHistory] ([MIGRATIONID], [PRODUCTVERSION])
> VALUES (N'<full_migration_timestamp_and_name>', N'<EF_version>');
> ```