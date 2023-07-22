public static class Config
{
    public static string DbConnectionString()
    {

        DotNetEnv.Env.Load();

        string host = Environment.GetEnvironmentVariable("DB_HOST");
        string port = Environment.GetEnvironmentVariable("DB_PORT");
        string dbName = Environment.GetEnvironmentVariable("DB_NAME");
        string dbUser = Environment.GetEnvironmentVariable("DB_USER");
        string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
        
        return $"Host={host};Port={port};Database={dbName};Username={dbUser};Password={dbPassword};";
    }
}