using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_tables")]
    public class SqlTable : DateEntity
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public bool isdeleted { get; set; } = false;
        public string customer_code { get; set; } = "";
        public SqlTableStatus? status { get; set; }
        public List<SqlLogTable>? logs { get; set; }
    }
}
