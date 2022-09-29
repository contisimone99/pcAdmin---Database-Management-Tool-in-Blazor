using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcAdmin.Shared
{
    public class TablesList
    {
        public List<TablesList_SQLSERVER> NomeTabella_SQLSERVER { get; set; }
        public List<TablesList_SQLITE> NomeTabella_SQLITE{ get; set; }
        public List<TablesList_POSTGRESQL> NomeTabella_POSTGRESQL { get; set; }
    }

    public class TablesList_SQLSERVER
    {
        [Key]        
        public string NomeTabella { get; set; }
    }
    public class TablesList_SQLITE
    {
        [Key]
        [Column("name")]
        public string NomeTabella { get; set; }
    }

    public class TablesList_POSTGRESQL
    {
        [Key]
        [Column("table_name")]
        public string NomeTabella { get; set; }
    }

     public class TablePrimaryKey
    {
        public List<TablePrimaryKey_SQLSERVER> ChiavePrimaria_SQLSERVER { get; set; }
        public List<TablePrimaryKey_SQLITE> ChiavePrimaria_SQLITE { get; set; }
        public List<TablePrimaryKey_POSTGRESQL> ChiavePrimaria_POSTGRESQL { get; set; }
    }

    public class TablePrimaryKey_SQLSERVER
    {
        [Key]        
        public string ChiavePrimaria { get; set; }
    }
    public class TablePrimaryKey_SQLITE
    {
        [Key]
        [Column("name")]
        public string ChiavePrimaria { get; set; }
    }

    public class TablePrimaryKey_POSTGRESQL
    {
        [Key]
        [Column("attname")]
        public string ChiavePrimaria { get; set; }
    }



    public class TableForeignKey
    {
        public List<TableForeignKey_SQLSERVER> tableForeignKey_SQLSERVER { get; set; }
        public List<TableForeignKey_SQLITE> tableForeignKey_SQLITE { get; set; }
        public List<TableForeignKey_POSTGRESQL> tableForeignKey_POSTGRESQL { get; set; }



    }

    public class TableForeignKey_SQLSERVER
    {
        [Key]
        [Column("column")]
        public string NomeColonna { get; set; }

        [Column("referenced_table")]
        public string NomeTabellaEsterna { get; set; }

        [Column("referenced_column")]
        public string NomeColonnaEsterna { get; set; }

    }

    public class TableForeignKey_SQLITE
    {
        [Key]
        [Column("from")]
        public string NomeColonna { get; set; }
        
        [Column("table")]
        public string NomeTabellaEsterna { get; set; }

        [Column("to")]
        public string NomeColonnaEsterna { get; set; }

        
    }

    public class TableForeignKey_POSTGRESQL
    {
        [Key]
        [Column("column_name")]
        public string NomeColonna { get; set; }

        [Column("foreign_table_name")]
        public string NomeTabellaEsterna { get; set; }

        [Column("foreign_column_name")]
        public string NomeColonnaEsterna { get; set; }

    }


    public class TableIndexDB
    {
        public List<TableIndex_SQLSERVER> tableIndex_SQLSERVER { get; set; }
        public List<TableIndex_SQLITE> tableIndex_SQLITE { get; set; }
        public List<TableIndex_POSTGRESQL> tableIndex_POSTGRESQL { get; set; }
    }

    public class TableIndex_SQLSERVER
    {
        [Key]
        public string NomeIndex { get; set; }
    }

    public class TableIndex_SQLITE
    {
        [Key]
        [Column("index_name")]
        public string NomeIndex { get; set; }

    }


    public class TableIndex_POSTGRESQL
    {
        [Key]
        [Column("indexname")]
        public string NomeIndex { get; set; }
    }
}
