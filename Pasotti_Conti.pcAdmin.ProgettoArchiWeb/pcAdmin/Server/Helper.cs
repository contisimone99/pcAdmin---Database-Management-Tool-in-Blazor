using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using pcAdmin.Server.Data;
using pcAdmin.Server.Controllers;

public static class Helper
{
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
                    while(columns.Count > i)
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
                        while(c < colNum)
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
}