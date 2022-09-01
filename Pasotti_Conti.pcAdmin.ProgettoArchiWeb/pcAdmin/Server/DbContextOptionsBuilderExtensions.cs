using Microsoft.EntityFrameworkCore;

static class DbContextOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder<T> Use<T>(this DbContextOptionsBuilder<T> builder, string provider, string connectionString)
        where T : DbContext
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(connectionString);

        return provider switch
        {
           "SQLITE"     => builder.UseSqlite(@connectionString),
           "SQLSERVER"  => builder.UseSqlServer(connectionString),
           "POSTGRESQL" => builder.UseNpgsql(connectionString),

            _ => throw new NotSupportedException(),
        };
    }
}

