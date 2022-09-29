using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcAdmin.Shared
{
    public static class SQLRawQuery
    {
        public static string SQLSERVER_TablesList = "SELECT NomeTabella = t.TABLE_NAME FROM information_schema.tables t;";
        public static string SQLITE_TablesList = "SELECT name FROM sqlite_schema WHERE type = 'table' AND name NOT LIKE 'sqlite_%';";
        public static string POSTGRESQL_TablesList = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'public' ORDER BY table_name";

        public static string SQLSERVER_PrimaryKey = "SELECT ChiavePrimaria = p.COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE p  WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1 AND TABLE_NAME = @Table";
        public static string SQLITE_PrimaryKey = "SELECT l.name FROM pragma_table_info(@Table) as l WHERE l.pk = 1;";
        public static string POSTGRESQL_PrimaryKey = "SELECT a.attname, format_type(a.atttypid, a.atttypmod) AS data_type FROM pg_index i JOIN pg_attribute a ON a.attrelid = i.indrelid AND a.attnum = ANY(i.indkey) WHERE  i.indrelid = @Table::regclass AND i.indisprimary;";

        public static string SQLSERVER_ForeignKey = "SELECT obj.name AS FK_NAME, sch.name AS[schema_name], tab1.name AS[table], col1.name AS[column], tab2.name AS[referenced_table], col2.name AS[referenced_column], TY.[name] AS system_data_type, col1.[max_length], col1.[precision], col1.[scale], col1.[is_nullable], col1.[is_ansi_padded] FROM sys.foreign_key_columns fkc INNER JOIN sys.objects obj ON obj.object_id = fkc.constraint_object_id INNER JOIN sys.tables tab1 ON tab1.object_id = fkc.parent_object_id INNER JOIN sys.schemas sch ON tab1.schema_id = sch.schema_id INNER JOIN sys.columns col1 ON col1.column_id = parent_column_id AND col1.object_id = tab1.object_id INNER JOIN sys.tables tab2 ON tab2.object_id = fkc.referenced_object_id INNER JOIN sys.columns col2 ON col2.column_id = referenced_column_id AND col2.object_id = tab2.object_id INNER JOIN sys.[types] TY ON col1.[system_type_id] = TY.[system_type_id] AND col1.[user_type_id] = TY.[user_type_id]  AND tab1.name = @Table";
        public static string SQLITE_ForeignKey = "SELECT m.name , p.* FROM sqlite_master m JOIN pragma_foreign_key_list(m.name) p ON m.name != p.\"table\"  WHERE m.type = 'table' ORDER BY m.name and name=@Table ;";
        public static string POSTGRESQL_ForeignKey = "SELECT tc.table_name, kcu.column_name, ccu.table_name AS foreign_table_name, ccu.column_name AS foreign_column_name FROM information_schema.table_constraints AS tc JOIN information_schema.key_column_usage AS kcu ON tc.constraint_name = kcu.constraint_name JOIN information_schema.constraint_column_usage AS ccu ON ccu.constraint_name = tc.constraint_name WHERE constraint_type = 'FOREIGN KEY' and tc.table_name = @Table;";

        public static string SQLSERVER_Index = "SELECT Nome = i.name, Index_ID = i.index_id, Unico = i.is_unique, PrimaryKey = i.is_primary_key from sys.indexes i where i.object_id = (select object_id from sys.objects where name = @Table)";
        public static string SQLITE_Index = "SELECT m.tbl_name as table_name, il.name as index_name, ii.name as column_name, CASE il.origin when 'pk' then 1 else 0 END as is_primary_key, CASE il.[unique] when 1 then 0 else 1 END as non_unique, il.[unique] as is_unique, il.partial, il.seq as sequence_in_index, ii.seqno as sequence_in_column FROM sqlite_master AS m, pragma_index_list(m.name) AS il, pragma_index_info(il.name) AS ii WHERE m.type = 'table' and m.tbl_name = @Table GROUP BY m.tbl_name, il.name, ii.name, il.origin, il.partial, il.seq ORDER BY index_name,il.seq,ii.seqno";
        public static string POSTGRESQL_Index = "SELECT * from pg_indexes where tablename not like 'pg%' and tablename=@Table";


    }
}
