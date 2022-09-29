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

public static class Helper
{
    //Esegue una query Select e restituisce una Lista di Array di Oggetti
    public static List<object[]> RawSqlQuery(DbContextOptions<DataContext> options, string query)
    {
        using (var context = new DataContext(options))
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    var entities = new List<object[]>();
                    int i = 0;
                    object[] _objectArr2 = new object[100];
                    var columns = result.GetColumnSchema();
                    Array.Resize(ref _objectArr2, columns.Count);
                    while (columns.Count > i)
                    {
                        _objectArr2[i] = columns[i].ColumnName;
                        i++;
                    }
                    entities.Add(_objectArr2);
                    while (result.Read())
                    {
                        object[] _objectArr = new object[100];

                        int colNum = result.GetValues(_objectArr);
                        Array.Resize(ref _objectArr, colNum);

                        int c = 0;
                        while (c < colNum)
                        {
                            var _object = result.GetValue(c);
                            _objectArr[c] = _object;
                            _objectArr2[c] = columns[c].ColumnName;
                            c++;
                        }
                        entities.Add(_objectArr);
                    }

                    return entities;
                }
            }
        }
    }

    //Restituisce una Lista di Oggetti con all'interno tutte le informazioni della Table
    public static List<object[]> ReadTableInfo(DatabaseConnection databaseConnection, DbContextOptions<DataContext> options, string query)
    {
        var entities = new List<object[]>();

        using (var context = new DataContext(options))
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    int i = 0;
                    object[] _objectArr1 = new object[100];
                    object[] _objectArr2 = new object[100];
                    object[] _objectArr3 = new object[100];
                    object[] _objectArr4 = new object[100];
                    var columns = result.GetColumnSchema();
                    Array.Resize(ref _objectArr1, columns.Count);
                    Array.Resize(ref _objectArr2, columns.Count);
                    Array.Resize(ref _objectArr3, columns.Count);
                    Array.Resize(ref _objectArr4, columns.Count);

                    if (databaseConnection.Provider == "POSTGRESQL")
                    {
                        while (columns.Count > i)
                        {
                            _objectArr1[i] = columns[i].ColumnName;
                            _objectArr2[i] = columns[i].ColumnOrdinal;
                            _objectArr3[i] = columns[i].DataTypeName;
                            i++;
                        }
                        _objectArr4 = POSTGRESQL_ISNULLABLE(databaseConnection, options, columns.Count());
                    }
                    else
                    {
                        while (columns.Count > i)
                        {
                            _objectArr1[i] = columns[i].ColumnName;
                            _objectArr2[i] = columns[i].ColumnOrdinal;
                            _objectArr3[i] = columns[i].DataTypeName;
                            _objectArr4[i] = columns[i].AllowDBNull;
                            i++;
                        }
                    }
                    entities.Add(_objectArr1);
                    entities.Add(_objectArr2);
                    entities.Add(_objectArr3);
                    entities.Add(_objectArr4);

                }

                return entities;
            }
        }
    }

    //POSTGRES NON HA IL NULLABLE NEL GETCOLUMNSCHEMA E QUINDI LO ANDIAMO A PRENDERE TRAMITE COMMAND AL DB
    public static object[] POSTGRESQL_ISNULLABLE(DatabaseConnection databaseConnection, DbContextOptions<DataContext> options, int Columns_Count)
    {
        using (var context = new DataContext(options))
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT is_nullable FROM information_schema.columns WHERE table_schema = 'public' and table_name=@Table";
                command.CommandType = CommandType.Text;
                DbParameter parameter = command.CreateParameter();
                parameter.ParameterName = "Table";
                parameter.Value = databaseConnection.TableData;
                command.Parameters.Add(parameter);
                context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    object[] _objectArr = new object[Columns_Count];
                    int c = 0;
                    while (result.Read())
                    {

                        int colNum = result.GetValues(_objectArr);
                        int i = 0;
                        while (i < colNum)
                        {
                            var _object = result.GetValue(i);
                            _objectArr[c] = _object;
                            c++;
                            i++;
                        }
                    }
                    return _objectArr;
                }
            }
        }

    }


    //CREA IL FILE CSV
    public static void ToCSV(this DataTable dtDataTable, string strFilePath)
    {
        StreamWriter sw = new StreamWriter(strFilePath, false);
        for (int i = 0; i < dtDataTable.Columns.Count; i++)
        {
            sw.Write(dtDataTable.Columns[i]);
            if (i < dtDataTable.Columns.Count - 1)
            {
                sw.Write(",");
            }
        }
        sw.Write(sw.NewLine);
        foreach (DataRow dr in dtDataTable.Rows)
        {
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                if (!Convert.IsDBNull(dr[i]))
                {
                    string value = dr[i].ToString();
                    if (value.Contains(','))
                    {
                        value = String.Format("\"{0}\"", value);
                        sw.Write(value);
                    }
                    else
                    {
                        sw.Write(dr[i].ToString());
                    }
                }
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
        }
        sw.Close();
    }

    //CREA UN DATATABLE CHE PASSA AL ToCSV
    public static DataTable createDataTable(DatabaseConnection table_tocsv)
    {
        DataTable table = new DataTable();
        for (var i = 0; i < table_tocsv.SelectedTable[0].Count(); i++)
        {
            table.Columns.Add(table_tocsv.SelectedTable[0][i].ToString());
        }

        for (var c =1; c<table_tocsv.SelectedTable.Count();c++)
        {
            
                table.Rows.Add(table_tocsv.SelectedTable[c]);
            
        }
        
        ToCSV(table, "ExportedCSV\\"+table_tocsv.TableData+ ".csv");

        return table;
    }


}
