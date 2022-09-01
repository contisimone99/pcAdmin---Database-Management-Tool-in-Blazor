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
        [Key]

        public string NomeTabella { get; set; }

    }

    public class TableInfo
    {
        [Key]
        public string NomeColonna { get; set; }

        public string TipoDato{ get; set; }

        public string IsNullable { get; set; }

    }

    public class TablePrimaryKey
    {
        [Key]
        public string ChiavePrimaria { get; set; }

    }

    public class TableForeignKey
    {
        [Key]
        public string NomeForeignKey { get; set; }
        public string Tabella { get; set; }
        public string Colonna { get; set; }
        public string Tabella_Referenziata { get; set; }
        public string Colonna_Referenziata { get; set; }

    }

    public class TableIndex
    {
        [Key]
        public string Nome { get; set; }
        public int Index_ID { get; set; }
        public bool Unico { get; set; }
        public bool PrimaryKey { get; set; }
    }
}
