
    internal static class ConnectionStrings
    {
       
        static readonly Dictionary<DbProvider, string> configurations = new()
        {
            [DbProvider.SQLServer] = "Server=MATT; Database=superhero-db; User Id=sa; Password=Pa$$w0rd;"
        };
        public static string Get(DbProvider provider) => configurations[provider];

    }

