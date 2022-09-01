using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcAdmin.Shared
{
    public class DatabaseConnection
    {
        public string Provider { get; set; }
        public string ConnectionString { get; set; }
        public string TableData { get; set; }  = string.Empty;
        public string Query { get; set; } = string.Empty;

    }
}
