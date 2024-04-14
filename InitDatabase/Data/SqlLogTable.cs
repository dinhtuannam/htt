using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitDatabase.Data
{
    [Table("tb_log_table")]
    public class SqlLogTable
    {
        [Key]
        public long id { get; set; }
        public string note { get; set; } = "";
        public string customer_code { get; set; } = "";
        public SqlTable? table { get; set; }
        public SqlAction? action { get; set; }
        public DateTime time { get; set; }
    }
}
