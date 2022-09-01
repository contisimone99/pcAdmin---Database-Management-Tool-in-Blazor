using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using pcAdmin.Server.Data;
using pcAdmin.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pcAdmin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pcAdminController : ControllerBase
    {

        public pcAdminController()
        { }

        public DataContext SetDB(DatabaseConnection databaseConnection)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .Use(databaseConnection.Provider, databaseConnection.ConnectionString)
            .Options;
            var context = new DataContext(options);
            return context;
        }


        public async Task<List<TablesList>> GetTablesListDB(DatabaseConnection databaseConnection)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .Use(databaseConnection.Provider, databaseConnection.ConnectionString)
            .Options;
            List<TablesList> _TablesList = new List<TablesList>();
            using (var context = new DataContext(options))
            {
                try
                {
                    switch (databaseConnection.Provider)
                    {
                        case "SQLSERVER":
                            _TablesList = await context.TablesList.FromSqlRaw("SELECT \r\n    NomeTabella = t.TABLE_NAME\r\nFROM\r\n    information_schema.tables t;").ToListAsync();
                            break;

                        case "SQLITE":
                            break;

                        case "POSTGRESQL":
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

        public async Task<List<TableInfo>> GetTableInfoDB(DatabaseConnection databaseConnection)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .Use(databaseConnection.Provider, databaseConnection.ConnectionString)
            .Options;
            List<TableInfo> _TableInfo = new List<TableInfo>();
            using (var context = new DataContext(options))
            {
                try
                {
                    switch (databaseConnection.Provider)
                    {
                        case "SQLSERVER":
                            _TableInfo = await context.TableInfo.FromSqlRaw("SELECT DISTINCT  NomeColonna = i.COLUMN_NAME,\r\n\t   TipoDato = i.DATA_TYPE,\r\n\t   IsNullable = i.IS_NULLABLE\r\n\t   from information_schema.columns  i\r\n\t   where TABLE_NAME = @Table", new SqlParameter("Table", databaseConnection.TableData)).ToListAsync();
                            break;

                        case "SQLITE":
                            break;

                        case "POSTGRESQL":
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return _TableInfo;
        }

        public async Task<List<TablePrimaryKey>> GetTablePrimaryKeyDB(DatabaseConnection databaseConnection)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .Use(databaseConnection.Provider, databaseConnection.ConnectionString)
            .Options;
            List<TablePrimaryKey> _TablePrimaryKey = new List<TablePrimaryKey>();
            using (var context = new DataContext(options))
            {
                try
                {
                    switch (databaseConnection.Provider)
                    {
                        case "SQLSERVER":
                            _TablePrimaryKey = await context.TablePrimaryKey.FromSqlRaw("SELECT ChiavePrimaria = p.COLUMN_NAME\r\nFROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE p\r\n WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1\r\nAND TABLE_NAME = @Table", new SqlParameter("Table", databaseConnection.TableData)).ToListAsync();
                            break;

                        case "SQLITE":
                            break;

                        case "POSTGRESQL":
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

        public async Task<List<TableForeignKey>> GetTableForeignKeyDB(DatabaseConnection databaseConnection)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .Use(databaseConnection.Provider, databaseConnection.ConnectionString)
            .Options;
            List<TableForeignKey> _TableForeignKey = new List<TableForeignKey>();
            using (var context = new DataContext(options))
            {
                try
                {
                    switch (databaseConnection.Provider)
                    {

                        case "SQLSERVER":
                            _TableForeignKey = await context.TableForeignKey.FromSqlRaw("SELECT  obj.name AS NomeForeignKey,\r\n    tab1.name AS [Tabella],\r\n    col1.name AS [Colonna],\r\n    tab2.name AS [Tabella_Referenziata],\r\n    col2.name AS [Colonna_Referenziata]\r\nFROM sys.foreign_key_columns fkc\r\nINNER JOIN sys.objects obj\r\n    ON obj.object_id = fkc.constraint_object_id\r\nINNER JOIN sys.tables tab1\r\n    ON tab1.object_id = fkc.parent_object_id\r\nINNER JOIN sys.schemas sch\r\n    ON tab1.schema_id = sch.schema_id\r\nINNER JOIN sys.columns col1\r\n    ON col1.column_id = parent_column_id AND col1.object_id = tab1.object_id\r\nINNER JOIN sys.tables tab2\r\n    ON tab2.object_id = fkc.referenced_object_id\r\nINNER JOIN sys.columns col2\r\n    ON col2.column_id = referenced_column_id AND col2.object_id = tab2.object_id").ToListAsync();
                            break;

                        case "SQLITE":
                            break;

                        case "POSTGRESQL":
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

        public async Task<List<TableIndex>> GetTableIndexDB(DatabaseConnection databaseConnection)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .Use(databaseConnection.Provider, databaseConnection.ConnectionString)
            .Options;
            List<TableIndex> _TableIndex = new List<TableIndex>();
            using (var context = new DataContext(options))
            {
                try
                {
                    switch (databaseConnection.Provider)
                    {
                        case "SQLSERVER":
                            _TableIndex = await context.TableIndex.FromSqlRaw("select Nome = i.name,\r\n\t   Index_ID = i.index_id,\r\n\t   Unico = i.is_unique,\r\n\t   PrimaryKey = i.is_primary_key\r\n\t   from sys.indexes i where i.object_id = (select object_id from sys.objects where name = @Table)", new SqlParameter("Table", databaseConnection.TableData)).ToListAsync();
                            break;

                        case "SQLITE":
                            break;

                        case "POSTGRESQL":
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

        public async Task<List<object[]>> GetSelectQuery(DatabaseConnection databaseConnection)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .Use(databaseConnection.Provider, databaseConnection.ConnectionString)
            .Options;
            using (var context = new DataContext(options))
            {
                try
                {
                    switch (databaseConnection.Provider)
                    {
                        case "SQLSERVER":
                            var querySQLSERVER = Helper.RawSqlQuery(options, databaseConnection.Query);
                            return querySQLSERVER;
                            break;

                        case "SQLITE":
                            var querySQLITE = context.Database.ExecuteSqlRaw(databaseConnection.Query);
                            break;

                        case "POSTGRESQL":
                            var queryPOSTGRESQL = context.Database.ExecuteSqlRaw(databaseConnection.Query);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        [HttpPost("gettableslist")]
        public async Task<IActionResult> GetTablesList(DatabaseConnection databaseConnection)
        {
            return base.Ok(await GetTablesListDB(databaseConnection));
        }

        [HttpPost("gettableinfo")]
        public async Task<IActionResult> GetTableInfo(DatabaseConnection databaseConnection)
        {
            return base.Ok(await GetTableInfoDB(databaseConnection));
        }

        [HttpPost("gettableprimarykey")]
        public async Task<IActionResult> GetTablePrimaryKey(DatabaseConnection databaseConnection)
        {
            return base.Ok(await GetTablePrimaryKeyDB(databaseConnection));
        }

        [HttpPost("gettableforeignkey")]
        public async Task<IActionResult> GetTableForeignKey(DatabaseConnection databaseConnection)
        {
            return base.Ok(await GetTableForeignKeyDB(databaseConnection));
        }


        [HttpPost("gettableindex")]
        public async Task<IActionResult> GetTableIndex(DatabaseConnection databaseConnection)
        {
            return base.Ok(await GetTableIndexDB(databaseConnection));
        }


        [HttpPost("sendquery")]
        public async Task<IActionResult> SendQuery(DatabaseConnection databaseConnection)
        {
           
                return base.Ok(await GetSelectQuery(databaseConnection));
        }




    }
}
