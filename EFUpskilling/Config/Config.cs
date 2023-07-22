public static class Config
{
    public static string DbConnectionString()
    {

        DotNetEnv.Env.Load();

        var host = Environment.GetEnvironmentVariable("DB_HOST");
        var port = Environment.GetEnvironmentVariable("DB_PORT");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        var dbUser = Environment.GetEnvironmentVariable("DB_USER");
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

        // Connection string
        return $"Host={host};Port={port};Database={dbName};Username={dbUser};Password={dbPassword};";
    }
}