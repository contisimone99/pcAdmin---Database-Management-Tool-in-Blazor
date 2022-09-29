using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using pcAdmin.Server.Data;
using pcAdmin.Server.Controllers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data.SqlTypes;
using pcAdmin.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.Sqlite;
using Npgsql;

public static class HelperPCAdmin
{
    //Esegue una query Select e restituisce una Lista di Array di Oggetti
    public static DataContext SetDB(DatabaseConnection databaseConnection)
    {
        var options = new DbContextOptionsBuilder<DataContext>()
        .Use(databaseConnection.Provider, databaseConnection.ConnectionString)
        .Options;
        var context = new DataContext(options);
        return context;
    }

    public static async Task<TablesList> GetTablesListDB(DatabaseConnection databaseConnection)
    {
        TablesList _TablesList = new TablesList();
        List<TablesList_SQLSERVER> _TablesList_SQLSERVER = new List<TablesList_SQLSERVER>();
        List<TablesList_SQLITE> _TablesList_SQLITE = new List<TablesList_SQLITE>();
        List<TablesList_POSTGRESQL> _TablesList_POSTGRESQL = new List<TablesList_POSTGRESQL>();

        using (var context = SetDB(databaseConnection))
        {
            try
            {
                switch (databaseConnection.Provider)
                {
                    case "SQLSERVER":
                        _TablesList_SQLSERVER = await context.TablesList_SQLSERVER.FromSqlRaw(SQLRawQuery.SQLSERVER_TablesList).ToListAsync();
                        _TablesList.NomeTabella_SQLSERVER = _TablesList_SQLSERVER;
                        break;

                    case "SQLITE":
                        _TablesList_SQLITE = await context.TablesList_SQLITE.FromSqlRaw(SQLRawQuery.SQLITE_TablesList).ToListAsync();
                        _TablesList.NomeTabella_SQLITE = _TablesList_SQLITE;
                        break;

                    case "POSTGRESQL":
                        _TablesList_POSTGRESQL = await context.TablesList_POSTGRESQL.FromSqlRaw(SQLRawQuery.POSTGRESQL_TablesList).ToListAsync();
                        _TablesList.NomeTabella_POSTGRESQL = _TablesList_POSTGRESQL;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        return _TablesList;
    }

    public static async Task<List<object[]>> GetTableInfoDB(DatabaseConnection databaseConnection)
    {
        var options = new DbContextOptionsBuilder<DataContext>()
        .Use(databaseConnection.Provider, databaseConnection.ConnectionString)
        .Options;
        string query;

        if (databaseConnection.Provider == "POSTGRESQL")
            query = "Select * from public.\"" + databaseConnection.TableData + "\"";
        else
            query = "Select * from " + databaseConnection.TableData;

        var TableInfo = Helper.ReadTableInfo(databaseConnection, options, query);
        return TableInfo;
    }

    public static async Task<TablePrimaryKey> GetTablePrimaryKeyDB(DatabaseConnection databaseConnection)
    {

        TablePrimaryKey _TablePrimaryKey = new TablePrimaryKey();
        List<TablePrimaryKey_SQLSERVER> _TablePrimaryKey_SQLSERVER = new List<TablePrimaryKey_SQLSERVER>();
        List<TablePrimaryKey_SQLITE> _TablePrimaryKey_SQLITE = new List<TablePrimaryKey_SQLITE>();
        List<TablePrimaryKey_POSTGRESQL> _TablePrimaryKey_POSTGRESQL = new List<TablePrimaryKey_POSTGRESQL>();


        using (var context = SetDB(databaseConnection))
        {
            try
            {
                switch (databaseConnection.Provider)
                {
                    case "SQLSERVER":
                        _TablePrimaryKey_SQLSERVER = await context.TablePrimaryKey_SQLSERVER.FromSqlRaw(SQLRawQuery.SQLSERVER_PrimaryKey
                                                                                                       , new SqlParameter("Table", databaseConnection.TableData))
                                                                                                       .ToListAsync();
                        _TablePrimaryKey.ChiavePrimaria_SQLSERVER = _TablePrimaryKey_SQLSERVER;
                        break;

                    case "SQLITE":
                        _TablePrimaryKey_SQLITE = await context.TablePrimaryKey_SQLITE.FromSqlRaw(SQLRawQuery.SQLITE_PrimaryKey
                                                                                                 , new SqliteParameter("Table", databaseConnection.TableData))
                                                                                                 .ToListAsync();
                        _TablePrimaryKey.ChiavePrimaria_SQLITE = _TablePrimaryKey_SQLITE;
                        break;

                    case "POSTGRESQL":
                        _TablePrimaryKey_POSTGRESQL = await context.TablePrimaryKey_POSTGRESQL.FromSqlRaw(SQLRawQuery.POSTGRESQL_PrimaryKey
                                                                                                         , new NpgsqlParameter("Table", "public.\"" + databaseConnection.TableData + "\""))
                                                                                                         .ToListAsync();
                        _TablePrimaryKey.ChiavePrimaria_POSTGRESQL = _TablePrimaryKey_POSTGRESQL;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        return _TablePrimaryKey;
    }

    public static async Task<TableForeignKey> GetTableForeignKeyDB(DatabaseConnection databaseConnection)
    {
        TableForeignKey _TableForeignKey = new TableForeignKey();
        List<TableForeignKey_SQLSERVER> _TableForeignKey_SQLSERVER = new List<TableForeignKey_SQLSERVER>();
        List<TableForeignKey_SQLITE> _TableForeignKey_SQLITE = new List<TableForeignKey_SQLITE>();
        List<TableForeignKey_POSTGRESQL> _TableForeignKey_POSTGRESQL = new List<TableForeignKey_POSTGRESQL>();

        using (var context = SetDB(databaseConnection))
        {
            try
            {
                switch (databaseConnection.Provider)
                {

                    case "SQLSERVER":
                        _TableForeignKey_SQLSERVER = await context.TableForeignKey_SQLSERVER.FromSqlRaw(SQLRawQuery.SQLSERVER_ForeignKey
                                                                                                       , new SqlParameter("Table", databaseConnection.TableData))
                                                                                                       .ToListAsync();
                        _TableForeignKey.tableForeignKey_SQLSERVER = _TableForeignKey_SQLSERVER;
                        break;

                    case "SQLITE":
                        _TableForeignKey_SQLITE = await context.TableForeignKey_SQLITE.FromSqlRaw(SQLRawQuery.SQLITE_ForeignKey
                                                                                                 , new SqliteParameter("Table", databaseConnection.TableData))
                                                                                                 .ToListAsync();
                        _TableForeignKey.tableForeignKey_SQLITE = _TableForeignKey_SQLITE;
                        break;
                    case "POSTGRESQL":
                        _TableForeignKey_POSTGRESQL = await context.TableForeignKey_POSTGRESQL.FromSqlRaw(SQLRawQuery.POSTGRESQL_ForeignKey
                                                                                                         , new NpgsqlParameter("Table", databaseConnection.TableData))
                                                                                                         .ToListAsync();
                        _TableForeignKey.tableForeignKey_POSTGRESQL = _TableForeignKey_POSTGRESQL;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        return _TableForeignKey;
    }

    public static async Task<TableIndexDB> GetTableIndexDB(DatabaseConnection databaseConnection)
    {
        TableIndexDB _TableIndex = new TableIndexDB();
        List<TableIndex_SQLSERVER> _TableIndex_SQLSERVER = new List<TableIndex_SQLSERVER>();
        List<TableIndex_SQLITE> _TableIndex_SQLITE = new List<TableIndex_SQLITE>();
        List<TableIndex_POSTGRESQL> _TableIndex_POSTGRESQL = new List<TableIndex_POSTGRESQL>();


        using (var context = SetDB(databaseConnection))
        {
            try
            {
                switch (databaseConnection.Provider)
                {
                    case "SQLSERVER":
                        _TableIndex_SQLSERVER = await context.TableIndex_SQLSERVER.FromSqlRaw(SQLRawQuery.SQLSERVER_Index
                                                                                             , new SqlParameter("Table", databaseConnection.TableData))
                                                                                             .ToListAsync();
                        _TableIndex.tableIndex_SQLSERVER = _TableIndex_SQLSERVER;
                        break;
                    case "SQLITE":
                        _TableIndex_SQLITE = await context.TableIndex_SQLITE.FromSqlRaw(SQLRawQuery.SQLITE_Index
                                                                                       , new SqliteParameter("Table", databaseConnection.TableData))
                                                                                       .ToListAsync();
                        _TableIndex.tableIndex_SQLITE = _TableIndex_SQLITE;
                        break;
                    case "POSTGRESQL":
                        _TableIndex_POSTGRESQL = await context.TableIndex_POSTGRESQL.FromSqlRaw(SQLRawQuery.POSTGRESQL_Index
                                                                                               , new NpgsqlParameter("Table", databaseConnection.TableData))
                                                                                               .ToListAsync();
                        _TableIndex.tableIndex_POSTGRESQL = _TableIndex_POSTGRESQL;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        return _TableIndex;
    }

    public static async Task<List<object[]>> GetSelectQuery(DatabaseConnection databaseConnection)
    {
        var options = new DbContextOptionsBuilder<DataContext>()
        .Use(databaseConnection.Provider, databaseConnection.ConnectionString)
        .Options;
        using (var context = SetDB(databaseConnection))
        {
            try
            {
                switch (databaseConnection.Provider)
                {
                    case "SQLSERVER":
                        var querySQLSERVER = Helper.RawSqlQuery(options, databaseConnection.Query);
                        return querySQLSERVER;


                    case "SQLITE":
                        var querySQLITE = Helper.RawSqlQuery(options, databaseConnection.Query);
                        return querySQLITE;


                    case "POSTGRESQL":

                        var queryPOSTGRESQL = Helper.RawSqlQuery(options, databaseConnection.Query);
                        return queryPOSTGRESQL;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<object[]>();
            }
            return new List<object[]>();
        }
    }
    

        public static async Task<Response> GetQuery(DatabaseConnection databaseConnection)
    {
        var options = new DbContextOptionsBuilder<DataContext>()
        .Use(databaseConnection.Provider, databaseConnection.ConnectionString)
        .Options;
        Response response = new Response();
        using (var context = new DataContext(options))
        {
            try
            {
                await context.Database.ExecuteSqlRawAsync(databaseConnection.Query);
                response.QueryResponse = "OK";
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.QueryResponse = "NOT_OK";
                return response;


            }
        }
    }

    public static async Task<Response> ExpCSV(DatabaseConnection databaseConnection)
    {
        Response response = new Response();

        try
        {
            Helper.createDataTable(databaseConnection);
            response.ExportResponse = "OK";
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            response.ExportResponse = "NOT_OK";
            return response;
        }

    }


}
