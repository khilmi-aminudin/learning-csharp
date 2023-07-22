namespace FundamentalUpSkilling.Config;
using Npgsql;


public class DbConfig
{
    private static readonly object lockObject = new();
    private static DbConfig? instance;
    private readonly NpgsqlConnection connection;

    private DbConfig()
    {
        DotNetEnv.Env.Load();

        var host = Environment.GetEnvironmentVariable("DB_HOST");
        var port = Environment.GetEnvironmentVariable("DB_PORT");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        var dbUser = Environment.GetEnvironmentVariable("DB_USER");
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

        // Connection string
        string connectionString = $"Host={host};Port={port};Database={dbName};Username={dbUser};Password={dbPassword};";

        connection = new NpgsqlConnection(connectionString);
        connection.Open();
    }

    public static DbConfig GetInstance()
    {
        // Double-checked locking for thread safety
        if (instance == null)
        {
            lock (lockObject)
            {
                instance ??= new DbConfig();
            }
        }

        return instance;
    }

    public NpgsqlConnection GetConnection()
    {
        return connection;
    }
}