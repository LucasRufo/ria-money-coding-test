using Dapper;
using Npgsql;
using Respawn;
using Testcontainers.PostgreSql;

namespace Exercise02.IntegrationTests;

[SetUpFixture]
public class DatabaseFixture
{
    private static readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder()
        .WithDatabase("testsDb")
        .WithName("testsDb")
        .WithPortBinding("5433", "5432")
        .WithUsername("testsUser")
        .WithPassword("tests@Password")
        .Build();

    private static Respawner Respawner = null!;

    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        await _postgreSqlContainer.StartAsync();

        using var conn = new NpgsqlConnection("Server=localhost;Database=testsDb;Port=5433;User Id=testsUser;Password=tests@Password;Timeout=300;CommandTimeout=300;KeepAlive=300;Include Error Detail=true");
        await conn.OpenAsync();

        var sqlQuery = @"
            CREATE TABLE IF NOT EXISTS customers (
                id INTEGER PRIMARY KEY,
                first_name VARCHAR(200) NOT NULL,
                last_name VARCHAR(200) NOT NULL,
                age INTEGER NOT NULL
            );";

        await conn.ExecuteAsync(sqlQuery);

        Respawner = await Respawner.CreateAsync(conn, new RespawnerOptions
        {
            TablesToIgnore = [],
            SchemasToInclude = [ "public" ],
            SchemasToExclude = [],
            DbAdapter = DbAdapter.Postgres
        });
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        await _postgreSqlContainer.DisposeAsync().AsTask();
    }

    public static async Task ResetDatabase()
    {
        using var conn = new NpgsqlConnection(_postgreSqlContainer.GetConnectionString());
        await conn.OpenAsync();
        await Respawner.ResetAsync(conn);
    }
}

