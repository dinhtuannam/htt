using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_table_status")]
    public class SqlTableStatus
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public bool isdeleted { get; set; } = false;
        public List<SqlTable>? tables { get; set; }
    }
}
